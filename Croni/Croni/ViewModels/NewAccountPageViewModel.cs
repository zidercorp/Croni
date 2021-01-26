using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Croni.ViewModels
{
    public class NewAccountPageViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public NewAccountPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CloseCommand = new DelegateCommand(CloseExecute);
        }

        private void CloseExecute()
        {
            var navParam = new NavigationParameters();
            navParam.Add("YES", "TEDSD");

            NavigationService.GoBackAsync(navParam, useModalNavigation: true, true);
        }
    }
}
