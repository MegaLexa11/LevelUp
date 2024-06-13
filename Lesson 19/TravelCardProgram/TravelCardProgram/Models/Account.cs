namespace TravelCardProgram.Models
{
    internal class Account
    {
        public Guid Id { get; }
        public double? Balance { get; set; }

        //Вроде, это не нужно
        //public Guid TravelCardId { get; init; }

        public TravelCard TravelCard { get; init; } = default!;
    }
}
