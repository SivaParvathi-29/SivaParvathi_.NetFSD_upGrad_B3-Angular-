using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Course { get; set; }
}

interface IStudentRepository
{
    void AddStudent(Student student);
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    void DeleteStudent(int id);
}

class StudentRepository : IStudentRepository
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

    public Student GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.StudentId == id);
    }

    public void DeleteStudent(int id)
    {
        var student = GetStudentById(id);
        if (student != null)
            students.Remove(student);
    }
}

class Program
{
    static void Main()
    {
        IStudentRepository repo = new StudentRepository();

        repo.AddStudent(new Student { StudentId = 1, StudentName = "Siva", Course = "C#" });

        foreach (var s in repo.GetAllStudents())
        {
            Console.WriteLine(s.StudentName);
        }

        var student = repo.GetStudentById(1);
        Console.WriteLine("Found: " + student.StudentName);

        repo.DeleteStudent(1);
    }
}