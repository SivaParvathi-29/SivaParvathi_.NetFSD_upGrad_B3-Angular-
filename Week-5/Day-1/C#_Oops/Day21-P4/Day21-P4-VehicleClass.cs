using System;

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

    // Virtual method
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

class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total + 500; // insurance charge
    }
}

class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total - (total * 0.05);
    }
}

