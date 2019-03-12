using System;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class ReverseDigits : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(ReverseDigits).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            var noOfTestCases = Convert.ToInt32(file.ReadLine());

            for(int i=0; i<noOfTestCases; i++)
            {
                var input = Convert.ToInt64(file.ReadLine());

                Int64 output = 0;
                var temp = input;
                var order = Order(input);
                Int64 base10Value = BaseTenToThePower(order);

                while(temp != 0)
                {
                    var digit = temp % 10;
                    output += (digit * base10Value);
                    base10Value = base10Value / 10;

                    temp = temp / 10;
                }

                Console.WriteLine(output);
            }

            file.Close();
        }

        private static int Order(Int64 numb)
        {
            int order = 0;
            var temp = numb;

            while(temp != 0)
            {
                order++;
                temp = temp / 10;
            }

            return order;
        }

        private static Int64 BaseTenToThePower(int power)
        {
            Int64 output = 1;

            if(power == 1)
            {
                return output;
            }

            var counter = power;

            while(counter != 1)
            {
                output = output * 10;
                counter--;
            }

            return output;
        }
    }
}