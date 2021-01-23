using Croni.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Croni.ViewModels
{
    public class CategoriesPageViewModel : TabViewModelBase
    {
        public CategoriesPageViewModel(INavigationService navigationService,
                                       IToolbarService toolbarService) : base(navigationService)
        {
            toolbarService.CategoriesAction = EditCategories;
        }

        private void EditCategories()
        {

        }
    }
}
