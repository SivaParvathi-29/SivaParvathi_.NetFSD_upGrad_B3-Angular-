using System;

class Student
{***********
    public double CalculateAverage(int m1, int m2, int m3)
    {
        double avg = (m1 + m2 + m3) / 3.0;
        return avg;
    }
}

class Program
{
    static void Main()
    {
        int m1, m2, m3;

        Console.Write("Enter marks 1: ");
        m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks 2: ");
        m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks 3: ");
        m3 = Convert.ToInt32(Console.ReadLine());

        Student s = new Student();

        double average = s.CalculateAverage(m1, m2, m3);

        string grade;

        if (average >= 80)
            grade = "A";
        else if (average >= 60)
            grade = "B";
        else if (average >= 50)
            grade = "C";
        else
            grade = "D";

        Console.WriteLine("Average = " + average);
        Console.WriteLine("Grade = " + grade);
    }
}