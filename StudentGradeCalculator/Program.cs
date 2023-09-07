using System;
using System.Collections.Generic;

namespace StudentGradeCalculator
{

public class Subject
    {
        public string subjectName;
        public int subjectGrade;
    }

    class Program
    {
        static float calculateAverage(List<Subject> subjects, int subjects_count){
            int total_grade = 0;

            foreach (Subject subject in subjects)
            {
                total_grade += subject.subjectGrade;
            }
            float average = total_grade / Convert.ToSingle(subjects_count);
            return average;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Name");
            string student_name = Console.ReadLine();

            Console.WriteLine("Enter the number of subjects");
            int subjects_count = Convert.ToInt32(Console.ReadLine());

            List<Subject> subjects = new List<Subject>();
            string subject_name;
            int grade;

            for (int i = 0; i < subjects_count; i++)
            {
                Console.WriteLine("Enter name of subject " + (i + 1));
                subject_name = Console.ReadLine();
                do
                {
                Console.WriteLine("Enter the grade of " + subject_name + ". The grade should be in the range of 0-100.");
                grade = Convert.ToInt32(Console.ReadLine());
                } while(grade < 0 || grade > 100);

                // Add subjects to the list.
                subjects.Add(new Subject() { subjectName = subject_name, subjectGrade = grade });
            }

            Console.WriteLine("Student Name: " + student_name);
            Console.WriteLine();

            // iterate through the list and display it
            foreach (Subject subject in subjects)
            {
                Console.WriteLine($"Subject Name: {subject.subjectName}    Grade: {subject.subjectGrade}");
            }

            float average = calculateAverage(subjects, subjects_count);
            Console.WriteLine("Average: " + average);
        }
    }
}
