using Croni.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Services
{
    public class ToolbarService : IToolbarService
    {
        public Action AccountsAction { get; set; }
        public Action CategoriesAction { get; set; }
        public Action DashboardAction { get; set; }
        public Action TransactionsAction { get; set; }

        public ViewName SelectedTab { get; set; }

        public void ExecuteAction()
        {
            if (SelectedTab == ViewName.Accounts)
                AccountsAction?.Invoke();
            else if (SelectedTab == ViewName.Categories)
                CategoriesAction?.Invoke();
            else if (SelectedTab == ViewName.Dashboard)
                DashboardAction?.Invoke();
            else if (SelectedTab == ViewName.Transactions)
                TransactionsAction?.Invoke();
        }
    }
}
