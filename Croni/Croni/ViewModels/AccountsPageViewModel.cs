using Croni.Data;
using Croni.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Croni.Common.Enums;
using Croni.Services;
using Prism;
using Croni.Views;
using System.Windows.Input;
using Croni.Data.Models;

namespace Croni.ViewModels
{
    public class AccountsPageViewModel : TabViewModelBase
    {
        #region Fields

        private readonly Lazy<IAccountService> _lazyAccountService;

        private IAccountService _accountService => _lazyAccountService.Value;
        private IToolbarService _toolbarService;

        #endregion

        #region Properties

        private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => SetProperty(ref _accounts, value);
        }

        private ObservableCollection<Account> _debts = new ObservableCollection<Account>();

        public ObservableCollection<Account> Debts
        {
            get => _debts;
            set => SetProperty(ref _debts, value);
        }

        private ObservableCollection<AccountTypeModel> _accountTypeModels = new ObservableCollection<AccountTypeModel>();

        public ObservableCollection<AccountTypeModel> AccountTypeModels
        {
            get => _accountTypeModels;
            set => SetProperty(ref _accountTypeModels, value);
        }

        private bool _popupOpen;

        public bool PopupOpen
        {
            get => _popupOpen;
            set => SetProperty(ref _popupOpen, value);
        }

        #endregion

        #region Commands

        public ICommand PopupOKCommand { get; }

        #endregion

        public AccountsPageViewModel(INavigationService navigationService,
                                     Lazy<IAccountService> lazyAccountService,
                                     IToolbarService toolbarService) : base(navigationService)
        {
            _lazyAccountService = lazyAccountService;
            _toolbarService = toolbarService;

            toolbarService.AccountsAction = AddAccount;

            PopupOKCommand = new DelegateCommand(OpenNewAccountPage);

            IsActiveChanged += AccountsPageViewModel_IsActiveChanged;
        }

        private async void OpenNewAccountPage()
        {
            var navigationParams = new NavigationParameters();
            await NavigationService.NavigateAsync(nameof(ViewName.NewAccountPage), navigationParams, true, true);
        }

        private void AccountsPageViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
                _toolbarService.SelectedTab = ViewName.AccountsPage;
        }

        private void AddAccount()
        {
            PopupOpen = true;
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var accounts = await _accountService.Get<Account>(account => account.AccountType == AccountType.Regular || 
                                                                         account.AccountType == AccountType.Savings);

            if (accounts != null)
                Accounts = new ObservableCollection<Account>(accounts);

            var debts = await _accountService.Get<Account>(account => account.AccountType == AccountType.Debt);

            if (accounts != null)
                Debts = new ObservableCollection<Account>(debts);

            var accountTypeList = new List<AccountTypeModel>
            {
                new AccountTypeModel
                {
                    Name = "Regular",
                    Description ="Cash, card, ...",
                    IsSelected = true
                },
                new AccountTypeModel
                {
                    Name = "Debt",
                    Description ="Credit, mortgage, ..."
                },
                new AccountTypeModel
                {
                    Name = "Savings",
                    Description = "Savings, goal, ..."
                }
            };

            AccountTypeModels = new ObservableCollection<AccountTypeModel>(accountTypeList);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
