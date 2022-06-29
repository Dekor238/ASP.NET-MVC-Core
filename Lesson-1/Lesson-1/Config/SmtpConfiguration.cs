namespace Lesson_1.Config;

public class SmtpConfiguration
{
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpToAddress { get; set; }
    
    // from secrets
    public string SmtpUser { get; set; }
    public string SmtpPass { get; set; }
}