class Program
{
    static void Main()
    {
        Vehicle vehicle;

        // Car Rental
        vehicle = new Car();
        vehicle.Brand = "Toyota";
        vehicle.RentalRatePerDay = 2000;

        double carRental = vehicle.CalculateRental(3);

        Console.WriteLine("Vehicle: Car");
        Console.WriteLine("Total Rental = " + carRental);

        Console.WriteLine();

        // Bike Rental
        vehicle = new Bike();
        vehicle.Brand = "Yamaha";
        vehicle.RentalRatePerDay = 800;

        double bikeRental = vehicle.CalculateRental(3);

        Console.WriteLine("Vehicle: Bike");
        Console.WriteLine("Total Rental = " + bikeRental);
    }
}