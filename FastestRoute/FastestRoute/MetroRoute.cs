namespace FastestRoute
{
    internal class MetroRoute : IRoutable
    {
        public int MinutesToGet { get; }

        public void Move()
        {
            Console.WriteLine($"The fastest way to get to the destination is to use a metro. It will take {MinutesToGet} minutes!");
        }

        public MetroRoute(int minutesToGet)
        {
            MinutesToGet = minutesToGet;
        }

        public override string ToString()
        {
            return "Metro";
        }
    }
}
