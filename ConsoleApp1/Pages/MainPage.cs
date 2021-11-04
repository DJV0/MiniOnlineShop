using OnlineStore.UI.EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.UI.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(EasyConsole.Program program, List<Option> menuItems) : base("Меню", program, menuItems.ToArray())
        {
        }
    }
}
