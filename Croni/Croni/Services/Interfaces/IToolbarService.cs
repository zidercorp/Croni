using Croni.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Services
{
    public interface IToolbarService
    {
        Action AccountsAction { get; set; }
        Action CategoriesAction { get; set; }
        Action DashboardAction { get; set; }
        Action TransactionsAction { get; set; }
        ViewName SelectedTab { get; set; }
        void ExecuteAction();
    }
}
