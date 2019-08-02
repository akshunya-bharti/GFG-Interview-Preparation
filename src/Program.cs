using System;
using System.IO;
using System.Diagnostics;
using InterviewPreparation.Problems;
using System.Collections.Generic;
using System.Linq;

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
            var problem = new Problems.String.ReverseWords();

            try
            {
                RunTestsOn(problem);
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

        private static void RunTestsOn(Problem problem)
        {
            // Calling the overridden Execute Method of the Problem
            problem.Execute();

            var filePath = $"{problem.TestFilePath}{problem.TestFileName}";
            StreamReader file = new StreamReader(filePath);

            int noOfTestCases = Convert.ToInt32(file.ReadLine());

            // Reading and storing expected outputs
            var expectedOutputs = new List<string>();

            var expectedOutputsLineNo = 1;

            while(file.ReadLine() != "expected")
            {
                expectedOutputsLineNo++;
            }

            try
            {
                for (int i = expectedOutputsLineNo + 1; i < (noOfTestCases + expectedOutputsLineNo + 1); i++)
                {
                    var line = File.ReadLines(filePath).Skip(i).Take(1).First();
                    expectedOutputs.Add(line);
                }
            }
            catch(InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    Console.WriteLine("Invalid no of expected outputs provided.");
                    Console.WriteLine("Verify the test file");
                }
            }

            DisplayTestResults(problem.TestInputs ,expectedOutputs, problem.TestOutputs);
        }

        private static void DisplayTestResults(List<string> testInputs,List<string> expectedOutputs, List<string> testOutputs)
        {
            if(expectedOutputs.Count != testOutputs.Count)
            {
                Console.WriteLine($"Tests Count Mismatch. Expected:{expectedOutputs.Count}. Generated:{testOutputs.Count}");
                return;
            }

            var count = expectedOutputs.Count;
            var passed = 0;
            var failed = 0;

            for(int i=0; i<count; i++)
            {
                Console.WriteLine($"\nExecuting Test No : {i + 1}");
                Console.WriteLine($"Input     : [{testInputs[i]}]");
                Console.WriteLine($"Expected  : [{expectedOutputs[i]}]");
                Console.WriteLine($"Output    : [{testOutputs[i]}]");

                if(expectedOutputs[i] == testOutputs[i])
                {
                    passed++;
                }
                else
                {
                    failed++;
                }
            }


            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------");

            Console.WriteLine($"TOTAL TESTS : {count}");
            Console.WriteLine($"PASSED      : {passed}");
            Console.WriteLine($"FAILED      : {failed}");
        }
    }
}
