using Dapper;
using StudentCourseApp.Data;
using StudentCourseApp.Models;
namespace StudentCourseApp.Repositories
{
    public class StudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        // Get Students with Course
        public async Task<List<Student>> GetStudentsWithCourse()
        {
            var query = @"SELECT s.StudentId, s.StudentName, 
                             c.CourseId, c.CourseName
                      FROM Students s
                      INNER JOIN Courses c ON s.CourseId = c.CourseId";

            using var connection = _context.CreateConnection();

            var result = await connection.QueryAsync<Student, Course, Student>(
                query,
                (student, course) =>
                {
                    student.Course = course;
                    return student;
                },
                splitOn: "CourseId"
            );

            return result.ToList();
        }

        // Get Courses with Students
        public async Task<List<Course>> GetCoursesWithStudents()
        {
            var query = @"SELECT c.CourseId, c.CourseName,
                             s.StudentId, s.StudentName, s.CourseId
                      FROM Courses c
                      LEFT JOIN Students s ON c.CourseId = s.CourseId";

            using var connection = _context.CreateConnection();

            var courseDict = new Dictionary<int, Course>();

            var result = await connection.QueryAsync<Course, Student, Course>(
                query,
                (course, student) =>
                {
                    if (!courseDict.TryGetValue(course.CourseId, out var currentCourse))
                    {
                        currentCourse = course;
                        currentCourse.Students = new List<Student>();
                        courseDict.Add(currentCourse.CourseId, currentCourse);
                    }

                    if (student != null && student.StudentId != 0)
                        currentCourse.Students.Add(student);

                    return currentCourse;
                },
                splitOn: "StudentId"
            );

            return courseDict.Values.ToList();
        }
    }
}
