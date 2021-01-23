using Croni.Services;
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

        private ContentPage _selectedPage;
        public ContentPage SelectedPage
        {
            get => _selectedPage;
            set
            {
                SetProperty(ref _selectedPage, value);
            }
        }

        public HomeTabbedPageViewModel(INavigationService navigationService,
                                       IToolbarService toolbarService) : base(navigationService)
        {
            _toolbarService = toolbarService;
            ActionCommand = new DelegateCommand(ExecuteAction);
        }

        private void ExecuteAction()
        {
            _toolbarService.ExecuteAction();
        }
    }
}
