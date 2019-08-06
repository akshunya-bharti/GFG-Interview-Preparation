using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Searching
{
    class MissingNumber : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(MissingNumber).Name}.txt";
        // Replace FOLDER NAME with the directory where your file resides
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Searching{Separator}";
        public override List<string> TestInputs { get; set; } = new List<string>();
        public override List<string> TestOutputs { get; set; } = new List<string>();

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            int noOfTestCases = Convert.ToInt32(file.ReadLine());

            for (int i = 0; i < noOfTestCases; i++)
            {
                var line = file.ReadLine();

                var line2 = file.ReadLine();
                TestInputs.Add(line2);

                // Finally add the result to Test outputs 
                var result = FindMissingNumberUsingXor(Convert.ToInt32(line), line2);
                TestOutputs.Add(result.ToString());
            }

            file.Close();
        }

        private static int FindMissingNumber(int count, string inputStr)
        {
            var inputStrArry = inputStr.Split(' ');
            var sum = (count * (count + 1)) / 2;

            foreach(var num in inputStrArry)
            {
                try
                {
                    sum -= Convert.ToInt32(num);
                }
                catch(System.FormatException)
                {
                    Console.WriteLine(num);
                }
            }

            return sum;
        }

        private static int FindMissingNumberUsingXor(int count, string inputStr)
        {
            var inputStrArry = inputStr.Split(' ');
            var inputXor = Convert.ToInt32(inputStrArry[0]);
            var allXor = 1;

            for(int i = 1; i < count - 1; i++)
            {
                inputXor = inputXor ^ Convert.ToInt32(inputStrArry[i]);
                allXor = allXor ^ (i + 1);
            }

            allXor = allXor ^ count;

            return inputXor ^ allXor;
        }
    }
}