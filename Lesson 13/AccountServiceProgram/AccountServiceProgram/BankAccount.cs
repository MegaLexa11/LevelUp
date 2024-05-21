using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServiceProgram
{
    internal class BankAccount
    {
        public Guid Id { get; }
        public string OwnerName { get; }
        public string AccountType { get; }

        public BankAccount(string ownerName, string accountType)
        {
            Id = new Guid();
            OwnerName = ownerName;
            AccountType = accountType;
        }
    }
}
