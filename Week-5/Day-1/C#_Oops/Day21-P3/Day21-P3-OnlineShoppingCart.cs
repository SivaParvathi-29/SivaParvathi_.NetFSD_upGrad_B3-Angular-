class Program
{
    static void Main()
    {
        Product product;

        // Electronics Product
        product = new Electronics();
        product.Name = "Laptop";
        product.Price = 20000;

        Console.WriteLine("Product: " + product.Name);
        Console.WriteLine("Original Price: " + product.Price);
        Console.WriteLine("Final Price after 5% discount = " + product.CalculateDiscount());

        Console.WriteLine();

        // Clothing Product
        product = new Clothing();
        product.Name = "T-Shirt";
        product.Price = 1000;

        Console.WriteLine("Product: " + product.Name);
        Console.WriteLine("Original Price: " + product.Price);
        Console.WriteLine("Final Price after 15% discount = " + product.CalculateDiscount());
    }
}