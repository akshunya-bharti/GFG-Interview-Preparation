using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Arrays
{
    class ReverseAnArray : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(ReverseAnArray).Name}.txt";
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
                var arrayElements = line2;

                TestInputs.Add(arrayElements);

                var output = ReverseArray(arraySize, arrayElements);

                TestOutputs.Add(output);
            }

            file.Close();
        }

        private static string ReverseArray(int size, string inputArray)
        {
            var charArray = inputArray.Split(' ');
            var stack = new Stack(size);

            foreach(var num in charArray)
            {
                var intNum = Convert.ToInt32(num);
                stack.Push(intNum);
            }

            var outputArray = string.Empty;

            while(stack.MaxIndex != 0)
            {
                outputArray = outputArray + $"{stack.Pop()} "; 
            }

            outputArray = outputArray + $"{stack.Pop()}";

            return outputArray;
        }
    }

    class Stack
    {
        public int MaxIndex { get; set; }
        public int?[] Array { get; set; }

        public Stack(int size)
        {
            Array = new int?[size];
            MaxIndex = -1;
        }

        public void Push(int number)
        {
            MaxIndex++;
            Array[MaxIndex] = number;
        }

        public int? Pop()
        {            
            var popOutNumber = Array[MaxIndex];
            Array[MaxIndex] = null;
            MaxIndex--;

            return popOutNumber;
        }
    }
}