﻿using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CroniUITemplates.Views.Profile
{
    /// <summary>
    /// Page to show article master page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterPage" /> class.
        /// </summary>
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}