class Program
{
    static void Main()
    {
        Employee emp;

        // Manager object
        emp = new Manager();
        emp.Name = "Ravi";
        emp.BaseSalary = 50000;

        Console.WriteLine("Manager Name: " + emp.Name);
        Console.WriteLine("Final Salary: " + emp.CalculateSalary());

        Console.WriteLine();

        // Developer object
        emp = new Developer();
        emp.Name = "Sita";
        emp.BaseSalary = 40000;

        Console.WriteLine("Developer Name: " + emp.Name);
        Console.WriteLine("Final Salary: " + emp.CalculateSalary());
    }
}