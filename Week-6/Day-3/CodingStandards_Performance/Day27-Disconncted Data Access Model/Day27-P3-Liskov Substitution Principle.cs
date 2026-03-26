using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void PrintArea(Shape shape)
    {
        Console.WriteLine("Area: " + shape.CalculateArea());
    }

    static void Main()
    {
        Shape rect = new Rectangle { Length = 5, Width = 4 };
        Shape circle = new Circle { Radius = 3 };

        PrintArea(rect);
        PrintArea(circle);
    }
}