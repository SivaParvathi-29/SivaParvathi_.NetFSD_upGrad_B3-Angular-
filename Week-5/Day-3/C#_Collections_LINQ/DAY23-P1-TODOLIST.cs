using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> tasks = new List<string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nTo-Do List Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask(tasks);
                    break;

                case "2":
                    ViewTasks(tasks);
                    break;

                case "3":
                    RemoveTask(tasks);
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddTask(List<string> tasks)
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added!");
        }
        else
        {
            Console.WriteLine("Task cannot be empty.");
        }
    }

    static void ViewTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        Console.Write("Enter task number to remove: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int index))
        {
            if (index >= 1 && index <= tasks.Count)
            {
                string removedTask = tasks[index - 1];
                tasks.RemoveAt(index - 1);
                Console.WriteLine($"Removed: {removedTask}");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
}