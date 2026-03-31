using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        static List<string> products = new List<string>();

        [HttpGet]
        [Route("product")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        
        [HttpPost]
        [Route("product/add")]
        public IActionResult Add(string name, int price, int quantity)
        {
            // Check if input is empty or invalid
            if (string.IsNullOrWhiteSpace(name) || price <= 0 || quantity <= 0)
            {
                ViewBag.Products = products;
                ViewBag.Error = "Please enter valid product details!";
                return View("Index");
            }

            string product = name + " - " + price + " - " + quantity;
            products.Add(product);

            ViewBag.Products = products;
            return View("Index");
        }
    }
    
}
