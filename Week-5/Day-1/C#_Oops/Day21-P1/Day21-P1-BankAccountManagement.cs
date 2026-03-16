using System;

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.AccountNumber = 101;

        acc.Deposit(5000);
        acc.Withdraw(2000);

        Console.WriteLine("Final Balance = " + acc.Balance);
    }
}