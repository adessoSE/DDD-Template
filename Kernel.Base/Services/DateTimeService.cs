using Kernel.Contracts.Interfaces.Services;

namespace Kernel.Base.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
