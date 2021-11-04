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
    public class UpdateAccountPage : Page
    {
        public UpdateAccountPage(MainProgram program) : base("Обновить пользователя", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var admin = MainProgram.User as Admin;
            var accountId = Guid.Parse(Input.ReadString("Id пользователя:"));
            var name = Input.ReadString("Имя:");
            var lastName = Input.ReadString("Фамилия:");
            var login = Input.ReadString("Логин:");
            var password = Input.ReadString("Пароль:");

            bool result = admin.UpdateAccount(new AccountDto()
            {
                Id = accountId,
                Name = name,
                LastName = lastName,
                Login = login,
                Password = password
            });

            if (!result)
            {
                Output.WriteLine("Ошибка при обновлении данных!");
                Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                await Program.NavigateBack(cancellationToken);
            }

            Output.WriteLine("Данные успешно обновлены!");
            Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
            await Program.NavigateBack(cancellationToken);
        }
    }
}
