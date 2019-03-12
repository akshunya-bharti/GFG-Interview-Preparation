using System;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class Factorial : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(Factorial).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            var noOfTestCases = Convert.ToInt32(file.ReadLine());

            for(int i=0; i<noOfTestCases; i++)
            {
                var input = Convert.ToInt32(file.ReadLine());
                var output = CalculateFactorial(input);
                Console.WriteLine(output);
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