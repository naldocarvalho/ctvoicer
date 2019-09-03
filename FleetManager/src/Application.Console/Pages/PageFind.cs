using Domain.Entities;
using EasyConsoleCore;
using Repository.Vehicles;
using Service.Services;
using System;

namespace FleetManager.AppConsole.Pages
{
    class PageFind : Page
    {
        private readonly VehicleService service = new VehicleService(new VehicleRepository());

        public PageFind(Program program)
            : base("Localizar Veículo", program)
        {
        }

        public async override void Display()
        {
            base.Display();

            Output.WriteLine("");

            string chassi = Input.ReadString("Informe o chassi para pesquisa:");
            Output.WriteLine("");

            if (!string.IsNullOrEmpty(chassi))
            {
                Vehicle vehicle = await service.GetByChassisAsync(chassi);

                if (vehicle == null)
                {
                    Output.WriteLine(ConsoleColor.Red, "Veículo não localizado");
                }
                else
                {
                    Output.WriteLine(ConsoleColor.Green, $"Dados do Veículo");
                    Output.WriteLine($"Chassi                     : {vehicle.Chassis}");
                    Output.WriteLine($"Cor                        : {vehicle.Color}");
                    Output.WriteLine($"Tipo                       : {vehicle.Type}");
                    Output.WriteLine($"Capacidade de passageiros  : {vehicle.PassengerCapacity}");
                    Output.WriteLine("");
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