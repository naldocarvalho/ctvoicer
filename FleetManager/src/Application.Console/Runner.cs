using Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace FleetManager.AppConsole
{
    class Runner
    {
        static void Main(string[] args)
        {
            //setup our DI
            //var serviceProvider = new ServiceCollection()
            //    .AddTransient<IVehicleService, VehicleService>()
            //    .BuildServiceProvider();

            new FleetManager().Run();
        }
    }
}