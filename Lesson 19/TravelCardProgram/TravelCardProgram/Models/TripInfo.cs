namespace TravelCardProgram.Models
{
    internal record TripInfo
    {
        public Guid Id { get; init; }
        public TransportType TransportType { get; init; }

    }
}
