namespace FastestRoute
{
    internal class TaxiRoute : IRoutable
    {
        public int MinutesToGet { get; }

        public void Move()
        {
            Console.WriteLine($"The fastest way to get to the destination is to use a taxi. It will take {MinutesToGet} minutes!");
        }

        public TaxiRoute(int minutesToGet)
        {
            MinutesToGet = minutesToGet;
        }

        public override string ToString()
        {
            return "Taxi";
        }
    }
}
