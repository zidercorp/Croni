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

namespace Croni.ViewModels
{
    public class AccountsPageViewModel : TabViewModelBase
    {
        #region Fields

        private readonly Lazy<IAccountService> _lazyAccountService;

        private IAccountService _accountService => _lazyAccountService.Value;

        #endregion

        #region Properties

        private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => SetProperty(ref _accounts, value);
        }

        private ObservableCollection<Account> _debts = new ObservableCollection<Account>();

        public event EventHandler IsActiveChanged;

        public ObservableCollection<Account> Debts
        {
            get => _debts;
            set => SetProperty(ref _debts, value);
        }

        #endregion

        public AccountsPageViewModel(INavigationService navigationService,
                                     Lazy<IAccountService> lazyAccountService,
                                     IToolbarService toolbarService) : base(navigationService)
        {
            _lazyAccountService = lazyAccountService;

            toolbarService.AccountsAction = AddAccount;
        }

        private void AddAccount()
        {
            var newAccount = new Account
            {
                Name = "BPI",
                Balance = 1000,
                AccountType = AccountType.Regular
            };

            _accountService.Insert(newAccount);

            Accounts.Add(newAccount);
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
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
