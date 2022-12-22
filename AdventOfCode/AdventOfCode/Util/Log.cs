using System.Diagnostics;

namespace AdventOfCode.Util
{
    public static class Log
    {
        public static Stopwatch Stopwatch { get; } = Stopwatch.StartNew();

        public static bool Enabled { get; set; }

        public static void Info(string message)
        {
            if (Enabled) Console.WriteLine($"{Stopwatch.Elapsed} {message}");
        }
    }
}
