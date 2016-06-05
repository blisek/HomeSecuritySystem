using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;
using ConsoleUI.Helpers;

namespace ConsoleUI.Pages.Impl
{
    public class MainPage : PageBase
    {
        public MainPage() : base("Main page", "")
        {
            pageConnection.Add(new UsersPage());
            pageConnection.Add(new EventsLogPage());
        }

        public override object GetInput()
        {
            return PageHelper.ChoosePage();
        }

        public override bool ProcessInput(PageLayoutManager manager, object obj)
        {
            return PageHelper.GoToPage(manager, pageConnection, obj);
        }
    }
}
