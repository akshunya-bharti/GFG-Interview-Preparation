using System;
using System.IO;
using System.Diagnostics;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            // using a stopwatch to check execution time of a solution
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Provide the Class Name of the problem you want to execute
            var problem = new Problems.Mathematical.Factorial();

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

            stopWatch.Stop();
            Console.WriteLine($"\nExecution Time:{stopWatch.Elapsed}");
        }
    }
}
