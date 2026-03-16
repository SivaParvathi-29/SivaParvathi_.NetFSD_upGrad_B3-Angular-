using System;

class BankAccount
{
    private string accountNumber;
    private double balance;

    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public double Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }

        Balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        Balance -= amount;
        Console.WriteLine("Withdrawn: " + amount);
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.AccountNumber = "12345";

        account.Deposit(5000);
        account.Withdraw(2000);

        Console.WriteLine("Current Balance = " + account.Balance);
    }
}