﻿using TrafficCourts.Common.Features.Mail;

namespace TrafficCourts.Messaging.MessageContracts
{
    /// <summary>
    /// Raised when a message was successfully sent to a disputant.
    /// </summary>
    public class DisputantEmailSent
    {
        /// <summary>
        /// The email message.
        /// </summary>
        public EmailMessage? Message { get; set; }

        /// <summary>
        /// The date and time the message was sent at.
        /// </summary>
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        /// Occam dispute Id
        /// </summary>
        public long OccamDisputeId { get; set; }
    }
}
