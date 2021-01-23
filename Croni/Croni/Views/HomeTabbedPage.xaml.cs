using Croni.Services;
using Prism.Ioc;
using Xamarin.Forms;

namespace Croni.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
        }

        private void TabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            var toolbarService = ContainerLocator.Container.Resolve<IToolbarService>();

            if (sender is HomeTabbedPage homeTabbedPage)
            {
                if (homeTabbedPage.CurrentPage is AccountsPage)
                    toolbarService.SelectedTab = ViewName.Accounts;
                else if (homeTabbedPage.CurrentPage is CategoriesPage)
                    toolbarService.SelectedTab = ViewName.Categories;
                else if (homeTabbedPage.CurrentPage is TransactionsPage)
                    toolbarService.SelectedTab = ViewName.Transactions;
                else if (homeTabbedPage.CurrentPage is DashboardPage)
                    toolbarService.SelectedTab = ViewName.Dashboard;
            }
        }
    }
}
