using Nito.AsyncEx;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Croni.Data.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        #region Fields

        private string _dbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "croni.db3");
        private Lazy<SQLiteAsyncConnection> _lazySQLiteConnetion;
        private SQLiteAsyncConnection _dbConnection => _lazySQLiteConnetion?.Value;
        private static readonly AsyncLock _mutex = new AsyncLock();

        #endregion

        #region Methods

        public void CreateDatabase()
        {
            var connectionString = new SQLiteConnectionString(_dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache, true);
            _lazySQLiteConnetion = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(connectionString));
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return _dbConnection;
        }

        #endregion
    }
}
