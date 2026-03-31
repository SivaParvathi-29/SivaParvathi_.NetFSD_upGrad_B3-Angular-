using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Show Form
        [HttpGet]
        [Route("student/form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST: Handle Form
        [HttpPost]
        [Route("student/submit")]
        public IActionResult Submit(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View("Display");
        }

        // Display Data
        [HttpGet]
        [Route("student/display")]
        public IActionResult Display()
        {
            return View();
        }
    }
}
