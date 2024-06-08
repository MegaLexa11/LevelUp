namespace TravelCardProgram.Models
{
    internal record TripInfo
    {
        public Guid Id { get; init; }
        public TransportType TransportType { get; init; }
        public double? Price { get; init; }

        public IEnumerable<Rate>? Rates { get; init; }

    }
}
