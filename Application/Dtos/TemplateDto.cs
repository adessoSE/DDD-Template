namespace DDDTemplate.Application.Dtos
{
    public class TemplateDto
    { 
        public Guid Id { get; set; }        
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
    }
}
