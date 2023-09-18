namespace DDDTemplate.Contracts.Events.Payloads
{
    public class TemplatePayload
    {
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public List<TemplatePositionPayload> TemplatePositions { get; set; } = new List<TemplatePositionPayload>();
    }
}
