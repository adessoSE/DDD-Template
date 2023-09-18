using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEMail(string subject, string message, User recipient);
    }
}

