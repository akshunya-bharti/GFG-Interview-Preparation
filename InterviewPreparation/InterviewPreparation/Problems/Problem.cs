using System.IO;

namespace InterviewPreparation.Problems
{
    abstract class Problem
    {
        abstract public void Execute();
        abstract public string TestFileName { get; set; }
        abstract public string TestFilePath { get; set; }

        public static char Separator { get; set; } = Path.DirectorySeparatorChar;
    }
}
