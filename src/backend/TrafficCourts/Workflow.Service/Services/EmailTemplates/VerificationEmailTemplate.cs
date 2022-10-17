﻿using TrafficCourts.Common.Features.EmailVerificationToken;
using TrafficCourts.Common.Features.Mail;
using TrafficCourts.Messaging.MessageContracts;
using TrafficCourts.Workflow.Service.Configuration;

namespace TrafficCourts.Workflow.Service.Services.EmailTemplates;

public class VerificationEmailTemplate : EmailTemplate<SendEmailVerificationEmail>, IVerificationEmailTemplate
{
    private readonly EmailConfiguration _emailConfiguration;
    private readonly IDisputeEmailVerificationTokenEncoder _encoder;
    private readonly ILogger<VerificationEmailTemplate> _logger;

    public VerificationEmailTemplate(EmailConfiguration emailConfiguration, IDisputeEmailVerificationTokenEncoder encoder, ILogger<VerificationEmailTemplate> logger) : base()
    {
        _emailConfiguration = emailConfiguration ?? throw new ArgumentNullException(nameof(emailConfiguration));
        _encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private const string SubjectTemplate = "Verify your email for traffic violation ticket {0}";
    private const string HtmlContentTemplate = @"
In order to confirm submission of your intent to dispute traffic violation ticket {0} click on the following link.
<br/>
<br/>
<a href='{1}'>{1}</a>
<br/>
<br/>
If you need more help, contact the Violation Ticket Centre toll free 1-877-661-8026, open weekdays 9am to 4pm.";

    public override EmailMessage Create(SendEmailVerificationEmail data)
    {
        EmailMessage sendEmail = new();

        sendEmail.From = Sender;
        sendEmail.To = data.EmailAddress;
        sendEmail.Subject = string.Format(SubjectTemplate, data.TicketNumber);
        sendEmail.HtmlContent = string.Format(HtmlContentTemplate, data.TicketNumber, CreateEmailVerificationUrl(data));
        return sendEmail;
    }

    private Uri CreateEmailVerificationUrl(SendEmailVerificationEmail data)
    {
        // https://tickets.gov.bc.ca/email/verify?token={token}

        var format = _emailConfiguration.EmailVerificationUrl;
        if (string.IsNullOrEmpty(format))
        {
            var property = EmailConfiguration.Section + "__" + nameof(EmailConfiguration.EmailVerificationUrl);
            _logger.LogError("Cannot create email validation link. Configuration {Property} is null or empty", property);
            throw new InvalidOperationException($"Cannot create email validation link. Configuration {property} is null or empty.");
        }

        var token = _encoder.Encode(new DisputeEmailVerificationToken { NoticeOfDisputeId = data.NoticeOfDisputeId, Token = data.Token });
        string uri = format + "?token=" + token;

        return new Uri(uri);
    }
}