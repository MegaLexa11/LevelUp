namespace TravelCardProgram.Models
{
    internal record User
    {
        public Guid Id { get; }
        public string Name { get; } = default!;

        public IEnumerable<TravelCard> TravelCards { get; init; }
    }
}
