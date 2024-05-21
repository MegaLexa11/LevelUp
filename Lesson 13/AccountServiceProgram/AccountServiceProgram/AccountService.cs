using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServiceProgram
{
    internal class AccountService
    {
        public BankAccount CreateAccount(string ownerName, string accountType)
        {
            PrintCreationInfo userNotification = new PrintCreationInfo(CheckBlacklist);
            userNotification += new PrintCreationInfo(CheckAccountType);
            
            BankAccount account = new BankAccount(ownerName, accountType);

            userNotification += new PrintCreationInfo(RegisterAccount);
            userNotification += new PrintCreationInfo(NotifyUser);

            userNotification(ownerName, accountType);

            return new BankAccount(ownerName, accountType);
        }

        private void CheckBlacklist(string ownerName, string accountType) 
        {
            // Some actions
            Console.WriteLine("The user is not in blacklist.");
        }

        private void CheckAccountType(string ownerName, string accountType)
        {
            // Some actions
            Console.WriteLine("The type of the new account is unique.");
        }

        private void RegisterAccount(string ownerName, string accountType)
        {
            // Some actions
            Console.WriteLine("Account registration successful.");
        }

        private void NotifyUser(string ownerName, string accountType)
        {
            // Some actions
            Console.WriteLine("Sending notification on user's email.");
        }

        private delegate void PrintCreationInfo(string ownerName, string accountType);
    }
}
