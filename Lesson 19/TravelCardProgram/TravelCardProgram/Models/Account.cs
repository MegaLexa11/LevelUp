namespace TravelCardProgram.Models
{
    internal class Account
    {
        public Guid Id { get; }
        public double? Balance { get; set; }
        public Guid TravelCardId { get; init; }

        public TravelCard TravelCard { get; init; } = default!;
    }
}
