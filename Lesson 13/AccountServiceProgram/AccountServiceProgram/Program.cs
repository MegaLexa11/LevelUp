using AccountServiceProgram;

AccountService accountService = new AccountService();
BankAccount bankAccount = accountService.CreateAccount("John Cena", "Debit");
BankAccount bankAccount2 = accountService.CreateAccount("Mike Vazowsky", "Debit");