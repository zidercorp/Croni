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
        public DashboardPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
