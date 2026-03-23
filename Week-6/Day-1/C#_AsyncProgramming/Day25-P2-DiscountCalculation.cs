using System;

namespace DiscountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount (%): ");
            double discount = Convert.ToDouble(Console.ReadLine());

            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("Product: " + name);
            Console.WriteLine("Final Price: " + finalPrice);

            Console.ReadLine();
        }
    }
}