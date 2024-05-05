using Account;

string userId = "12345678";
string debitAccountId = "12345678";
string debitAccountId2 = "02345679";
string creditAccountId = "12345654";


BankAccount debitAccount = new BankAccount(debitAccountId, userId, AccountType.Debit);
BankAccount debitAccount2 = debitAccount with { AccountId = debitAccountId2 };
BankAccount creditAccount = debitAccount with { AccountId = creditAccountId, AccountType = AccountType.Credit };

Console.WriteLine(debitAccount == debitAccount2);
Console.WriteLine(debitAccount == creditAccount);