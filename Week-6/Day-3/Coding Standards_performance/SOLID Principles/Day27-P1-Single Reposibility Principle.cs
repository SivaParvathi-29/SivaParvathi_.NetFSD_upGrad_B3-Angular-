using System;
using System.Collections.Generic;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int Marks { get; set; }
}

class StudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}

class ReportGenerator
{
    public void GenerateReport(List<Student> students)
    {
        Console.WriteLine("Student Report:");
        foreach (var s in students)
        {
            Console.WriteLine($"ID: {s.StudentId}, Name: {s.StudentName}, Marks: {s.Marks}");
        }
    }
}

class Program
{
    static void Main()
    {
        StudentRepository repo = new StudentRepository();
        repo.AddStudent(new Student { StudentId = 1, StudentName = "Siva", Marks = 85 });

        ReportGenerator report = new ReportGenerator();
        report.GenerateReport(repo.GetAllStudents());
    }
}