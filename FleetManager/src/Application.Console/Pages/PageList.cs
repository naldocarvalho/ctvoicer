using BetterConsoleTables;
using Domain.Entities;
using EasyConsoleCore;
using Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.AppConsole.Pages
{
    class PageList : Page
    {
        private static IServiceProvider serviceProvider;

        public PageList(Program program) : base("Listagem de todos os veículos", program)
        {

        }

        public async override void Display()
        {
            //var serviceProvider = new ServiceCollection()
            //    .AddSingleton<IVehicleService, VehicleService>()
            //    .BuildServiceProvider();

            RegisterServices();

            var vehicleService = serviceProvider.GetService<IVehicleService>();

            base.Display();

            Output.WriteLine("");

            IList<Vehicle> vehicles = await vehicleService.ListAsync();

            if (vehicles.Any())
            {
                Table table = new Table("Id", "Chassi", "Cor", "Tipo", "Capacidade")
                {
                    Config = TableConfiguration.Default()
                };

                vehicles.ToList().ForEach(x => table.AddRow(x.Id, x.Chassis, x.Color, x.Type, x.PassengerCapacity));

                ConsoleTables tables = new ConsoleTables(table);
                Output.WriteLine(tables.ToString());
            }
            else
            {
                Output.WriteLine(ConsoleColor.Green, "Nenhum veículo para exibir.");
                Output.WriteLine("");
            }

            DisposeServices();

            Input.ReadString("Pressione [Enter] para voltar para o Menu Principal");

            Program.NavigateHome();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IVehicleService, VehicleService>();
            serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }

            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}