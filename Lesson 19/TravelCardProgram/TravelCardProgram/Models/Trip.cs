namespace TravelCardProgram.Models
{
    internal record Trip
    {
        public Guid Id { get; init; }
        public DateTime TripDate { get; init; }

        // Связи с терминалом и ЭПБ
        public Guid TerminalId { get; init; }
        public Guid TravelCardId { get; init; }

        public TravelCard TravelCard { get; init; } = default!;
        public Terminal Terminal { get; init; } = default!;


    }
}
