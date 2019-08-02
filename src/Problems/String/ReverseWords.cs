using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.String
{
    class ReverseWords : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(ReverseWords).Name}.txt";
        // Replace FOLDER NAME with the directory where your file resides
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}String{Separator}";
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
                TestInputs.Add(line);

                // Finally add the result to Test outputs 
                var result = ReverseWordsWithDot(line);
                TestOutputs.Add(result);
            }

            file.Close();
        }

        private static string ReverseWordsWithDot(string inputStr)
        {
            var outputStr = string.Empty;
            var inputStrArray = inputStr.Split('.');

            for(int i=inputStrArray.Length - 1; i>0; i--)
            {
                outputStr += inputStrArray[i] + ".";
            }

            outputStr += inputStrArray[0];

            return outputStr;
        }
    }
}