
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


public class Student
{
    public string Name{ get; set; }
    public string Grade{ get; set; }
    public int Age{ get; set; }
    private readonly string _rollNumber;

    public string RollNumber => _rollNumber;

    public Student(string name, int age, string grade, string rollNumber)
    {
        Name = name;
        Age = age;
        Grade = grade;
        _rollNumber = rollNumber;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, RollNumber: {RollNumber}, Grade: {Grade}";
    }
}

public class StudentList<T>
{
    private List<T> students = new List<T>();

    public void Add(T student)
    {
        students.Add(student);
    }

    public Student SearchByName(string name)
    {
        return students.OfType<Student>().FirstOrDefault(s => s.Name == name);
    }

    public Student SearchByRollNumber(string rollNumber)
    {
        return students.OfType<Student>().FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public void DisplayAll()
    {
        foreach (T student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public void Serialize(string filePath)
    {
        var json = JsonSerializer.Serialize(students);
        File.WriteAllText(filePath, json);

    }

    public void Deserialize(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}