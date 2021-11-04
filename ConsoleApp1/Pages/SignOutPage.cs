using OnlineStore.BLL.Roles;
using OnlineStore.UI.EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainProgram = OnlineStore.UI.EasyConsole.Program;

namespace OnlineStore.UI.Pages
{
    public class SignOutPage : Page
    {
        public SignOutPage(MainProgram program) : base("Вход в аккаунт", program) { }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var registeredUser = MainProgram.User as RegisteredUser;
            registeredUser.SignOut(user => MainProgram.User = user);

            Program.SetPage<MainPage>();
            Program.History.Clear();
            await Program.NavigateTo<MainPage>(cancellationToken);
        }
    }
}
