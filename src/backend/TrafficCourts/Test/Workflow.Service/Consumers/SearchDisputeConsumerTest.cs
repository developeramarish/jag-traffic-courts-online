﻿using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0;
using TrafficCourts.Messaging.MessageContracts;
using TrafficCourts.Workflow.Service.Consumers;
using TrafficCourts.Workflow.Service.Services;
using Xunit;

namespace TrafficCourts.Test.Workflow.Service.Consumers;

public class SearchDisputeConsumerTest
{

    private readonly Mock<ILogger<SearchDisputeConsumer>> _mockLogger;
    private readonly Mock<IOracleDataApiService> _oracleDataApiService;
    private readonly SearchDisputeConsumer _consumer;
    private readonly Mock<ConsumeContext<SearchDisputeRequest>> _context;
    private readonly SearchDisputeRequest _message;
    private readonly SearchDisputeResponse _expectedResponse;

    public SearchDisputeConsumerTest()
    {
        _message = new()
        {
            TicketNumber = "AX00000000",
            IssuedTime = "17:54"
        };
        _expectedResponse = new();
        _mockLogger = new();
        _oracleDataApiService = new();
        _consumer = new(_mockLogger.Object, _oracleDataApiService.Object);
        _context = new();
        _context.Setup(_ => _.Message).Returns(_message);
        _context.Setup(_ => _.CancellationToken).Returns(CancellationToken.None);
        _context.Setup(_ => _.RespondAsync<SearchDisputeResponse>(_expectedResponse));
    }

    [Fact]
    public async Task TestSearchDisputeConsumer_ExpectNull()
    {
        // Arrange 
        // oracle-data-api returns null 

        // Act 
        await _consumer.Consume(_context.Object);

        // Assert - expect response to be valid, but fields null. 
        VerifyExpectedResponse();
    }

    [Fact]
    public async Task TestSearchDisputeConsumer_ExpectResponse()
    {
        // Arrange 
        ICollection<DisputeResult> searchResult = new List<DisputeResult>
        {
            new()
            {
                DisputeId = 1,
                DisputeStatus = DisputeResultDisputeStatus.VALIDATED,
                JjDisputeStatus = DisputeResultJjDisputeStatus.IN_PROGRESS
            }
        };
        _oracleDataApiService.Setup(_ => _.SearchDisputeAsync(_message.TicketNumber, _message.IssuedTime, It.IsAny<CancellationToken>())).Returns(Task.FromResult(searchResult));
        _expectedResponse.DisputeId = "1";
        _expectedResponse.DisputeStatus = "VALIDATED";
        _expectedResponse.JJDisputeStatus = "IN_PROGRESS";

        // Act 
        await _consumer.Consume(_context.Object);

        // Assert - expect response to be valid and fields match. 
        VerifyExpectedResponse();
    }

    private void VerifyExpectedResponse()
    {
        _context.Verify(m => m.RespondAsync<SearchDisputeResponse>(It.Is<SearchDisputeResponse>(
            a => a.DisputeId == _expectedResponse.DisputeId
                && a.DisputeStatus == _expectedResponse.DisputeStatus
                && a.JJDisputeStatus == _expectedResponse.JJDisputeStatus
                && a.IsError == _expectedResponse.IsError
            )), Times.Once);
    }
}