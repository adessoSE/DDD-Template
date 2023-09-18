using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace DDDTemplate.Infrastructure.Services
{
    public class SmtpEmailSender : IEmailService
    {
        private SmtpSettings _smtpSettings;
        
        public SmtpEmailSender(IConfiguration configuration)
        {
            _smtpSettings = new SmtpSettings();
            configuration.GetSection("SmtpSettings").Bind(_smtpSettings);            
        }

        public void SendEMail(string subject, string message, User recipient)
        {
            if (!string.IsNullOrEmpty(recipient.Email) && _smtpSettings is not null)
            {
                using var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
                var mailMessage = new MailMessage();
                mailMessage.To.Add(recipient.Email);
                mailMessage.From = new MailAddress(_smtpSettings.Sender);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = message;
                client.Send(mailMessage);
            }            
        }
    }
}
