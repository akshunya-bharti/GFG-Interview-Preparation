using System;
using System.IO;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Provide the Class Name of the problem you want to execute
            var problem = new Problems.Mathematical.ArmstrongNumbers();

            try
            {
                // Calling the overridden Execute Method of the Problem
                problem.Execute();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File Not Found");
                Console.WriteLine("\nVerify the File name and path:-");
                Console.WriteLine($"\nPath:{ Path.GetFullPath(problem.TestFilePath)}");
                Console.WriteLine($"\nFile Name:{ problem.TestFileName}");
            }            
        }
    }
}
