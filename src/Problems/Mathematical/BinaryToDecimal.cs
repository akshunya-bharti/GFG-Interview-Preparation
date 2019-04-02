using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class BinaryToDecimal : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(BinaryToDecimal).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";
        public override List<string> TestInputs { get; set; } = new List<string>();
        public override List<string> TestOutputs { get; set; } = new List<string>();

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            var noOfTestCases = Convert.ToInt32(file.ReadLine());

            for(int i=0; i<noOfTestCases; i++)
            {
                var line = file.ReadLine();
                var binaryInput = Convert.ToInt64(line);
                TestInputs.Add(line);

                Int64 decimalOutput = 0;
                var temp = binaryInput;
                var baseTwoValue = 1;

                while (temp != 0)
                {
                    // finding least significant bit
                    var lsbOfTemp = temp % 10;

                    // multiplying the lsb with baseTwoVAlue at that position
                    decimalOutput += (lsbOfTemp * baseTwoValue);

                    // moving on to the next digit (towards the left)
                    temp = temp / 10;

                    // increasing the base two value in the same loop
                    baseTwoValue = baseTwoValue * 2;
                }

                TestOutputs.Add(decimalOutput.ToString());
            }

            file.Close();
        }
    }
}