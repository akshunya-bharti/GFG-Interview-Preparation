using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.Mathematical
{
    class PrimeNumber : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(PrimeNumber).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Mathematical{Separator}";

        public override void Execute()
        {
            var filePath = $"{TestFilePath}{TestFileName}";
            StreamReader file = new StreamReader(filePath);

            var noOfTestCases = Convert.ToInt32(file.ReadLine());        

            for (int i = 0; i < noOfTestCases; i++)
            {
                var input = Convert.ToInt32(file.ReadLine());

                if(IsPrime(input))
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

        private static bool IsPrime(int input)
        {
            if(input == 1)
            {
                return false;
            }

            // Finding all the primes till half the input
            var listOfPrimes = new List<int> { 2, 3, 5};
            
            if(listOfPrimes.Contains(input))
            {
                return true;
            }

            for(int i=7; i<input/2; i++)
            {
                bool IIsPrime = true;

                foreach(var prime in listOfPrimes)
                {
                    if (i % prime == 0)
                    {
                        IIsPrime = false;
                        break;
                    }
                }

                if(IIsPrime)
                {
                    listOfPrimes.Add(i);
                }
            }

            foreach(var prime in listOfPrimes)
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