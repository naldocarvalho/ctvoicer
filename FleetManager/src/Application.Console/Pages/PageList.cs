﻿using BetterConsoleTables;
using Domain.Entities;
using EasyConsoleCore;
using Infrastructure.Data.Repositories;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.AppConsole.Pages
{
    class PageList : Page
    {
        private readonly VehicleService service = new VehicleService(new VehicleRepository());

        public PageList(Program program)
            : base("Page List", program)
        {
        }

        public async override void Display()
        {
            base.Display();

            Output.WriteLine("");

            IList<Vehicle> vehicles = await service.ListAsync();

            if (vehicles.Any())
            {
                Table table = new Table("Id", "Chassi", "Cor", "Tipo", "Capacidade")
                {
                    Config = TableConfiguration.Default()
                };

                foreach (Vehicle vehicle in vehicles)
                {
                    table.AddRow(vehicle.Id, vehicle.Chassis, vehicle.Color, vehicle.Type, vehicle.PassengerCapacity);
                }

                ConsoleTables tables = new ConsoleTables(table);
                Output.WriteLine(tables.ToString());
            }
            else
            {
                Output.WriteLine(ConsoleColor.Green, "Nenhum veículo para exibir.");
                Output.WriteLine("");
            }

            Input.ReadString("Pressione [Enter] para voltar para o Menu Principal");

            Program.NavigateHome();
        }
    }
}