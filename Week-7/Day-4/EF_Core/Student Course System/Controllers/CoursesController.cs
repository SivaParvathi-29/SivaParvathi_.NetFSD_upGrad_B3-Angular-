using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;

public class CoursesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var courses = _context.Courses.ToList(); // ✅ fetch data
        return View(courses);                    // ✅ pass to view
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }
}