using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterviewPreparation.Problems.Arrays
{
    class RotateArray : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(RotateArray).Name}.txt";
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
                // read first line and get array size and rotation size
                var line = file.ReadLine();
                var arraySize = line.Split(' ')[0];
                var rotationSize = Convert.ToInt32(line.Split(' ')[1]);

                // read second line and get the input array
                var line2 = file.ReadLine();
                var inputArray = line2;

                TestInputs.Add(line2);

                // rotate it
                var output = RotateArrayBy(inputArray, rotationSize);
                 
                // save it
                TestOutputs.Add(output);
            }

            file.Close();
        }

        private static string RotateArrayBy(string inputArray, int rotationSize)
        {
            var sb = new StringBuilder();
            var inputStrArray = inputArray.TrimEnd().Split(' ');
            var outputStrArray = new string[inputStrArray.Length];

            // first loop to start from the elements at rotationSize index and
            // keep storing them in output array
            var j = 0;
            for (int i = rotationSize; i < inputStrArray.Length; i++)
            {
                outputStrArray[j] = inputStrArray[i];
                j++;
            }

            // second loop to take the first half from input array and
            // fill the remaining half of output array
            for (int i = 0; i < rotationSize; i++)
            {
                outputStrArray[j] = inputStrArray[i];
                j++;
            }

            // Converting the array to string to return
            foreach(var chr in outputStrArray)
            {
                sb.Append(chr);
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}