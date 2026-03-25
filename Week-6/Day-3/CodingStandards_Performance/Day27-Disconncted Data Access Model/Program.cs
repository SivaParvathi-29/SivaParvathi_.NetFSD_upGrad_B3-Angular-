using System;
using System.Data;

class Program
{
    static void Main()
    {
        ProductDAL dal = new ProductDAL();

        while (true)
        {
            Console.WriteLine("\n1.Insert 2.View 3.Update 4.Delete 5.Exit");
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
                    Console.WriteLine("Inserted Successfully");
                    break;

                case 2:
                    DataTable dt = dal.GetAllProducts();
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["ProductId"]} {row["ProductName"]} {row["Category"]} {row["Price"]}");
                    }
                    break;

                case 3:
                    Product up = new Product();
                    Console.Write("Enter ID: ");
                    up.ProductId = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    up.ProductName = Console.ReadLine();
                    Console.Write("New Category: ");
                    up.Category = Console.ReadLine();
                    Console.Write("New Price: ");
                    up.Price = decimal.Parse(Console.ReadLine());

                    dal.UpdateProduct(up);
                    Console.WriteLine("Updated Successfully");
                    break;

                case 4:
                    Console.Write("Enter ID to Delete: ");
                    int id = int.Parse(Console.ReadLine());
                    dal.DeleteProduct(id);
                    Console.WriteLine("Deleted Successfully");
                    break;

                case 5:
                    return;
            }
        }
    }
}