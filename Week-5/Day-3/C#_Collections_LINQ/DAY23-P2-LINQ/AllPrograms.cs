using System;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class AllProblems
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // 1. FMCG
            Console.WriteLine("1. FMCG Products:");
            var p1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in p1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 2. Grain
            Console.WriteLine("\n2. Grain Products:");
            var p2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in p2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            // 3. Sort by Code
            Console.WriteLine("\n3. Sort by Product Code:");
            var p3 = products.OrderBy(p => p.ProCode);
            foreach (var item in p3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");

            // 4. Sort by Category
            Console.WriteLine("\n4. Sort by Category:");
            var p4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in p4)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");

            // 5. Sort by MRP Asc
            Console.WriteLine("\n5. Sort by MRP Asc:");
            var p5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in p5)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 6. Sort by MRP Desc
            Console.WriteLine("\n6. Sort by MRP Desc:");
            var p6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in p6)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            // 7. Group by Category
            Console.WriteLine("\n7. Group by Category:");
            var p7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in p7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine($"{item.ProName} - {item.ProMrp}");
            }

            // 8. Group by MRP
            Console.WriteLine("\n8. Group by MRP:");
            var p8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in p8)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine(item.ProName);
            }

            // 9. Highest price in FMCG
            Console.WriteLine("\n9. Highest FMCG Product:");
            var p9 = products
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .FirstOrDefault();
            Console.WriteLine($"{p9.ProName} - {p9.ProMrp}");

            // 10. Total count
            Console.WriteLine("\n10. Total Products:");
            Console.WriteLine(products.Count());

            // 11. FMCG count
            Console.WriteLine("\n11. FMCG Count:");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            // 12. Max price
            Console.WriteLine("\n12. Max Price:");
            Console.WriteLine(products.Max(p => p.ProMrp));

            // 13. Min price
            Console.WriteLine("\n13. Min Price:");
            Console.WriteLine(products.Min(p => p.ProMrp));

            // 14. All below 30
            Console.WriteLine("\n14. All products below 30?");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            // 15. Any below 30
            Console.WriteLine("\n15. Any product below 30?");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}