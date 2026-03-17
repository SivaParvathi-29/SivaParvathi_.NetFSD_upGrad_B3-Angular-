using System;

// Custom Exception Class
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

// BankAccount Class
class BankAccount
{
    private double balance;

    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
        }

        balance -= amount;
        Console.WriteLine("Withdrawal Successful. Remaining Balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Balance: ");
        double balance = double.Parse(Console.ReadLine());

        Console.Write("Enter Withdraw Amount: ");
        double withdrawAmount = double.Parse(Console.ReadLine());

        BankAccount account = new BankAccount(balance);

        try
        {
            account.Withdraw(withdrawAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction completed.");
        }
    }
}