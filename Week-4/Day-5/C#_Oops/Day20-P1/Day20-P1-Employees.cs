using System;

class Program
{
    static void Main()
    {
        try
        {
            Employee emp = new Employee("Siva ", 4500m, 35);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);
            Console.WriteLine("Salary: " + emp.Salary);

            // Give raise
            emp.GiveRaise(10);

            // Deduct penalty
            bool result = emp.DeductPenalty(500);

            if (result)
                Console.WriteLine("Penalty applied successfully.");
            else
                Console.WriteLine("Penalty failed. Salary cannot go below 1000.");

            Console.WriteLine("Final Salary: " + emp.Salary);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}