using System.Collections.Generic;
using System.IO;

namespace InterviewPreparation.Problems
{
    abstract class Problem
    {
        abstract public void Execute();
        abstract public string TestFileName { get; set; }
        abstract public string TestFilePath { get; set; }
        abstract public List<string> TestInputs { get; set; }
        abstract public List<string> TestOutputs { get; set; }

        public static char Separator { get; set; } = Path.DirectorySeparatorChar;
    }
}
