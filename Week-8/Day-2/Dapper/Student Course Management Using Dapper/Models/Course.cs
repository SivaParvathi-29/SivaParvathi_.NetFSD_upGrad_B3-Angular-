namespace StudentCourseApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string CourseName { get; set; }

        public required List<Student> Students { get; set; }
    }
}
