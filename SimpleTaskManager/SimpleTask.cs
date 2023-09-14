using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleTaskManager
{
    public enum TaskCategory
    {
        Personal,
        Work,
        Errands
    }

    public class SimpleTask
    {
        public string Name, Description;
        public bool IsCompleted;
        public TaskCategory Category;
    }

    public class TaskManager
    {
        private List<SimpleTask> tasks;
        private const string FILE_NAME = "tasks.csv";

        public TaskManager()
        {
            tasks = new List<SimpleTask>();
            LoadTasks().Wait();
        }

        public async Task LoadTasks()
        {
            if (!File.Exists(FILE_NAME))
                return;

            var lines = await File.ReadAllLinesAsync(FILE_NAME);
            foreach (var line in lines)
            {
                var data = line.Split(",");
                var task = new SimpleTask
                {
                    Name = data[0],
                    Description = data[1],
                    Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), data[2]),
                    IsCompleted = bool.Parse(data[3])
                };
                tasks.Add(task);
            }
        }

        public void AddTask(SimpleTask task)
        {
            try
            {
                tasks.Add(task);
                SaveTasks().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding tasks: {ex.Message}");
            }
        }

        public async Task SaveTasks()
        {
            var lines = tasks.Select(t => $"{t.Name},{t.Description},{t.Category},{t.IsCompleted}");
            await File.WriteAllLinesAsync(FILE_NAME, lines);
        }

        public IEnumerable<SimpleTask> FilterByCategory(TaskCategory category)
        {
            return tasks.Where(t => t.Category == category);
        }

        public void ViewAllTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
            }
        }    
    }
}