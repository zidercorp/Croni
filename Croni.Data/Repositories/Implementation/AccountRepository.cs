using Croni.Common.Enums;
using Croni.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(Lazy<IDatabaseConnection> lazyDatabaseConnection) : base(lazyDatabaseConnection)
        {

        }
    }
}
