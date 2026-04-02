using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            var students = _context.Students.ToList();

            ViewBag.Courses = courses;
            ViewBag.Students = students;

            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(string courseName)
        {
            var course = new Course { CourseName = courseName };
            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddStudent(string studentName, int age, int courseId)
        {
            var student = new Student
            {
                StudentName = studentName,
                Age = age,
                CourseId = courseId
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}