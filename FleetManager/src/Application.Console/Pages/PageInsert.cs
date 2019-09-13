﻿using Domain.Entities;
using EasyConsoleCore;
using Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;

namespace FleetManager.AppConsole.Pages
{
    class PageInsert : Page
    {
        public PageInsert(Program program) : base("Cadastro de Veículo", program)
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

            Vehicle vehicle = new Vehicle();

            try
            {
                string chassi = Input.ReadString("Informe o chassi:");
                vehicle.Chassis = chassi;

                string cor = Input.ReadString("Informe a cor   :");
                vehicle.Color = cor;

                Type typeVehicle = Input.ReadEnum<Type>("Informe o tipo  :");
                vehicle.Type = typeVehicle.ToString();

                Vehicle result = await vehicleService.GetByChassisAsync(chassi);

                if (result != null)
                {
                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.Red, $"Não é possível finalizar o cadastro pois já existe um veículo cadastrado com o chassi: {chassi}");
                }
                else
                {
                    await vehicleService.AddAsync(vehicle);

                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.Green, "Cadastro realizado com sucesso.");
                }

            }
            catch (Exception ex)
            {
                Output.WriteLine("");
                Output.WriteLine($"Erro: {ex.Message}");
                Output.WriteLine($"InnerException: {ex.InnerException}");
            }

            Output.WriteLine("");
            Input.ReadString("Pressione [Enter] para voltar para o Menu Principal");

            Program.NavigateHome();
        }

        enum Type
        {
            Ônibus,
            Caminhão
        }
    }
}