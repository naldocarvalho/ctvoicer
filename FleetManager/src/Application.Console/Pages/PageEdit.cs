using Domain.Entities;
using EasyConsoleCore;
using Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;

namespace FleetManager.AppConsole.Pages
{
    class PageEdit : Page
    {
        public PageEdit(Program program) : base("Editar Veículo", program)
        {
        }

        public async override void Display()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IVehicleService, VehicleService>()
                .BuildServiceProvider();

            var vehicleService = serviceProvider.GetService<IVehicleService>();

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
                    string cor = Input.ReadString("Informe a cor:");
                    vehicle.Color = cor;

                    if (!string.IsNullOrWhiteSpace(cor))
                    {
                        vehicleService.Update(vehicle);
                        Output.WriteLine("");
                        Output.WriteLine(ConsoleColor.Green, "Cadastro atualizado com sucesso.");
                    }
                    else
                    {
                        Output.WriteLine("");
                        Output.WriteLine(ConsoleColor.Red, "Não é possível editar o cadastro do veículo sem informar a cor.");
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