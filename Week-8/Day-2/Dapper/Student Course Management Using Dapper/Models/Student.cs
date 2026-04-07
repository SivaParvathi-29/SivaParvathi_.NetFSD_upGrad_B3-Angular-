namespace StudentCourseApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }

        public int CourseId { get; set; }
        public required Course Course { get; set; }
    }
}
