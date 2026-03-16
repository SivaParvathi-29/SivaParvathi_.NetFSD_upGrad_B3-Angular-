using System;

class BankAccount
{
    // Private fields (Data Hiding)
    private int accountNumber;
    private double balance;

    // Property for Account Number
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    // Property for Balance (Read Only outside)
    public double Balance
    {
        get { return balance; }
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }

        balance = balance + amount;
        Console.WriteLine("Amount Deposited: " + amount);
        Console.WriteLine("Current Balance: " + balance);
    }

    // Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount.");
            return;
        }

        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        balance = balance - amount;
        Console.WriteLine("Amount Withdrawn: " + amount);
        Console.WriteLine("Current Balance: " + balance);
    }
}