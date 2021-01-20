using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Croni.ViewModels
{
    public class CategoriesPageViewModel : ViewModelBase
    {
        public CategoriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
