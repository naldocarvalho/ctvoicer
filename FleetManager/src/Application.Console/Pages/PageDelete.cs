using Domain.Entities;
using EasyConsoleCore;
using Infrastructure.Data.Repositories;
using Service.Services;
using System;

namespace FleetManager.AppConsole.Pages
{
    class PageDelete : Page
    {
        private readonly VehicleService service = new VehicleService(new VehicleRepository());

        public PageDelete(Program program)
            : base("Excluir Veículo", program)
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
                    if (Input.ReadString("Deseja excluir o cadastro (S/N):").ToUpper() == "S")
                    {
                        await service.DeleteAsync(vehicle.Id);

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