using System;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class SumOfDigitsPalindrome : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(SumOfDigitsPalindrome).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            int noOfTestCases = Convert.ToInt32(file.ReadLine());

            for (int i = 0; i < noOfTestCases; i++)
            {
                var input = Convert.ToInt32(file.ReadLine());
                var sumOfDigits = SumOfDigits(input);

                if (IsPalindrome(sumOfDigits))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
                
            file.Close();
        }

        private static int SumOfDigits(int numb)
        {
            var temp = numb;
            var sum = 0;
            while(temp != 0)
            {
                var digit = temp % 10;
                sum += digit;
                temp = temp / 10;
            }

            return sum;
        }

        private static bool IsPalindrome(int numb)
        {
            var counter = 0;
            var leftHalf = numb;
            var rightHalf = 0;
            var numbLength = Order(numb);

            if(numbLength == 1)
            {
                return true;
            }

            var breakpoint = (numbLength / 2) - 1;

            while (leftHalf != 0)
            {
                rightHalf = (leftHalf % 10) + (rightHalf * 10);
                leftHalf = leftHalf / 10;

                if (counter == breakpoint)
                {
                    if(numbLength % 2 != 0)
                    {
                        leftHalf = leftHalf / 10;
                    }
                    break;
                }

                counter++;
            }

            if(leftHalf == rightHalf)
            {
                return true;
            }
            else
            {
                return false;
            }
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
