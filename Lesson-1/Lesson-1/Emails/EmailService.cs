using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Lesson_1.Emails;

public class EmailService : IEmailService
{
    public void Send(string to, string subject, string text, string from)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = text };

        // send email
        var SmtpHost = "smtp.beget.com";
        var SmtpPort = 25;
        var SmtpUser = "asp2022gb@rodion-m.ru";
        var SmtpPass = "3drtLSa1";
        
        using var smtp = new SmtpClient();
        smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.None);
        smtp.Authenticate(SmtpUser, SmtpPass);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}