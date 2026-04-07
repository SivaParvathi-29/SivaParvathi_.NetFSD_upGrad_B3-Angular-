
using StudentCourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using StudentCourseApp.Repositories;

namespace StudentCourseApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> StudentsWithCourse()
        {
            var data = await _repo.GetStudentsWithCourse();
            return View(data);
        }

        public async Task<IActionResult> CoursesWithStudents()
        {
            var data = await _repo.GetCoursesWithStudents();
            return View(data);
        }
    }
}
