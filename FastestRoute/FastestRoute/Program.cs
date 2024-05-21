using FastestRoute;

// По идее, пользователь только точку Б в качестве пункта назначения, не зная точного расстояния, времени и т.п., поэтому сымитируем формирование времени до пункта назначения рандомом
Random rand = new Random();
BusRoute busRoute = new BusRoute(rand.Next(20, 40));
MetroRoute metroRoute = new MetroRoute(rand.Next(20, 40));
TaxiRoute taxiRoute = new TaxiRoute(rand.Next(20, 40));

IRoutable[] routes = new IRoutable[]{ busRoute, metroRoute, taxiRoute };

/*foreach (IRoutable route in routes)
{
    Console.WriteLine($"{route} {route.MinutesToGet}");
}*/

IRoutable fastestRoute = RouteHandler.FastestRoute(routes);

RouteContext transportContext = new RouteContext(fastestRoute);
transportContext.UseRoute();

// Допустим, прошло время возвращаться из точи Б. Также, если бы эта программа была менее гипотетической, то точно создавались бы новые объекты маршрутов, поэтому ниже создаем новые
busRoute = new BusRoute(rand.Next(20, 40));
metroRoute = new MetroRoute(rand.Next(20, 40));
taxiRoute = new TaxiRoute(rand.Next(20, 40));
routes = new IRoutable[] { busRoute, metroRoute, taxiRoute };

/*foreach (IRoutable route in routes)
{
    Console.WriteLine($"{route} {route.MinutesToGet}");
}*/

fastestRoute = RouteHandler.FastestRoute(routes);
transportContext.SetRoute(fastestRoute);
transportContext.UseRoute();