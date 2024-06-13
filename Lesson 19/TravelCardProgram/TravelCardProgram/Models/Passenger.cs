namespace TravelCardProgram.Models
{
    internal record Passenger
    {
        public Guid Id { get; }
        public string Name { get; } = default!;

        public IEnumerable<TravelCard> TravelCards { get; init; } = default!;
    }
}
