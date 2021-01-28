﻿using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CroniUITemplates.Views.Templates
{
    /// <summary>
    /// Review template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingReviewTemplate : Grid
    {
        public BookingReviewTemplate()
        {
            InitializeComponent();
        }
    }
}