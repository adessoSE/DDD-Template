namespace Kernel.Contracts.Interfaces.Events
{
    public interface IDomainEvent
    {
        Guid CorrelationId { get; }
        bool IsPublished { get; }        
        DateTimeOffset DateOccurred { get; }
        Guid CreatedBy { get; }
        void SetPublish(bool published);
    }
}
