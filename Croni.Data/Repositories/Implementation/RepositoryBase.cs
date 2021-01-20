using Croni.Data.Database;
using Polly;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Data.Repositories
{
    public class RepositoryBase
    {
        private Lazy<IDatabaseConnection> _lazyDBConnection;

        protected IDatabaseConnection _dbConnection => _lazyDBConnection.Value;

        public RepositoryBase(Lazy<IDatabaseConnection> lazyDBConnection)
        {
            _lazyDBConnection = lazyDBConnection;
        }

        protected static Task<T> AttemptAndRetry<T>(Func<Task<T>> action, int numRetries = 3)
        {
            return Policy.Handle<SQLiteException>().WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action);
        }

        protected static Task AttemptAndRetry(Func<Task> action, int numRetries = 3)
        {
            return Policy.Handle<SQLiteException>().WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action);     
        }

        static TimeSpan pollyRetryAttempt(int attemptNumber) => TimeSpan.FromMilliseconds(Math.Pow(2, attemptNumber));
    }
}
