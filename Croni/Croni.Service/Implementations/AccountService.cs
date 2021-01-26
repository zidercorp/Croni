using Croni.Data;
using Croni.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.Service
{
    public class AccountService : ServiceBase<Account>, IAccountService
    {
        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {

        }
    }
}
