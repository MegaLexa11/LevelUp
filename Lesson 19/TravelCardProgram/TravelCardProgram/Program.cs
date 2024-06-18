using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelCardProgram.Models;


using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json");
        config.AddEnvironmentVariables();
        config.Build();
    })
    .ConfigureServices((context, services) =>
    {
        var connString = context.Configuration.GetConnectionString("TravelCardsDb");
        services.AddDbContext<TravelCardsDbContext>(options => options.UseNpgsql(connString));
    })
    .Build();

var services = host.Services;
var context = services.GetRequiredService<TravelCardsDbContext>();

await host.RunAsync();