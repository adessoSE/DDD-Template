namespace Kernel.Contracts.Interfaces.Entities
{
    public interface IAggregateRoot : IEntity<Guid>, IAuditableEntity
    {
    }
}
