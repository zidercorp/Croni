using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.Data.Database
{
    public interface IDatabaseConnection
    {
        SQLiteAsyncConnection GetAsyncConnection();
        void CreateDatabase();
    }
}
