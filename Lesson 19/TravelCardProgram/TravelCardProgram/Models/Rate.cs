namespace TravelCardProgram.Models
{
    internal record Rate
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public int? Duration { get; init; }
        public Guid UndergroundTripId { get; init; }
        public Guid GroundTripId { get; init; }

        // Добавить IEnumerable TravelCard
        public TripInfo Trip { get; init; } = default!;
        public IEnumerable<TravelCard> TravelCards { get; init; } = default!;
    }
}
