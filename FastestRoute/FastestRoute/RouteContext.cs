namespace FastestRoute
{
    internal class RouteContext
    {

        private IRoutable RouteToUse { get; set; }

        public RouteContext(IRoutable routeToUse)
        {
            RouteToUse = routeToUse;
        }

        public void SetRoute(IRoutable transportToUse)
        {
            RouteToUse = transportToUse;
        }

        public void UseRoute()
        {
            RouteToUse.Move();
        }
    }
}
