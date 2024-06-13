namespace TravelCardProgram.Models
{
    internal record Tariff
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public int? Duration { get; init; }
        public double UndergroundTripPrice { get; init; }
        public double GroundTripPrice { get; init; }
        //public Guid TravelCardId { get; init; }

        public IEnumerable<TravelCard> TravelCards { get; init; } = default!;
    }
}
