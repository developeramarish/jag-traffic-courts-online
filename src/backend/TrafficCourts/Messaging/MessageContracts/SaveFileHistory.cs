﻿using TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0;

namespace TrafficCourts.Messaging.MessageContracts
{
    /// <summary>
    /// Interface message contract for saving file history
    /// </summary>
    public class SaveFileHistoryRecord
    {
        public FileHistoryAuditLogEntryType AuditLogEntryType { get; set; }
        public long? DisputeId { get; set; }
        public string? NoticeOfDisputeId { get; set; }
        public string? TicketNumber { get; set; }
        public string? ActionByApplicationUser { get; set; }
    }
}
