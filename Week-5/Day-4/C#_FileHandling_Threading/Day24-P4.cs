using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter root directory path: ");
        string path = Console.ReadLine();

        try
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            DirectoryInfo root = new DirectoryInfo(path);

            Console.WriteLine("\n--- Subdirectories and File Count ---\n");

            DirectoryInfo[] directories = root.GetDirectories();

            foreach (DirectoryInfo dir in directories)
            {
                FileInfo[] files = dir.GetFiles();
                int fileCount = files.Length;

                Console.WriteLine("Folder Name : " + dir.Name);
                Console.WriteLine("File Count  : " + fileCount);
                Console.WriteLine("-------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}