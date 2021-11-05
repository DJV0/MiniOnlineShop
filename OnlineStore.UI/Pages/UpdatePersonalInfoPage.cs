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
    public class UpdatePersonalInfoPage : Page
    {
        public UpdatePersonalInfoPage(MainProgram program) : base("Обновить личную информацию", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var registeredUser = MainProgram.User as RegisteredUser;
            var name = Input.ReadString($"Имя ({registeredUser.Name}):");
            var lastName = Input.ReadString($"Фамилия ({registeredUser.LastName}):");
            var login = Input.ReadString($"Логин ({registeredUser.Login}):");
            var password = Input.ReadString($"Новый пароль:");

            bool result = registeredUser.UpdatePersonalInfo(new AccountDto()
            {
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
