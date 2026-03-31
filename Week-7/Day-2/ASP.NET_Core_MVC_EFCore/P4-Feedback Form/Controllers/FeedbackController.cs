using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        [Route("feedback")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("feedback/submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You!";
            }
            else
            {
                ViewData["Message"] = "We will improve!";
            }

            return View("Index");
        }
    }
}
