namespace DDDTemplate.Infrastructure.Models
{
    public class SmtpSettings
    {
        public int Port { get; set; }
        public string Host { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
    }
}

