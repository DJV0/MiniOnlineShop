using OnlineStore.UI.EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;
using MainProgram = OnlineStore.UI.EasyConsole.Program;

namespace OnlineStore.UI.Pages
{
    public class AdminMainPage : MenuPage
    {
        public AdminMainPage(MainProgram program, List<Option> menuList) : base("Меню", program, menuList.ToArray())
        {
        }
    }
}
