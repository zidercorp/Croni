using Croni.Common.Fonts;
using Croni.Services;
using Croni.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Croni.ViewModels
{
    public class HomeTabbedPageViewModel : ViewModelBase
    {
        private readonly IToolbarService _toolbarService;
        public ICommand ActionCommand { get; }

        private ViewName _selectedTab;

        public ViewName SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        public HomeTabbedPageViewModel(INavigationService navigationService,
                                       IToolbarService toolbarService) : base(navigationService)
        {
            _toolbarService = toolbarService;

            _toolbarService.SelectedTabChanged += _toolbarService_SelectedTabChanged;
            ActionCommand = new DelegateCommand(ExecuteAction);
        }

        private void _toolbarService_SelectedTabChanged(object sender, EventArgs e)
        {
            SelectedTab = _toolbarService.SelectedTab;
        }

        private void ExecuteAction()
        {
            _toolbarService.ExecuteAction();
        }
    }
}
