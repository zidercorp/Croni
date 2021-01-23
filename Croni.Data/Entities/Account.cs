using Croni.Common.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Croni.Data
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public AccountType AccountType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public decimal Balance { get; set; }

        public decimal CreditLimit { get; set; }

        public bool IncludeInTotalBalance { get; set; }
    }
}
