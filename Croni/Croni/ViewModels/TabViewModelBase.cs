using Prism;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.ViewModels
{
    public class TabViewModelBase : ViewModelBase, IActiveAware
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public TabViewModelBase(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
