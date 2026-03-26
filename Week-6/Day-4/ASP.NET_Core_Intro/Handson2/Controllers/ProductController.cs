using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

public class ProductController : Controller
{
    private List<Product> products = new List<Product>()
    {
        new Product { Id = 1, Name = "Laptop", Price = 50000 },
        new Product { Id = 2, Name = "Mobile", Price = 20000 },
        new Product { Id = 3, Name = "Tablet", Price = 30000 }
    };

    public IActionResult Index()
    {
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        return View(product);
    }
}