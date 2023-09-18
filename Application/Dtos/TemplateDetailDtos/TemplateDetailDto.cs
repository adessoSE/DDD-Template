namespace DDDTemplate.Application.Dtos.TemplateDetailDtos
{
    public class TemplateDetailDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public List<TemplatePositionDto> TemplatePositions { get; set; } = new List<TemplatePositionDto>();
    }
}
