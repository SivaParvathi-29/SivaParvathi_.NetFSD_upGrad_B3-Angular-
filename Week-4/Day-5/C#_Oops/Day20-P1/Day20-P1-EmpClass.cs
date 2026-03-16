using System;

public class Employee
{
    // Private Fields (Data Hiding)
    private string fullName;
    private int age;
    private decimal salary;
    private readonly string employeeId;

    // FullName Property
    public string FullName
    {
        get => fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty.");

            fullName = value.Trim();
        }
    }

    // Age Property
    public int Age
    {
        get => age;
        set
        {
            if (value < 18 || value > 80)
                throw new ArgumentException("Age must be between 18 and 80.");

            age = value;
        }
    }

    // Salary Property (Private Set)
    public decimal Salary
    {
        get => salary;
        private set
        {
            if (value < 1000)
                throw new ArgumentException("Salary cannot be less than 1000.");

            salary = value;
        }
    }

    // Readonly Employee ID
    public string EmployeeId => employeeId;

    // Constructor
    public Employee(string name, decimal startingSalary, int age)
    {
        employeeId = "E" + Guid.NewGuid().ToString().Substring(0, 5);

        FullName = name;
        Salary = startingSalary;
        Age = age;
    }

    // Give Raise Method
    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0 || percentage > 30)
            throw new ArgumentException("Raise percentage must be between 0 and 30.");

        Salary = Salary * (1 + percentage / 100);

        Console.WriteLine($"Salary increased successfully. New Salary: {Salary}");
    }

    // Deduct Penalty Method
    public bool DeductPenalty(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Penalty amount must be greater than zero.");

        if (Salary - amount < 1000)
            return false;

        Salary -= amount;
        return true;
    }
}