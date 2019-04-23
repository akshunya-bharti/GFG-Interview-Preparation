using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterviewPreparation.Problems.Arrays
{
    class MajorityElement : Problem
    {
        public override string TestFileName { get; set; } = $"{typeof(MajorityElement).Name}.txt";
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}Arrays{Separator}";
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
                var arraySize = Convert.ToInt32(line);

                var line2 = file.ReadLine();
                var arrayStr = line2;

                TestInputs.Add(line2);

                var output = FindMajorityElement(arrayStr);

                TestOutputs.Add(output.ToString());
            }

            file.Close();
        }

        private static int FindMajorityElement(string arrayStr)
        {
            var array = arrayStr.TrimEnd().Split(' ');

            // this will keep a record of the count of each element
            var map = new Dictionary<string, int>();

            // instead of traversing the whole array, we can traverse it in 2 halves
            var fromIndex = 0;
            var toIndex = array.Length / 2;

            // this first half will simply do a count of each element
            for(int i = fromIndex; i<=toIndex; i++)
            {
                var num = array[i];

                if (map.ContainsKey(num))
                {
                    map[num]++;
                }
                else
                {
                    map.Add(num, 1);
                }
            }

            // if all the elements of first half are same, that means it is a majority element
            if(map.Count == 1)
            {
                return Convert.ToInt32(map.Keys.First());
            }

            // Let's finally move to the second half where it gets more interesting ;)
            fromIndex = toIndex + 1;
            toIndex = array.Length - 1;
            var majority = array.Length / 2 + 1;

            for (int i = fromIndex; i <= toIndex; i++)
            {
                var remainingCount = toIndex - i;
                var num = array[i];

                // note the absence of else condition
                // so basically we are not adding any new elements in map as they can never form a majority
                if (map.ContainsKey(num))
                {
                    map[num]++;

                    // now we should always be at a watch to see whether number has formed a majority
                    if(map[num] == majority)
                    {
                        return Convert.ToInt32(num);
                    }
                }

                // now we will check our map to identify exisitng candidates which can never attain majority
                var keysToRemove = new List<string>();
                foreach(var keyValuePair in map)
                {
                    if(keyValuePair.Value + remainingCount < majority)
                    {
                        keysToRemove.Add(keyValuePair.Key);
                    }
                }

                // and remove those keys
                foreach(var key in keysToRemove)
                {
                    map.Remove(key);
                }

                // finally if this results in an empty map, let's break out of the loop
                if(map.Count == 0)
                {
                    break;
                }
            }

            return -1;
        }
    }
}