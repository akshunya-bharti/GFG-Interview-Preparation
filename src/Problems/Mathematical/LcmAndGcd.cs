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

                var num1 = Convert.ToInt32(line.Split(' ')[0]);
                var num2 = Convert.ToInt32(line.Split(' ')[1]);

                //var lcm = LcmAndGcdByPrimeFactors(num1, num2)[0];
                //var gcd = LcmAndGcdByPrimeFactors(num1, num2)[1];

                var lcm = LcmAndGcdByEuclideanAlgo(num1, num2)[0];
                var gcd = LcmAndGcdByEuclideanAlgo(num1, num2)[1];

                TestOutputs.Add($"{lcm} {gcd}");
            }

            file.Close();
        }

        private static long[] LcmAndGcdByEuclideanAlgo(long num1, long num2)
        {
            if (num1 == num2)
            {
                return new long[2] {num1, num1};
            }

            if (num1 > num2)
            {
                if (num1 % num2 == 0)
                {
                    return new long[2] { num1, num2 };
                }
                else
                {
                    var gcd = LcmAndGcdByEuclideanAlgo(num2, num1 - num2)[1];
                    return new long[2] { (num1 * num2)/gcd, gcd};
                }
            }
            else
            {
                if(num2 % num1 == 0)
                {
                    return new long[2] { num2, num1 };
                }
                else
                {
                    var gcd = LcmAndGcdByEuclideanAlgo(num1, num2 - num1)[1];
                    return new long[2] { (num1 * num2) / gcd, gcd };
                }
            }
        }

        private static int[] LcmAndGcdByPrimeFactors(int num1, int num2)
        {
            var num1PrimeFactors = FindPrimeFactors(num1);
            var num2PrimeFactors = FindPrimeFactors(num2);

            var commonFactors = new List<int>();

            // Finding common factors and removing that from num2 factors
            foreach (var factor in num1PrimeFactors)
            {
                if (num2PrimeFactors.Contains(factor))
                {
                    num2PrimeFactors.Remove(factor);
                    commonFactors.Add(factor);
                }
            }

            var lcm = 1;
            var gcd = 1;

            // Removing common factors from num1 factors and using the same loop
            // to find the product of all factors of common factors
            foreach (var factor in commonFactors)
            {
                num1PrimeFactors.Remove(factor);
                lcm = lcm * factor;
            }

            // since gcd is product of all common factors, the value of lcm at this point is gcd
            gcd = lcm;

            // Repeating the same step for num1 and num2 prime factors (common factors removed)
            foreach (var factor in num1PrimeFactors)
            {
                lcm = lcm * factor;
            }

            foreach (var factor in num2PrimeFactors)
            {
                lcm = lcm * factor;
            }

            return new int[2] { lcm, gcd };
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