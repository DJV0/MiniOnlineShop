using OnlineStore.BLL.Dto;
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
    public class ChangeOrderStatusPage : Page
    {
        public ChangeOrderStatusPage(MainProgram program) : base("Изменить стутус заказа", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            RegisteredUser registeredUser;
            string menu;
            if (MainProgram.User is Admin)
            {
                registeredUser = MainProgram.User as Admin;
                menu = "1. Отменить заказ\n" +
                "2. Оплата получена\n" +
                "3. Отправлено\n" +
                "4. Получено\n" +
                "5. Выполнено\n";
                Output.WriteLine(menu);
                var Id = Guid.Parse(Input.ReadString("Заказ id:"));
                var userInput = Input.ReadString("Введите номер статуса или [Enter] чтобы вернуться в меню:");
                switch (userInput)
                {
                    case "1":
                        registeredUser.ChangeOrderStatus(Id, OrderStatus.Canceled_by_the_administrator);
                        Output.WriteLine("Статут изменен.");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                        break;
                    case "2":
                        registeredUser.ChangeOrderStatus(Id, OrderStatus.Payment_received);
                        Output.WriteLine("Статут изменен.");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                        break;
                    case "3":
                        registeredUser.ChangeOrderStatus(Id, OrderStatus.Sent);
                        Output.WriteLine("Статут изменен.");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                        break;
                    case "4":
                        registeredUser.ChangeOrderStatus(Id, OrderStatus.Received);
                        Output.WriteLine("Статут изменен.");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                        break;
                    case "5":
                        registeredUser.ChangeOrderStatus(Id, OrderStatus.Completed);
                        Output.WriteLine("Статут изменен.");
                        Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                        await Program.NavigateBack(cancellationToken);
                        break;
                    default:
                        await Program.NavigateBack(cancellationToken);
                        break;
                }
            }

            registeredUser = MainProgram.User as RegisteredUser;
            menu = "1. Получено\n" +
            "2. Отменить заказ\n";
            Output.WriteLine(menu);
            var orderId = Guid.Parse(Input.ReadString("Заказ id:"));
            var input = Input.ReadString("Введите номер статуса или [Enter] чтобы вернуться в меню:");
            switch (input)
            {
                case "1":
                    registeredUser.ChangeOrderStatus(orderId, OrderStatus.Received);
                    Output.WriteLine("Статут изменен.");
                    Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
                    await Program.NavigateBack(cancellationToken);
                    break;
                case "2":
                    registeredUser.ChangeOrderStatus(orderId, OrderStatus.Canceled_by_user);
                    Output.WriteLine("Статут изменен.");
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
