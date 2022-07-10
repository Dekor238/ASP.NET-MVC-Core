using Lesson_1.Config;
using Lesson_1.DAL;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Lesson_1.Emails;

public class EmailService : IEmailService
{
    private readonly SmtpConfiguration _smtpConfiguration;
    //private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;
    
    public EmailService(IOptionsSnapshot<SmtpConfiguration> options, ILogger<EmailService> logger)
    {
        //_configuration = configuration;
        _logger = logger;
        _smtpConfiguration = options.Value;
    }

    public void Send(string subject, string text)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpConfiguration.SmtpUser));
            email.To.Add(MailboxAddress.Parse(_smtpConfiguration.SmtpToAddress));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = text };
        
            using var smtp = new SmtpClient();
            smtp.Connect(_smtpConfiguration.SmtpHost, _smtpConfiguration.SmtpPort, SecureSocketOptions.None);
            smtp.Authenticate(_smtpConfiguration.SmtpUser, _smtpConfiguration.SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Cannot send email!");
        }
    }
}