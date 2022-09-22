using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//Exercises for the Exceptions Chapter

namespace csharp_web_dev_lsn9exceptions
{
    class Program
    {
        
        static double Divide(double x, double y)
        {
            if (y == 0d)
            {
                throw new ArgumentOutOfRangeException("y", "Cannot divide by zero!");
            }
            else
            {
                return x / y;
            }
        }
        
        static int CheckFileExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "File name cannot be null or empty!");
            }
            else
            {
                const string pattern = @"\.cs$";
                var expr = new Regex(pattern);
                return expr.IsMatch(fileName) ? 1 : 0;
            }
        }
        

        static void Main(string[] args)
        {
            // Test out your Divide() function here!
            try
            {
                Divide(10d, 0d);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            // Test out your CheckFileExtension() function here!
            Dictionary<string, string> students = new Dictionary<string, string>();
            students.Add("Carl", "Program.cs");
            students.Add("Brad", "");
            students.Add("Enzo", "MyCode.csproj");
            students.Add("Elizabeth", "MyCode.cs");
            students.Add("Stefanie", "CoolProgram.cs");

            Dictionary<string, int> grades = new Dictionary<string, int>();
            foreach (KeyValuePair<string, string> studentSubmission in students)
            {
                try
                {
                    int grade = Program.CheckFileExtension(studentSubmission.Value);
                    grades.Add(studentSubmission.Key, grade);
                    Console.WriteLine($"Successfully graded {studentSubmission.Key}'s submission (grade: {grade}).");
                }
                catch (ArgumentNullException e)
                {
                    grades.Add(studentSubmission.Key, 0);
                    Console.WriteLine($"Error when grading {studentSubmission.Key}'s submission (grade: 0): {e.Message}");
                }
            }

        }
    }
}
