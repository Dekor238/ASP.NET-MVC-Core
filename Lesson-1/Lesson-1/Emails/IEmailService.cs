using Lesson_1.Config;
using Lesson_1.DAL;
using Microsoft.Extensions.Options;

namespace Lesson_1.Emails;

public interface IEmailService
{
    public void Send(string subject, string text); // new from IOptionsSnapshot

}