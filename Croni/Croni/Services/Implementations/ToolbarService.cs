using Croni.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Services
{
    public class ToolbarService : BindableBase, IToolbarService
    {
        public Action AccountsAction { get; set; }
        public Action CategoriesAction { get; set; }
        public Action DashboardAction { get; set; }
        public Action TransactionsAction { get; set; }

        private ViewName _selectedTab;
        public ViewName SelectedTab
        {
            get => _selectedTab;
            set
            {
                SetProperty(ref _selectedTab, value, RaisePropertyChanged);
            }
        }

        private void RaisePropertyChanged()
        {
            SelectedTabChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SelectedTabChanged;

        public void ExecuteAction()
        {
            if (SelectedTab == ViewName.AccountsPage)
                AccountsAction?.Invoke();
            else if (SelectedTab == ViewName.CategoriesPage)
                CategoriesAction?.Invoke();
            else if (SelectedTab == ViewName.DashboardPage)
                DashboardAction?.Invoke();
            else if (SelectedTab == ViewName.TransactionsPage)
                TransactionsAction?.Invoke();
        }
    }
}
