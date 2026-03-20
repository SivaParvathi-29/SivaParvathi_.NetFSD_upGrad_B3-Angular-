using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("\n--- Drive Information ---\n");

            foreach (DriveInfo drive in drives)
            {
                if (!drive.IsReady)
                {
                    Console.WriteLine($"Drive {drive.Name} is not ready.");
                    Console.WriteLine("---------------------------");
                    continue;
                }

                double freePercent = (drive.AvailableFreeSpace * 100.0) / drive.TotalSize;

                Console.WriteLine($"Drive Name   : {drive.Name}");
                Console.WriteLine($"Drive Type   : {drive.DriveType}");
                Console.WriteLine($"Total Size   : {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"Free Space   : {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");

                if (freePercent < 15)
                {
                    Console.WriteLine("⚠ WARNING: Low Disk Space!");
                }

                Console.WriteLine("---------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}