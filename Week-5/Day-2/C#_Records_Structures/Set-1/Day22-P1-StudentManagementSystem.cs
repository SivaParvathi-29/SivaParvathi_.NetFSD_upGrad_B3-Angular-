using System;

record Student(int RollNo, string Name, string Course, int Marks);

class Program
{
    static void Main()
    {
        Student[] students;
        int count = 0;

        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        students = new Student[n];

        while (true)
        {
            Console.WriteLine("\n---- Student Record Management ----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (count < n)
                    {
                        Console.Write("Enter Roll Number: ");
                        int roll = int.Parse(Console.ReadLine());

                        if (roll <= 0)
                        {
                            Console.WriteLine("Invalid Roll Number.");
                            break;
                        }

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        int marks = int.Parse(Console.ReadLine());

                        if (marks < 0 || marks > 100)
                        {
                            Console.WriteLine("Marks should be between 0 and 100.");
                            break;
                        }

                        students[count] = new Student(roll, name, course, marks);
                        count++;

                        Console.WriteLine("Student Record Added Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student list is full.");
                    }
                    break;

                case 2:
                    Console.WriteLine("\nStudent Records:");
                    if (count == 0)
                    {
                        Console.WriteLine("No records available.");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Roll No: {students[i].RollNo} | Name: {students[i].Name} | Course: {students[i].Course} | Marks: {students[i].Marks}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Roll Number to search: ");
                    int searchRoll = int.Parse(Console.ReadLine());
                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].RollNo == searchRoll)
                        {
                            Console.WriteLine("\nStudent Found:");
                            Console.WriteLine($"Roll No: {students[i].RollNo} | Name: {students[i].Name} | Course: {students[i].Course} | Marks: {students[i].Marks}");
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Record not found.");
                    }
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}