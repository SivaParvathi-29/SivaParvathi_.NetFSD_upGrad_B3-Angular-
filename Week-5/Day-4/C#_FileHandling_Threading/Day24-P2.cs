using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter folder path:");
        string folderPath = Console.ReadLine();

        try
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid folder path!");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles();

            int count = 0;

            Console.WriteLine("\nFile Details:\n");

            foreach (FileInfo file in files)
            {
                Console.WriteLine("File Name     : " + file.Name);
                Console.WriteLine("File Size     : " + file.Length + " bytes");
                Console.WriteLine("Creation Date : " + file.CreationTime);
                Console.WriteLine("-------------------------------");
                count++;
            }

            Console.WriteLine("\nTotal Files: " + count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}