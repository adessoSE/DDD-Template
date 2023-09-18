namespace DDDTemplate.Contracts.Events.Payloads
{
    public class TemplatePositionPayload
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public IEnumerable<TravelCostPayload>? TravelCosts { get; set; }
    }
}
