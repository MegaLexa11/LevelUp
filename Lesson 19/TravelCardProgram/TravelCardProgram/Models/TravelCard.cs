namespace TravelCardProgram.Models
{
    internal record TravelCard
    {
        public Guid Id { get; init; }
        public string Number { get; init; }
        public DateTime ActivationDate { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public bool IsActive  => ExpirationDate is null || ExpirationDate < DateTime.Now;
        public Guid AccountId { get; init; }
        public Guid TariffId { get; init; }
        public Guid PassengerId { get; init; }

        public Account Account { get; init; } = default!;
        public Tariff Tariff { get; init; } = default!;
        public Passenger Passenger { get; init; } = default!;
    }
}
