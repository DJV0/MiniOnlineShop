using OnlineStore.BLL.Dto;
using OnlineStore.BLL.Roles;
using OnlineStore.UI.EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainProgram = OnlineStore.UI.EasyConsole.Program;

namespace OnlineStore.UI.Pages
{
    public class CreateOrderPage : Page
    {
        public CreateOrderPage(MainProgram program) : base("Оформить заказ", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var registeredUser = MainProgram.User as RegisteredUser;
            var productBasket = MainProgram.ProductBasket;
            Output.WriteLine("Список товаров в корзине:");
            for (int i = 0; i < productBasket.Count; i++)
            {
                Output.WriteLine($"{i + 1}. " + productBasket[i]);
            }

            string input = Input.ReadString("\nДоступные значения:\n" +
                "[+] - оформить заказ\n" +
                "[-] - отменить заказ\n" +
                "[Enter] - вернуться в меню:");
            switch (input)
            {
                case "+":
                    if(productBasket.Any())
                    {
                        Output.WriteLine("Корзина пуста!");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                    }
                    registeredUser.CreateOrder(new OrderDto()
                    {
                        User = registeredUser,
                        Products = productBasket
                    });
                    Output.WriteLine("Заказ оформлен.");
                    Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                    await Program.NavigateBack(cancellationToken);
                    break;
                case "-":
                    productBasket.Clear();
                    Output.WriteLine("Заказ отменен.");
                    Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                    await Program.NavigateBack(cancellationToken);
                    break;
                default:
                    await Program.NavigateBack(cancellationToken);
                    break;
            }
        }
    }
}
