using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems
{
    class Sample : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(Sample).Name}.txt";
        // Replace FOLDER NAME with the directory where your file resides
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}[FOLDER NAME]{Separator}";
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
                var inputNumberInt = Convert.ToInt32(line);
                TestInputs.Add(line);

                /*
                 WRITE YOUR LOGIC HERE
                 OR
                 CALL THE FUNCTIONS WRITTEN BELOW 
                 */

                // Finally add the result to Test outputs 
                TestOutputs.Add("");
            }

            file.Close();
        }

        /*
         WRITE ADDITIONAL FUNCTIONS HERE AND CALL THEM IN THE Execute() Method
         */
    }
}