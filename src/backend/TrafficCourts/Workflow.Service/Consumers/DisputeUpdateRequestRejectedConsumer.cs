﻿using MassTransit;
using Newtonsoft.Json;
using TrafficCourts.Common.Features.Mail.Templates;
using TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0;
using TrafficCourts.Messaging.MessageContracts;
using TrafficCourts.Workflow.Service.Services;
using DisputeUpdateRequest = TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0.DisputeUpdateRequest;

namespace TrafficCourts.Workflow.Service.Consumers;

public class DisputeUpdateRequestRejectedConsumer : IConsumer<DisputeUpdateRequestRejected>
{
    private readonly ILogger<DisputeUpdateRequestRejectedConsumer> _logger;
    private readonly IOracleDataApiService _oracleDataApiService;
    private readonly IDisputeUpdateRequestRejectedTemplate _updateRequestRejectedTemplate;
    private readonly IWorkflowDocumentService _workflowDocumentService;

    public DisputeUpdateRequestRejectedConsumer(
        ILogger<DisputeUpdateRequestRejectedConsumer> logger,
        IOracleDataApiService oracleDataApiService,
        IDisputeUpdateRequestRejectedTemplate updateRequestRejectedTemplate,
        IWorkflowDocumentService workflowDocumentService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _oracleDataApiService = oracleDataApiService ?? throw new ArgumentNullException(nameof(oracleDataApiService));
        _updateRequestRejectedTemplate = updateRequestRejectedTemplate ?? throw new ArgumentNullException(nameof(updateRequestRejectedTemplate));
        _workflowDocumentService = workflowDocumentService ?? throw new ArgumentNullException();
    }

    public async Task Consume(ConsumeContext<DisputeUpdateRequestRejected> context)
    {
        // TCVP-1974
        // - call oracle-data-api to update DisputeUpdateRequest status.
        // - send confirmation email indicating request was rejected
        // - populate file/email history records

        _logger.LogDebug("Consuming message");
        DisputeUpdateRequestRejected message = context.Message;

        // Set the status of the DisputeUpdateRequest object to REJECTED.
        DisputeUpdateRequest updateRequest = await _oracleDataApiService.UpdateDisputeUpdateRequestStatusAsync(message.UpdateRequestId, DisputeUpdateRequestStatus.REJECTED, context.CancellationToken);

        if (updateRequest?.UpdateType == DisputeUpdateRequestUpdateType.DISPUTANT_DOCUMENT)
        {
            // remove document from repository
            UpdateRequest? patch = JsonConvert.DeserializeObject<UpdateRequest>(updateRequest.UpdateJson);
            foreach(UploadDocumentRequest doc in patch?.UploadedDocuments)
            {
                if (doc.DocumentId is not null) await _workflowDocumentService.RemoveFileAsync((Guid)doc.DocumentId, context.CancellationToken);
            }
        }

        // Get the current Dispute by id
        Dispute dispute = await _oracleDataApiService.GetDisputeByIdAsync(updateRequest.DisputeId, false, context.CancellationToken);

        // send confirmation email to end user indicating their request was rejected
        if (dispute.EmailAddressVerified)
        {
            PublishEmailConfirmation(dispute, context);
        }

        // populate file history
        PublishFileHistoryLog(dispute, context);
    }

    private async void PublishEmailConfirmation(Dispute dispute, ConsumeContext<DisputeUpdateRequestRejected> context)
    {
        SendDisputantEmail message = new()
        {
            Message = _updateRequestRejectedTemplate.Create(dispute),
            NoticeOfDisputeGuid = new Guid(dispute.NoticeOfDisputeGuid),
            TicketNumber = dispute.TicketNumber
        };
        await context.PublishWithLog(_logger, message, context.CancellationToken);
    }

    private async void PublishFileHistoryLog(Dispute dispute, ConsumeContext<DisputeUpdateRequestRejected> context)
    {
        SaveFileHistoryRecord fileHistoryRecord = new()
        {
            DisputeId = dispute.DisputeId,
            AuditLogEntryType = FileHistoryAuditLogEntryType.DURR,
            ActionByApplicationUser = context.Message.UserName
        };
        await context.PublishWithLog(_logger, fileHistoryRecord, context.CancellationToken);
    }
}
