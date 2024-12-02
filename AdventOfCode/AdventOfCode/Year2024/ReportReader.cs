using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class ReportReader
    {
        public static int CountSafeReports(string input, bool allowTolerance = false)
        {
            var reports = input.Split("\r\n").Select(r => new ReportReaderReport(r)).ToList();

            return reports.Count(r => r.IsSafe(allowTolerance));
        }
    }

    public class ReportReaderReport(string input)
    {
        public List<int> Levels { get; } = input.ParseNumbers<int>();

        public bool IsSafe(bool allowTolerance)
        {
            if (IsSafe(Levels)) return true;
            if (allowTolerance)
            {
                for (int n = 0; n < Levels.Count; n++)
                {
                    var levels = Levels.ToList();
                    levels.RemoveAt(n);
                    if (IsSafe(levels)) return true;
                }
            }

            return false;
        }

        private static bool IsSafe(List<int> levels)
        {
            var direction = levels[0] > levels[1] ? -1 : 1;
            for (var n = 1; n < levels.Count; n++)
            {
                if ((direction == 1 && levels[n - 1] > levels[n]) ||
                    (direction == -1 && levels[n - 1] < levels[n]) ||
                    Math.Abs(levels[n - 1] - levels[n]) < 1 ||
                    Math.Abs(levels[n - 1] - levels[n]) > 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
