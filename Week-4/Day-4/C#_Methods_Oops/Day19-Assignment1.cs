using System;

class Product
{
    private int productId;
    private string productName;
    private double unitPrice;
    private int qty;

    public Product(int productId)
    {
        this.productId = productId;
    }

    public int ProductId
    {
        get { return productId; }
    }

    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    public double UnitPrice
    {
        get { return unitPrice; }
        set { unitPrice = value; }
    }

    public int Quantity
    {
        get { return qty; }
        set { qty = value; }
    }

    public void ShowDetails()
    {
        double total = unitPrice * qty;

        Console.WriteLine("Product ID: " + ProductId);
        Console.WriteLine("Product Name: " + ProductName);
        Console.WriteLine("Unit Price: " + UnitPrice);
        Console.WriteLine("Quantity: " + Quantity);
        Console.WriteLine("Total Amount: " + total);
    }
}

class Program
{
    static void Main()
    {
        Product p = new Product(101);

        p.ProductName = "Laptop";
        p.UnitPrice = 50000;
        p.Quantity = 2;

        p.ShowDetails();
    }
}