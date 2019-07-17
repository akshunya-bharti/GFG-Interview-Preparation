using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Arrays
{
    class ProductArray : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(ProductArray).Name}.txt";
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
                var arraySize = Convert.ToInt32(line);

                var line2 = file.ReadLine();
                var arrayStr = line2;

                TestInputs.Add(line2);

                var result = FindProductArray(arraySize, arrayStr);

                // Finally add the result to Test outputs 
                TestOutputs.Add(result);
            }

            file.Close();
        }

        public static string FindProductArray(int arraySize,string arrayStr)
        {
            var array = arrayStr.Split(' ');
            var outputArray = new List<string>();
            var productOfAllElements = 1;

            foreach(var element in array)
            {
                productOfAllElements *= Convert.ToInt32(element);
            }

            foreach(var element in array)
            {
                outputArray.Add((productOfAllElements / Convert.ToInt32(element)).ToString());
            }

            var output = outputArray[0];
            var firstElement = true;

            foreach(var element in outputArray)
            {
                if(firstElement)
                {
                    firstElement = false;
                }
                else
                {
                    output = output + " " + element;
                }
            }

            return output;
        }
    }
}
