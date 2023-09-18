using Kernel.Contracts.Interfaces.Entities;

namespace DDDTemplate.Domain.Entities
{
    public class TemplatePosition : IEntity<Guid>
    {        
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TemplateEntity TemplateEntity { get; set; }        
    }
}
