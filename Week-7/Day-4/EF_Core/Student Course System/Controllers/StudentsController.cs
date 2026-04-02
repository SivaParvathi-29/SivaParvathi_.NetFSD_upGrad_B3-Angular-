using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace StudentCourseMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.Course)
                .ToList();

            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student.CourseId == 0)
            {
                ViewBag.Courses = _context.Courses.ToList();
                return View(student); // prevent null course
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}