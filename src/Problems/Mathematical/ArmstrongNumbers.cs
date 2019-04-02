using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class ArmstrongNumbers : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(ArmstrongNumbers).Name}.txt";        
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";
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

                var order = Order(inputNumberInt);
                var sum = 0;
                var temp = inputNumberInt;
                while(temp != 0)
                {
                    var digit = temp % 10;
                    sum += Power(digit, order);
                    temp = temp / 10;
                }

                if (sum == inputNumberInt)
                {
                    TestOutputs.Add("Yes");
                }
                else
                {
                    TestOutputs.Add("No");
                }
            }

            file.Close();
        }

        private static int Power(int numb, int pow)
        {
            // any number raised to zero is one
            if(pow == 0)
            {
                return 1;
            }

            // any number raised to an even power can be split into 2 numbers raised half the power each
            if(pow%2 ==0)
            {
                return Power(numb, pow / 2) * Power(numb, pow / 2);
            }

            // any number raised to an odd power can be split into...
            // number multiplied by the 2 numbers raised half the power each
            return numb * Power(numb, pow / 2) * Power(numb, pow / 2);
        }

        // Keep on dividig the number by 10, till you get a zero
        private static int Order(int numb)
        {
            var order = 0;

            while (numb != 0)
            {
                numb = numb / 10;
                order++;
            }

            return order;
        }
    }
}
