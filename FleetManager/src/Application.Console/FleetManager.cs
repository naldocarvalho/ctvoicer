using EasyConsoleCore;
using FleetManager.AppConsole.Pages;

namespace FleetManager.AppConsole
{
    class FleetManager : Program
    {
        public FleetManager() : base("Menu Principal", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new PageInsert(this));
            AddPage(new PageEdit(this));
            AddPage(new PageDelete(this));
            AddPage(new PageList(this));
            AddPage(new PageFind(this));

            SetPage<MainPage>();
        }
    }
}