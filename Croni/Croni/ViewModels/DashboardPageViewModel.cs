using Croni.Services;
using Croni.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Croni.ViewModels
{
    public class DashboardPageViewModel : TabViewModelBase
    {
        private readonly IToolbarService _toolbarService;
        public DashboardPageViewModel(INavigationService navigationService,
                                      IToolbarService toolbarService) : base(navigationService)
        {
            _toolbarService = toolbarService;

            IsActiveChanged += DashboardPageViewModel_IsActiveChanged;
        }

        private void DashboardPageViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                _toolbarService.SelectedTab = ViewName.Dashboard;
        }
    }
}
