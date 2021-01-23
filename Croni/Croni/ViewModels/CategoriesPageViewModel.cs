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
    public class CategoriesPageViewModel : TabViewModelBase
    {
        private readonly IToolbarService _toolbarService;
        public CategoriesPageViewModel(INavigationService navigationService,
                                       IToolbarService toolbarService) : base(navigationService)
        {
            _toolbarService = toolbarService;
            toolbarService.CategoriesAction = EditCategories;

            IsActiveChanged += CategoriesPageViewModel_IsActiveChanged;
        }

        private void CategoriesPageViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                _toolbarService.SelectedTab = ViewName.Categories;
        }

        private void EditCategories()
        {

        }
    }
}
