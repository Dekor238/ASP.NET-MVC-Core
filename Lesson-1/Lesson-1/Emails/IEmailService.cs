namespace Lesson_1.Emails;

public interface IEmailService
{
    void Send(string to, string subject, string text, string from);
}