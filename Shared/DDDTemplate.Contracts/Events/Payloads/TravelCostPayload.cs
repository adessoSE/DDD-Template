namespace DDDTemplate.Contracts.Events.Payloads
{
    public class TravelCostPayload
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public double Distance { get; set; }        
    }
}
