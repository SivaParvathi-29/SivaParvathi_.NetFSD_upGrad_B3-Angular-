using System.Text.Json.Serialization;

namespace WebApplication4.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int Age { get; set; }

        public int CourseId { get; set; }

        [JsonIgnore]   // VERY IMPORTANT
        public Course? Course { get; set; }
    }
}