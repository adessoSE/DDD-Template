namespace Kernel.Contracts.Interfaces.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
