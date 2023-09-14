using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SimpleTaskManager;

class Program
{
    static TaskManager manager = new TaskManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSimple Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Filter Tasks By Category");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddNewTask();
                        break;
                    case 2:
                        manager.ViewAllTasks();
                        break;
                    case 3:
                        FilterTasks();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please choose a valid option.");
                        break;
                }
            }
        }
    }

    static void AddNewTask()
    {
        Console.WriteLine("Enter Task Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Task Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter Task Category (Personal, Work, Errands):");
        string categoryInput = Console.ReadLine();

        if (Enum.TryParse(categoryInput, out TaskCategory category))
        {
            var task = new SimpleTask
            {
                Name = name,
                Description = description,
                Category = category,
                IsCompleted = false
            };
            manager.AddTask(task);
        }
        else
        {
            Console.WriteLine("Invalid category entered!");
        }
    }

    static void FilterTasks()
    {
        Console.WriteLine("Enter Category to filter by (Personal, Work, Errands):");
        string categoryInput = Console.ReadLine();

        if (Enum.TryParse(categoryInput, out TaskCategory category))
        {
            var tasks = manager.FilterByCategory(category);
            foreach (var task in tasks)
            {
                Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
            }
        }
        else
        {
            Console.WriteLine("Invalid category entered!");
        }
    }
}

