using Acr.UserDialogs;
using Croni.Data;
using Croni.Data.Database;
using Croni.Data.Repositories;
using Croni.Service;
using Croni.Services;
using Croni.ViewModels;
using Croni.Views;
using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
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

        protected async override void Initialize()
        {
            base.Initialize();

            var database = Container.Resolve<IDatabase>();
            await database.InitializeDatabase();
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("Mzg3NzE2QDMxMzgyZTM0MmUzMGxXMmJaak1DVDZFYWNVbW1UYms1a1BST2JXWk5WN3ZJc3ZEUDFaTnpjRTQ9");

            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(ViewName.MainPage)}/NavigationPage/{nameof(ViewName.HomeTabbedPage)}?selectedTab={nameof(ViewName.CategoriesPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterSingleton<IToolbarService, ToolbarService>();

            containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
            containerRegistry.RegisterSingleton<IDatabase, Database>();

            containerRegistry.RegisterSingleton<ITransactionRepository, TransactionRepository>();
            containerRegistry.RegisterSingleton<IAccountRepository, AccountRepository>();

            containerRegistry.RegisterSingleton<IUserDialogs>(sp => UserDialogs.Instance);
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();

            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountsPage, AccountsPageViewModel>();
            containerRegistry.RegisterForNavigation<TransactionsPage, TransactionsPageViewModel>();
            containerRegistry.RegisterForNavigation<CategoriesPage, CategoriesPageViewModel>();
            containerRegistry.RegisterForNavigation<NewAccountPage, NewAccountPageViewModel>();
        }
    }
}
