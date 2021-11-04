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
    public class GetOrdersPage : Page
    {
        public GetOrdersPage(MainProgram program) : base("История заказов", program)
        {

        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var registeredUser = MainProgram.User as RegisteredUser;
            foreach (var order in registeredUser.GetOrders())
            {
                Output.WriteLine(order.ToString() +"\nТовары:");
                foreach (var product in order.Products)
                {
                    Output.WriteLine(product.ToString());
                }
            }
            Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
            await Program.NavigateBack(cancellationToken);
        }
    }
}
