using Croni.Data.Database;
using Croni.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Data.Database
{
    public class Database : RepositoryBase, IDatabase
    {
        #region Fields

        const int _databaseVersion = 1;

        #endregion

        #region Ctor

        public Database(Lazy<IDatabaseConnection> lazyDBConnection) : base(lazyDBConnection) { }

        #endregion

        #region Methods

        public async Task InitializeDatabase()
        {
            int currentDbVersion = await GetDatabaseVersion();

            if (currentDbVersion < _databaseVersion)
                await UpgradeDatabase();
            else
                await CreateTables();
        }

        private async Task<int> GetDatabaseVersion()
        {
            var databaseConnection = _dbConnection.GetAsyncConnection();
            return await AttemptAndRetry(() => databaseConnection.ExecuteScalarAsync<int>("PRAGMA user_version")).ConfigureAwait(false);
        }

        private async Task UpgradeDatabase()
        {
            //the first time ever we get this value after the database creation
            //this should be equals 0. but it's ok and will perform the correct
            //updates in the switch.
            int currentDbVersion = await GetDatabaseVersion();

            if (currentDbVersion < _databaseVersion)
            {
                await DeleteTables();
                await CreateTables();

                await SetDatabaseToVersion(_databaseVersion);
            }
        }

        private async Task<int> SetDatabaseToVersion(int version)
        {
            var databaseConnection = _dbConnection.GetAsyncConnection();

            return await AttemptAndRetry(() => databaseConnection.ExecuteAsync("PRAGMA user_version = " + version)).ConfigureAwait(false);
        }

        private async Task CreateTables()
        {
            var con = _dbConnection.GetAsyncConnection();

            await AttemptAndRetry(async () =>
            {
                await con.CreateTableAsync<Transaction>();

                await con.ExecuteAsync("PRAGMA foreign_keys = ON");
            });
        }

        public async Task DeleteTables()
        {
            var databaseConnection = _dbConnection.GetAsyncConnection();

            await AttemptAndRetry(async () =>
            {
                await databaseConnection.DropTableAsync<Transaction>();
            }).ConfigureAwait(false);

        }

        #endregion
    }
}
