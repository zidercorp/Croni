using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Data.Database
{
    public interface IDatabase
    {
        Task InitializeDatabase();
    }
}
