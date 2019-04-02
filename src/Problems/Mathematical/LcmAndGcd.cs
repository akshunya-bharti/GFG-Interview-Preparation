using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class LcmAndGcd : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(LcmAndGcd).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";
        public override List<string> TestInputs { get; set; } = new List<string>();
        public override List<string> TestOutputs { get; set; } = new List<string>();

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            var noOfTestCases = Convert.ToInt32(file.ReadLine());

            for (int i = 0; i < noOfTestCases; i++)
            {
                var line = file.ReadLine();
                TestInputs.Add(line);

                var num2 = Convert.ToInt32(line.Split(' ')[1]);
                var num1 = Convert.ToInt32(line.Split(' ')[0]);

                var num1PrimeFactors = FindPrimeFactors(num1);
            }

            file.Close();
        }

        private static List<int> FindPrimeFactors(int num)
        {
            var listOfPrimeFactors = new List<int>();
            var listOfPrimes = FindPrimesTill(num);

            var temp = num;

            while(temp != 1)
            {
                foreach (var prime in listOfPrimes)
                {
                    if (temp % prime == 0)
                    {
                        temp = temp / prime;
                        listOfPrimeFactors.Add(prime);
                        break;
                    }
                }
            }

            return listOfPrimeFactors;
        }

        private static List<int> FindPrimesTill(int num)
        {
            var listOfPrimes = new List<int>();

            for (int i = 2; i <= num; i++)
            {
                if(IsPrime(i))
                {
                    listOfPrimes.Add(i);
                }
            }
            
            return listOfPrimes;
        }

        private static bool IsPrime(int input)
        {
            if (input == 1)
            {
                return false;
            }

            // Finding all the primes till half the input
            var listOfPrimes = new List<int> { 2, 3, 5 };

            if (listOfPrimes.Contains(input))
            {
                return true;
            }

            for (int i = 7; i < input / 2; i++)
            {
                bool IIsPrime = true;

                foreach (var prime in listOfPrimes)
                {
                    if (i % prime == 0)
                    {
                        IIsPrime = false;
                        break;
                    }
                }

                if (IIsPrime)
                {
                    listOfPrimes.Add(i);
                }
            }

            foreach (var prime in listOfPrimes)
            {
                if (input % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}