namespace TravelCardProgram.Models
{
    internal record TravelCard
    {
        public Guid Id { get; init; }
        public string Number { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public Guid AccountId { get; init; }
        public Guid RateId { get; init; }
        public Guid UserId { get; init; }

        public Account Account { get; init; } = default!;
        public Rate Rate { get; init; } = default!;
        public User User { get; init; } = default!;
    }
}
