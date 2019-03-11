using System;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class ArmstrongNumbers : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(ArmstrongNumbers).Name}.txt";        
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";        

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            int noOfTestCases = Convert.ToInt32(file.ReadLine());

            for (int i = 0; i < noOfTestCases; i++)
            {
                var inputNumber = file.ReadLine();
                var inputNumberInt = Convert.ToInt32(inputNumber);

                var sumOfCubesOfDigits = 0;
                foreach (var digit in inputNumber)
                {
                    var digitInt = Convert.ToInt32(digit.ToString());
                    var digitCube = (digitInt * digitInt * digitInt);
                    sumOfCubesOfDigits += digitCube;
                }

                if (sumOfCubesOfDigits == inputNumberInt)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            file.Close();
        }
    }
}
