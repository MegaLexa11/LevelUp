namespace FastestRoute
{
    internal static class RouteHandler
    {
        public static IRoutable FastestRoute(IRoutable[] transportArr)
        {
            IRoutable fastestTransport = transportArr[0];
            foreach (IRoutable transport in transportArr)
            {
                if (transport.MinutesToGet < fastestTransport.MinutesToGet)
                {
                    fastestTransport = transport;
                }
            }
            return fastestTransport;
        }
    }
}
