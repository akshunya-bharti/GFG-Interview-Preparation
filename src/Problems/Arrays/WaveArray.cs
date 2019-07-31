using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Arrays
{
    class WaveArray : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(WaveArray).Name}.txt";
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
                var line1 = file.ReadLine();
                var arraySize = Convert.ToInt32(line1);

                var line2 = file.ReadLine();
                var arrayStr = line2;

                TestInputs.Add(line2);

                var result = ConvertToWaveArray(arraySize, arrayStr);

                // Finally add the result to Test outputs 
                TestOutputs.Add(result);
            }

            file.Close();
        }

        public static string ConvertToWaveArray(int arraySize,string arrayStr)
        {
            if(arraySize <= 1)
            {
                return arrayStr;
            }

            var array = arrayStr.Split(' ');

            var num = array.Length % 2 == 0 ? 0 : 1;

            for(int i=num; i<array.Length; i+=2)
            {
                var temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
            }

            var waveArray = System.String.Join(" ", array);

            return waveArray;
        }
    }
}