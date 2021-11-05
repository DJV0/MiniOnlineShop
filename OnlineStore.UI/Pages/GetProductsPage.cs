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
    public class GetProductsPage : Page
    {
        public GetProductsPage(MainProgram program) : base("Список товаров", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            var productList = ((RegisteredUser)MainProgram.User).GetProducts().ToList();
            for (int i = 0; i < productList.Count; i++)
            {
                Output.WriteLine($"{i + 1}. " + productList[i].ToString());
            }
            string input = Input.ReadString("Введите номер товара чтобы добавить его в корзину" +
                "или нажмите [Enter] чтобы вернуться в меню:");
            while (input != "")
            {
                int index = Convert.ToInt32(input) - 1;
                if (index >= 0 && index < productList.Count && !MainProgram.ProductBasket.Contains(productList[index])) 
                    MainProgram.ProductBasket.Add(productList[index]);
                
                input = Input.ReadString("Введите номер товара чтобы добавить его в корзину " +
                "или нажмите [Enter] чтобы вернуться в меню:");
            }

            await Program.NavigateBack(cancellationToken);
        }
    }
}
