using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Croni.ViewModels
{
    public class TransactionsPageViewModel : ViewModelBase
    {
        public TransactionsPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
