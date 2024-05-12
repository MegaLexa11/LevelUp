using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    // Guid, наверно, не очень подходят для обозначения id счета и id владельца, так как тут это условно и вместо них, скорее всего подразумеваются номер счета и, допустим, паспортные данные, поэтому тут string
    internal sealed record BankAccount (string AccountId, string OwnerId, AccountType AccountType)
    {
        public bool Equals(BankAccount other)
        {
            return this.OwnerId == other.OwnerId && this.AccountType == other.AccountType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.OwnerId, this.AccountType);
        }
    }
}
