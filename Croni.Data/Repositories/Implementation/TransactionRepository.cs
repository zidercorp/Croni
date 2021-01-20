using Croni.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Lazy<IDatabaseConnection> lazyDBConnection) : base(lazyDBConnection)
        {

        }
    }
}
