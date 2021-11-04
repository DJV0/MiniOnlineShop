using OnlineStore.BLL.Roles;
using OnlineStore.BLL.Dto;
using OnlineStore.UI.EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainProgram = OnlineStore.UI.EasyConsole.Program;

namespace OnlineStore.UI.Pages
{
    public class RegistrateUserPage : Page
    {
        public RegistrateUserPage(MainProgram program) : base("Регистрация пользователя", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var guest = MainProgram.User as Guest;
            var name = Input.ReadString("Имя:");
            var lastName = Input.ReadString("Фамилия:");
            var login = Input.ReadString("Логин:");
            var password = Input.ReadString("Пароль:");

            bool result = guest.RegistrateUser(new AccountDto()
            {
                Name = name,
                LastName = lastName,
                Login = login,
                Password = password
            });

            if (!result)
            {
                Output.WriteLine("Ошибка регистрации!");
                Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                await Program.NavigateHome(cancellationToken);
            } 

            Output.WriteLine("Регистрация прошла успешно!");
            Input.ReadString("\nНажмите [Enter] чтобы перейти ко входу.");
            await Program.NavigateHome(cancellationToken);


            
        }
    }
}
