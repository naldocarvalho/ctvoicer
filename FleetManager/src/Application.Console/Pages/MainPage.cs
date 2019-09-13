using EasyConsoleCore;
using System;

namespace FleetManager.AppConsole.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(Program program) : base("Menu Principal", program,
                new Option("Inserir um veículo", () => program.NavigateTo<PageInsert>()),
                new Option("Editar um veículo existente", () => program.NavigateTo<PageEdit>()),
                new Option("Deletar um veículo existente", () => program.NavigateTo<PageDelete>()),
                new Option("Listar todos os veículos", () => program.NavigateTo<PageList>()),
                new Option("Encontrar veículo por Chassi", () => program.NavigateTo<PageFind>()),
                new Option("Sair", () => Environment.Exit(-1)))
        {
        }
    }
}