using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "log.txt";

        try
        {
            Console.WriteLine("Enter your message:");
            string message = Console.ReadLine();

            byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }

            Console.WriteLine("Message written successfully to file!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
}