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
    public class SignInPage : Page
    {
        public SignInPage(MainProgram program) : base("Вход в аккаунт", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);
            var guest = MainProgram.User as Guest;
            string login = Input.ReadString("Логин:");
            string password = Input.ReadString("Пароль:");
            var result = guest.SignIn(login, password, user => MainProgram.User = user);
            if (!result)
            {
                Output.WriteLine("Ошибка авторизации!");
                Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                await Program.NavigateHome(cancellationToken);
            }

            if(MainProgram.User is Admin)
            {
                Program.SetPage<AdminMainPage>();
                Program.History.Clear();
                await Program.NavigateTo<AdminMainPage>(cancellationToken);
            }

            Program.SetPage<RegisteredMainPage>();
            Program.History.Clear();
            await Program.NavigateTo<RegisteredMainPage>(cancellationToken);

        }
    }
}
