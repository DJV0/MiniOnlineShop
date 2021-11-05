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
    public class UpdateProductPage : Page
    {
        public UpdateProductPage(MainProgram program) : base("Обновить товар", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);
            var admin = MainProgram.User as Admin;
            var name = Input.ReadString("Название:");
            var category = (ProductCategory)Enum.Parse(typeof(ProductCategory), Input.ReadString("Категория:"));
            var description = Input.ReadString("Описание:");
            var cost = Convert.ToDecimal(Input.ReadString("Цена:"));

            var result = admin.UpdateProduct(new ProductDto()
            {
                Name = name,
                Category = category,
                Description = description,
                Cost = cost
            });
            if (!result) Output.WriteLine("Ошибка при обновлении!");
            else Output.WriteLine("Обновление выполнено");

            Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
            await Program.NavigateBack(cancellationToken);

        }
    }
}
