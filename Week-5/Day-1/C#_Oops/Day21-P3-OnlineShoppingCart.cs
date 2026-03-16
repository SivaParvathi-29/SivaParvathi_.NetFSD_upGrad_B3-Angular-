using System;

class Product
{
    private double price;   

    public string Name { get; set; }

    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }
            price = value;
        }
    }

    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05); 
    }
}

class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15); 
    }
}


class Program
{
    static void Main()
    {
        Product product;

        product = new Electronics();
        product.Name = "Laptop";
        product.Price = 20000;

        Console.WriteLine("Product: " + product.Name);
        Console.WriteLine("Original Price: " + product.Price);
        Console.WriteLine("Final Price after 5% discount = " + product.CalculateDiscount());

        Console.WriteLine();

        product = new Clothing();
        product.Name = "T-Shirt";
        product.Price = 1000;

        Console.WriteLine("Product: " + product.Name);
        Console.WriteLine("Original Price: " + product.Price);
        Console.WriteLine("Final Price after 15% discount = " + product.CalculateDiscount());
    }
}