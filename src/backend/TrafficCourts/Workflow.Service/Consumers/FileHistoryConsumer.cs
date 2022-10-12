﻿using MassTransit;
using TrafficCourts.Messaging.MessageContracts;
using TrafficCourts.Workflow.Service.Services;

namespace TrafficCourts.Workflow.Service.Consumers
{
    /// <summary>
    ///     Consumer for SendEmail message.
    /// </summary>
    public class FileHistoryConsumer : IConsumer<SaveFileHistoryRecord>
    {
        private readonly IFileHistoryService _fileHistoryService;

        public FileHistoryConsumer(IFileHistoryService fileHistoryService)
        {
            _fileHistoryService = fileHistoryService ?? throw new ArgumentNullException(nameof(fileHistoryService));
        }

        public async Task Consume(ConsumeContext<SaveFileHistoryRecord> context)
        {
            await _fileHistoryService.SaveFileHistoryAsync(context.Message, context.CancellationToken);
        }
    }
}