using Kernel.Base.Entities;

namespace DDDTemplate.Domain.Entities
{    
    public class TemplateEntity : AggregateRoot
    {                
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public bool Confirmed { get; set; }
        public List<TemplatePosition> TemplatePositions { get; set; } = new List<TemplatePosition>();
    }
}
