using Croni.Data.Database;
using Croni.Data.Repositories;
using Croni.ViewModels;
using Croni.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Croni
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
            containerRegistry.RegisterSingleton<IDatabase, Database>();
            containerRegistry.RegisterSingleton<ITransactionRepository, TransactionRepository>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountsPage, AccountsPageViewModel>();
            containerRegistry.RegisterForNavigation<TransactionsPage, TransactionsPageViewModel>();
            containerRegistry.RegisterForNavigation<CategoriesPage, CategoriesPageViewModel>();
        }
    }
}
