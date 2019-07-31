using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Arrays
{
    class RemoveDuplicatesUnsortedArray : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(RemoveDuplicatesUnsortedArray).Name}.txt";
        // Replace FOLDER NAME with the directory where your file resides
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Arrays{Separator}";
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
                var inputSize = line;

                var line2 = file.ReadLine();
                TestInputs.Add(line2);
                var inputArrayString = line2;

                // Finally add the result to Test outputs 
                var result = RemoveDuplicates(inputArrayString, Convert.ToInt32(inputSize));
                TestOutputs.Add(result);
            }

            file.Close();
        }

        private static string RemoveDuplicates(string inputString, int inputSize)
        {
            var inputArray = inputString.Split(' ');
            var alreadyTraversed = new HashSet<string>();

            for(int i=0; i<inputSize; i++)
            {
                var element = inputArray[i];

                if (alreadyTraversed.Contains(element))
                {
                    inputArray[i] = null;
                }
                else
                {
                    alreadyTraversed.Add(element);
                }
            }

            var output = string.Empty;

            foreach(var element in inputArray)
            {
                if(element != null)
                {
                    output += element + ' ';
                }
            }

            output = output.TrimEnd(' ');

            return output;
        }
    }
}