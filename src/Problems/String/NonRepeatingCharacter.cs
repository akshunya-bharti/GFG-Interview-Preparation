using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems.String
{
    class NonRepeatingCharacter : Problem
    {
        // Replace Sample with your class file name
        public override string TestFileName { get; set; } = $"{typeof(NonRepeatingCharacter).Name}.txt";
        // Replace FOLDER NAME with the directory where your file resides
        public override string TestFilePath { get; set; } = $"..{Separator}..{Separator}Problems{Separator}String{Separator}";
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
                var inputSize = line;

                var line2 = file.ReadLine();
                var inputStr = line2;
                TestInputs.Add(inputStr);
                
                var result = FirstNonRepChar(inputStr).ToString();
                if(System.String.IsNullOrEmpty(result))
                {
                    result = "-1";
                }
                
                TestOutputs.Add(result);
            }

            file.Close();
        }

        private static char? FirstNonRepChar(string inputStr)
        {
            //char? currentNonRepChr = null;
            var nonRepCharList = new List<char?>();
            var traversedChar = new HashSet<char?>();

            //currentNonRepChr = inputStr[0];
            traversedChar.Add(inputStr[0]);
            nonRepCharList.Add(inputStr[0]);

            for(int i=1; i<inputStr.Length; i++)
            {
                var c = inputStr[i];

                // already traversed c, so is a repeating char
                if(traversedChar.Contains(c))
                {
                    // if traversing the duplicate of c for the 1st time
                    if(nonRepCharList.Contains(c))
                    {
                        nonRepCharList.Remove(c);
                    }
                }
                // a potential non repeating char
                else
                {
                    nonRepCharList.AddRange(new List<char?>() { c });
                }

                // since it is traversed now
                traversedChar.Add(c);
            }

            if(nonRepCharList.Count != 0)
            {
                return nonRepCharList[0];
            }
            else
            {
                return null;
            }
        }
    }
}