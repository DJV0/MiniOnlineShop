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
    public class GetAccountsPage : Page
    {
        public GetAccountsPage(MainProgram program) : base("Список пользователей", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var admin = MainProgram.User as Admin;
            foreach (var account in admin.GetAccounts())
            {
                Output.WriteLine(account.ToString());
            }

            Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
            await Program.NavigateBack(cancellationToken);
        }
    }
}
