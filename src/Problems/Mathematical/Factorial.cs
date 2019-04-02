using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class Factorial : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(Factorial).Name}.txt";
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
                var input = Convert.ToInt32(line);
                TestInputs.Add(line);

                var output = CalculateFactorial(input);
                TestOutputs.Add(output.ToString());
            }

            file.Close();
        }

        private static Int64 CalculateFactorial(Int64 numb)
        {
            if(numb <= 1)
            {
                return 1;
            }

            return numb * CalculateFactorial(numb - 1);
        }
    }
}