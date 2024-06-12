namespace AccountServiceProgram
{
    internal class AccountService
    {
        private PrintCreationInfo _userNotification;

        public AccountService()
        {
            _userNotification = new PrintCreationInfo(CheckBlacklist);
            _userNotification += CheckAccountType;
            _userNotification += RegisterAccount;
            _userNotification += NotifyUser;
        }

        public BankAccount CreateAccount(string ownerName, string accountType)
        {
            _userNotification.Invoke(ownerName, accountType);
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
