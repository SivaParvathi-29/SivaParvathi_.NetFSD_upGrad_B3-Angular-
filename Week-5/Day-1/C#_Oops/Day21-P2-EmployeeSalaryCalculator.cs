using System;

class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20); 
    }
}

class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10); 
    }
}

class Program
{
    static void Main()
    {
        Employee emp;

        emp = new Manager();
        emp.Name = "Manager";
        emp.BaseSalary = 50000;

        Console.WriteLine("Manager Salary = " + emp.CalculateSalary());

        
        emp = new Developer();
        emp.Name = "Developer";
        emp.BaseSalary = 50000;

        Console.WriteLine("Developer Salary = " + emp.CalculateSalary());
    }
}