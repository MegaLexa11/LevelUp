namespace FastestRoute
{
    internal class BusRoute : IRoutable
    {
        public int MinutesToGet { get; }

        public void Move()
        {
            Console.WriteLine($"The fastest way to get to the destination is to use a bus. It will take {MinutesToGet} minutes!");
        }


        public BusRoute(int minutesToGet)
        {
            MinutesToGet = minutesToGet;
        }

        public override string ToString()
        {
            return "Bus";
        }
    }
}
