﻿namespace TrafficCourts.Common.Features.Mail.Model
{
    public class MailTemplateCollection
    {
        public static readonly List<MailTemplate> DefaultMailTemplateCollection = new List<MailTemplate>
        {
        /// <summary>
        /// Default template email messages, for notifications on dispute state changes
        /// </summary>
        new MailTemplate()
            {
                TemplateName =  "SubmitDisputeTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Ticket Dispute for <ticketid> submitted.",
                PlainContentTemplate = "The ticket <ticketid> has been submitted, and will be reviewed.\n\nIf you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        new MailTemplate()
            {
                TemplateName = "CancelledDisputeTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Ticket Dispute for <ticketid> cancelled.",
                PlainContentTemplate = "Your ticket has been canceled and will no longer be disputed.\n\nIf you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        new MailTemplate()
            {
                TemplateName = "RejectedDisputeTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Ticket Dispute for <ticketid> rejected.",
                PlainContentTemplate = "Your dispute has been rejected and will not be processed.\n\nIf you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        new MailTemplate()
            {
                TemplateName = "ProcessingDisputeTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Ticket Dispute for <ticketid> is being processed.",
                PlainContentTemplate = "Your dispute is now being processed. You will receive more information once processing is complete.\n\nIf you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        new MailTemplate()
            {
                TemplateName = "VerificationEmailTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Verify your email for traffic violation ticket {ticketid}.",
                PlainContentTemplate = "In order to confirm submission of your intent to dispute traffic violation ticket {ticketid} click on the following link: " +
                    "{emailVerificationUrl}?guid={emailVerificationToken} " +
                    "If you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        new MailTemplate()
            {
                TemplateName = "DisputeUpdateRequestAcceptedTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "TBD (ie. Disputant contact information changes approved)",
                PlainContentTemplate = "TBD (ie. Your requested contact changes have been approved.)"
            },
        new MailTemplate()
            {
                TemplateName = "DisputeUpdateRequestRejectedTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "TBD (ie. Disputant contact information changes rejected)",
                PlainContentTemplate = "TBD (ie. Your requested contact changes have been rejected.)"
            },
        new MailTemplate()
            {
                TemplateName = "DisputeUpdateRequestReceivedTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "TBD (ie. Dispute update request(s) received)",
                PlainContentTemplate = "TBD (ie. Your request to update dispute information was received.)"
            },
        new MailTemplate()
            {
                TemplateName = "DisputantEmailUpdateSuccessfulTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Email verification successful",
                PlainContentTemplate = "TBD (ie. Your email address has been updated successfully.)"
            },
        new MailTemplate()
            {
                TemplateName = "UpdateEmailVerificationTemplate",
                Sender = "DoNotReply@tickets.gov.bc.ca",
                SubjectTemplate = "Verify your email update for traffic violation ticket {ticketid}.",
                PlainContentTemplate = "TBD (ie. In order to confirm your email update click on the following link): " +
                    "{emailVerificationUrl}?guid={emailVerificationToken} " +
                    "If you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm."
            },
        };

        public List<MailTemplate> MailTemplates { get; set; } = new List<MailTemplate>();
    }

    public class MailTemplate
    {
        /// <summary>
        /// The template name of the message
        /// </summary>
        public string TemplateName { get; set; } = String.Empty;

        /// <summary>
        /// The sender(from) of the e-mail message
        /// </summary>
        public string? Sender { get; set; }

        /// <summary>
        /// The subject text in the notification message
        /// </summary>
        public string SubjectTemplate { get; set; } = String.Empty;

        /// <summary>
        /// Plain content text of the email message.
        /// The code using the message, should know what keys to replace.
        /// </summary>
        public string? PlainContentTemplate { get; set; }

        /// <summary>
        /// HTML content text of the email message.
        /// </summary>
        public string? HtmlContentTemplate { get; set; }
    }
}
