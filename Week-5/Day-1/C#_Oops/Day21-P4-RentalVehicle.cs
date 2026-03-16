using System;

// Base Class
class Vehicle
{
    private double rentalRatePerDay;

    public string Brand { get; set; }

    public double RentalRatePerDay
    {
        get { return rentalRatePerDay; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Rental rate cannot be negative.");
                return;
            }
            rentalRatePerDay = value;
        }
    }

    public virtual double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days.");
            return 0;
        }

        return RentalRatePerDay * days;
    }
}

// Derived Class Car
class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total + 500;
    }
}

// Derived Class Bike
class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total - (total * 0.05);
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Vehicle vehicle;

        vehicle = new Car();
        vehicle.Brand = "Toyota";
        vehicle.RentalRatePerDay = 2000;

        Console.WriteLine("Car Rental = " + vehicle.CalculateRental(3));

        vehicle = new Bike();
        vehicle.Brand = "Yamaha";
        vehicle.RentalRatePerDay = 800;

        Console.WriteLine("Bike Rental = " + vehicle.CalculateRental(3));
    }
}