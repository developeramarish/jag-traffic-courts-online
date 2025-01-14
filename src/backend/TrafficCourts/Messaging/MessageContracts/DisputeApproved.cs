﻿namespace TrafficCourts.Messaging.MessageContracts
{
    public class DisputeApproved
    {
        [Obsolete($"Use {nameof(GivenName1)}, {nameof(GivenName2)},  {nameof(GivenName3)} and {nameof(Surname)}")]
        public string? CitizenName { get; set; }

        public string? Surname { get; set; }
        public string? GivenName1 { get; set; }
        public string? GivenName2 { get; set; }
        public string? GivenName3 { get; set; }

        public DateTime? TicketIssuanceDate { get; set; }
        public string TicketFileNumber { get; set; } = String.Empty;
        public string IssuingOrganization { get; set; } = String.Empty;
        public string IssuingLocation { get; set; } = String.Empty;
        public string DriversLicence { get; set; } = String.Empty;
        public IList<ViolationTicketCount> ViolationTicketCounts { get; set; } = new List<ViolationTicketCount>();
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public Guid NoticeOfDisputeGuid { get; set; }
        public IList<DisputedCount> DisputeCounts { get; set; } = new List<DisputedCount>();
    }

    public class ViolationTicketCount
    {
        public int Count { get; set; } = 0;
        public string? Subparagraph { get; set; }
        public string Section { get; set; } = String.Empty;
        public string? Subsection { get; set; }
        public string? Paragraph { get; set; }
        public string Act { get; set; } = String.Empty;
        public double? Amount { get; set; }
    }

    public class DisputedCount
    {
        public int Count { get; set; } = 0;
        public string? DisputeType { get; set; }
    }
}
