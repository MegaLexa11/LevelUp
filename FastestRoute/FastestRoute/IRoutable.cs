namespace FastestRoute
{
    internal interface IRoutable
    {
        int MinutesToGet { get; }

        void Move();

    }
}
