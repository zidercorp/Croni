﻿using CroniUITemplates.DataService;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CroniUITemplates.Views.Bookmarks
{
    /// <summary>
    /// Page to show the wishlist. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishlistPage : ContentPage
    {
        public WishlistPage()
        {
            InitializeComponent();
            this.BindingContext = WishlistDataService.Instance.WishlistViewModel;
        }
    }
}