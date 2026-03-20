using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Monthly Sales Amount: ");
        double sales = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Customer Rating (1-5): ");
        int rating = Convert.ToInt32(Console.ReadLine());

        var result = GetPerformanceData(sales, rating);

        string performance = result switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        Console.WriteLine("\n--- Employee Performance ---");
        Console.WriteLine("Employee Name : " + name);
        Console.WriteLine("Sales Amount  : " + result.sales);
        Console.WriteLine("Rating        : " + result.rating);
        Console.WriteLine("Performance   : " + performance);
    }

    static (double sales, int rating) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }
}