using OnlineStore.BLL.Roles;
using OnlineStore.UI.EasyConsole;
using OnlineStore.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.UI
{
    class MenuProgram : EasyConsole.Program
    {

        public MenuProgram(User user) : base("storesolid", breadcrumbHeader: true, user)
        {
            var mainMenuItems = new List<Option>()
            {
                new Option("Найти товар", NavigateTo<FindProductPage>),
                new Option("Войти в аккаунт", NavigateTo<SignInPage>),
                new Option("Зарегистрироваться", NavigateTo<RegistrateUserPage>)
            };

            var registeredMainMenuItems = new List<Option>()
            {
                new Option("Найти товар", NavigateTo<FindProductPage>),
                new Option("Список товаров", NavigateTo<GetProductsPage>),
                new Option("Оформить заказ", NavigateTo<CreateOrderPage>),
                new Option("История заказов", NavigateTo<GetOrdersPage>),
                new Option("Изменить статус заказа", NavigateTo<ChangeOrderStatusPage>),
                new Option("Обновить личную информацию", NavigateTo<UpdatePersonalInfoPage>),
                new Option("Выйти из аккаунта", NavigateTo<SignOutPage>)
            };

            var adminMainMenuItems = new List<Option>()
            {
                new Option("Добавить товар", NavigateTo<AddProductPage>),
                new Option("Обновить товар", NavigateTo<UpdateProductPage>),
                new Option("Список пользователей", NavigateTo<GetAccountsPage>),
                new Option("Обновить пользователя", NavigateTo<UpdateAccountPage>)
            };

            AddPage(new MainPage(this, mainMenuItems));
            AddPage(new FindProductPage(this));
            AddPage(new GetProductsPage(this));
            AddPage(new AddProductPage(this));
            AddPage(new UpdateProductPage(this));
            AddPage(new SignInPage(this));
            AddPage(new RegistrateUserPage(this));
            AddPage(new RegisteredMainPage(this, registeredMainMenuItems));
            AddPage(new SignOutPage(this));
            AddPage(new AdminMainPage(this, registeredMainMenuItems.Union(adminMainMenuItems).ToList()));
            AddPage(new UpdatePersonalInfoPage(this));
            AddPage(new GetAccountsPage(this));
            AddPage(new UpdateAccountPage(this));
            AddPage(new CreateOrderPage(this));
            AddPage(new GetOrdersPage(this));
            AddPage(new ChangeOrderStatusPage(this));

            SetPage<MainPage>();
        }
    }
}
