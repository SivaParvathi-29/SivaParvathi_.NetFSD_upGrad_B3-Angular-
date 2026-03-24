using ConsoleApp2.Data;
using ProductApp.Models;
using System;

class Program
{
    static void Main()
    {
        ProductDAL dal = new ProductDAL();

        while (true)
        {
            Console.WriteLine("\n1.Insert\n2.View\n3.Update\n4.Delete\n5.Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product p = new Product();
                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();
                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();
                    Console.Write("Price: ");
                    p.Price = decimal.Parse(Console.ReadLine());

                    dal.InsertProduct(p);
                    Console.WriteLine("Inserted!");
                    break;

                case 2:
                    var list = dal.GetAllProducts();
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.ProductId} {item.ProductName} {item.Category} {item.Price}");
                    }
                    break;

                case 3:
                    Product u = new Product();
                    Console.Write("ID: ");
                    u.ProductId = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    u.ProductName = Console.ReadLine();
                    Console.Write("New Category: ");
                    u.Category = Console.ReadLine();
                    Console.Write("New Price: ");
                    u.Price = decimal.Parse(Console.ReadLine());

                    dal.UpdateProduct(u);
                    Console.WriteLine("Updated!");
                    break;

                case 4:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    dal.DeleteProduct(id);
                    Console.WriteLine("Deleted!");
                    break;

                case 5:
                    return;
            }
        }
    }
}