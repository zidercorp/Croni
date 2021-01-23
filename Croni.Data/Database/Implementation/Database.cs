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
            _dbConnection.CreateDatabase();

            await CreateTables();

            int currentDbVersion = await GetDatabaseVersion();

            if (currentDbVersion < _databaseVersion)
                await UpgradeDatabase();
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
                //we have to ignore the current database updates, so start from the next
                int startUpgradingFrom = currentDbVersion + 1;
                //if we are are, database upgrade is needed
                switch (startUpgradingFrom)
                {
                    case 1: //starting version
                        InitializeData();
                        goto case 2;
                    case 2:
                        UpgradeFrom1To2();
                        goto case 3;
                    case 3:
                        UpgradeFrom2To3();
                        goto case 4;
                    case 4: //ecc.. ecc..
                        break;
                    default:
                        //if we are here something with the update went wrong,
                        //deleting and recreating the database is the only
                        //possible action to perform
                        throw new Exception("something went really wrong");
                }

                await SetDatabaseToVersion(_databaseVersion);
            }
        }

        private void InitializeData()
        {
            
        }

        private static void UpgradeFrom1To2() { }

        private static void UpgradeFrom2To3() { }

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
                await con.CreateTableAsync<Account>();

                await con.ExecuteAsync("PRAGMA foreign_keys = ON");
            }).ConfigureAwait(false);
        }

        public async Task DeleteTables()
        {
            var databaseConnection = _dbConnection.GetAsyncConnection();

            await AttemptAndRetry(async () =>
            {
                await databaseConnection.DropTableAsync<Transaction>();
                await databaseConnection.DropTableAsync<Account>();
            }).ConfigureAwait(false);
        }

        #endregion
    }
}
