using System;
using System.Diagnostics;

namespace TracingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;

            Trace.TraceInformation("Order Processing Started");

            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order Processing Completed");

            Console.WriteLine("Check log.txt for trace output");
            Console.ReadLine();
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Validating Order...");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Processing Payment...");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Updating Inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Generating Invoice...");
        }
    }
}