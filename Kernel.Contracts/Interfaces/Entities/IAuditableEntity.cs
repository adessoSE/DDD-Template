namespace Kernel.Contracts.Interfaces.Entities
{
    public interface IAuditableEntity
    {
        public DateTimeOffset Created { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        public Guid? LastModifiedBy { get; set; }
    }
}
