using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.BLL.Roles;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static Task Main(string[] args)
        {
            var services = new ServiceCollection();
            BusinessLogicLayerDIConfigurator.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            User user = new Guest(serviceProvider.GetRequiredService<IProductService>(),
                serviceProvider.GetRequiredService<IAccountService>(),
                serviceProvider.GetRequiredService<IOrderService>(),
                serviceProvider.GetRequiredService<IMapper>());
            return new MenuProgram(user).Run(CancellationToken.None);
        }
    }
}
