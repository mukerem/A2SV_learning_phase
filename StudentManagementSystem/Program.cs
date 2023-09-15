using System;

class Program
{
    static void Main()
    {
        var studentManager = new StudentList<Student>();

        studentManager.Add(new Student("Mukerem", 26, "A", "R123"));
        studentManager.Add(new Student("Biruk", 22, "B", "R124"));
        studentManager.DisplayAll();

        var student = studentManager.SearchByName("Mukerem");
        Console.WriteLine(student?.Name ?? "Student not found.");

        studentManager.Serialize("students.json");
        studentManager.Deserialize("students.json");
    }
}
