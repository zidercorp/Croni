﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CroniUITemplates.ViewModels.ErrorAndEmpty
{
    /// <summary>
    /// ViewModel for payment failed page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentFailedPageViewModel : BaseViewModel
    {
        #region Fields

        private string imagePath;

        private string header;

        private string content;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="PaymentFailedPageViewModel" /> class.
        /// </summary>
        public PaymentFailedPageViewModel()
        {
            this.ImagePath = "PaymentFailed.svg";
            this.Header = "PAYMENT FAILED";
            this.Content = "An error occurred while processing your payment";
            this.TryAgainCommand = new Command(this.TryAgain);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Try again button is clicked.
        /// </summary>
        public ICommand TryAgainCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                this.header = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Try again button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void TryAgain(object obj)
        {
            // Do something
        }

        #endregion
    }
}
