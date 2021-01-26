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
    public class TransactionsPageViewModel : TabViewModelBase
    {
        private readonly IToolbarService _toolbarService;
        public TransactionsPageViewModel(INavigationService navigationService,
                                         IToolbarService toolbarService) : base(navigationService)
        {
            _toolbarService = toolbarService;

            IsActiveChanged += TransactionsPageViewModel_IsActiveChanged;
        }

        private void TransactionsPageViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                _toolbarService.SelectedTab = ViewName.TransactionsPage;
        }
    }
}
