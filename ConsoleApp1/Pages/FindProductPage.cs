using OnlineStore.UI.EasyConsole;
using System.Threading;
using System.Threading.Tasks;
using MainProgram = OnlineStore.UI.EasyConsole.Program;

namespace OnlineStore.UI.Pages
{
    class FindProductPage : Page
    {
        public FindProductPage(MainProgram program) : base("Найти товар по названию", program)
        {
        }
        public override async Task Display(CancellationToken cancellationToken)
        {
            await base.Display(cancellationToken);

            string productName = Input.ReadString("Название товара:");
            var product = MainProgram.User.GetProduct(productName);
            if(product == null) Output.WriteLine("Продукт не найден!");
            else Output.WriteLine(product.ToString());

            Input.ReadString("\nНажмите [Enter] чтобы вернуться в меню.");
            await Program.NavigateBack(cancellationToken);
        }
    }
}
