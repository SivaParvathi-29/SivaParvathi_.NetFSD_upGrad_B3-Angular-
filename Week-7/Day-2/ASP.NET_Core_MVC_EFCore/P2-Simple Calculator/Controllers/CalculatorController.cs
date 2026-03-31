using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        [Route("calc")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("calc/add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;

            return View("Index");
        }
    }
}
