using Domain.Entities;
using EasyConsoleCore;
using Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;

namespace FleetManager.AppConsole.Pages
{
    class PageDelete : Page
    {
        public PageDelete(Program program) : base("Excluir Veículo", program)
        {

        }

        public async override void Display()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IVehicleService, VehicleService>()
                .BuildServiceProvider();

            var vehicleService = serviceProvider.GetService<IVehicleService>();

            //var services = new ServiceCollection();
            //services.AddTransient<IVehicleService, VehicleService>();

            //var provider = services.BuildServiceProvider();

            //var service1 = provider.GetService<IVehicleService>();

            base.Display();

            Output.WriteLine("");

            string chassi = Input.ReadString("Informe o chassi para pesquisa:");
            Output.WriteLine("");

            if (!string.IsNullOrEmpty(chassi))
            {
                Vehicle vehicle = await vehicleService.GetByChassisAsync(chassi);

                if (vehicle == null)
                {
                    Output.WriteLine(ConsoleColor.Red, "Veículo não localizado");
                }
                else
                {
                    if (Input.ReadString("Deseja excluir o cadastro (S/N):").ToUpper() == "S")
                    {
                        vehicleService.Delete(vehicle);
                        Output.WriteLine("");
                        Output.WriteLine(ConsoleColor.Green, "Cadastro excluído com sucesso.");
                    }
                    else
                    {
                        Output.WriteLine("");
                        Output.WriteLine(ConsoleColor.Green, "Operação cancelada pelo usuário.");
                    }
                }
            }
            else
            {
                Output.WriteLine("");
                Output.WriteLine(ConsoleColor.Red, "Não é possível fazer pesquisa sem informar o chassi do veículo.");
            }

            Output.WriteLine("");
            Input.ReadString("Pressione [Enter] para voltar para o Menu Principal");

            Program.NavigateHome();
        }
    }
}