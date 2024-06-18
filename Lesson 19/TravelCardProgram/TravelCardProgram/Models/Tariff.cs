namespace TravelCardProgram.Models
{
    internal record Tariff
    {
        public Guid Id { get; init; }
        // Название тарифа
        public string Name { get; init; } = default!;
        // Заложенная в тарифе длительность
        public int? Duration { get; init; }
        // Стоимость поездки под землей
        public double UndergroundTripPrice { get; init; }
        // Стоимость поездки под землей
        public double GroundTripPrice { get; init; }

        public IEnumerable<TravelCard> TravelCards { get; init; } = default!;
    }
}
