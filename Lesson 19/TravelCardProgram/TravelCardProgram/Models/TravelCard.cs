namespace TravelCardProgram.Models
{
    internal record TravelCard
    {
        public Guid Id { get; init; }
        // Номер ЭПБ - как будто, у всех таких карт есть свой номер
        public string Number { get; init; }
        // Дата Активации ЭПБ
        public DateTime ActivationDate { get; init; }
        // Дата окончания действия ЭПБ
        public DateTime? ExpirationDate { get; init; }
        // Статус
        public TravelCardStatuses Status { get; init; }
        // Дата истечения повышенного коэффициента стоимости
        public DateTime? HighCoefficientExpiration { get; init; }
        // Применяется ли коэффициент
        public bool HighCoefficientActive { get; init; }

        // Связи со счетом, тарифом и пассажиром
        public Guid AccountId { get; init; }
        public Guid TariffId { get; init; }
        public Guid PassengerId { get; init; }

        public Account Account { get; init; } = default!;
        public Tariff Tariff { get; init; } = default!;
        public Passenger Passenger { get; init; } = default!;
        public IEnumerable<Trip> Trips { get; init; } = default!;
    }
}
