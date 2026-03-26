using System;

interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}

class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.05;
}

class PremiumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.10;
}

class VipCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.20;
}

class DiscountCalculator
{
    public double GetFinalPrice(double amount, IDiscountStrategy strategy)
    {
        return amount - strategy.CalculateDiscount(amount);
    }
}

class Program
{
    static void Main()
    {
        DiscountCalculator calc = new DiscountCalculator();

        double final = calc.GetFinalPrice(1000, new PremiumCustomerDiscount());
        Console.WriteLine("Final Price: " + final);
    }
}