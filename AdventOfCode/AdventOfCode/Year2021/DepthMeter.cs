using AdventOfCode.Util;

namespace AdventOfCode.Year2021
{
    public class DepthMeter
    {
        public int CountIncreases(string puzzleInput)
        {
            List<int> depths = GetDepthsFromInput(puzzleInput);

            int increases = 0;
            for (int i = 1; i < depths.Count; i++)
            {
                if (depths[i - 1] < depths[i])
                {
                    increases++;
                }
            }

            return increases;
        }

        public object CountIncreasesForSlidingWindow(string puzzleInput)
        {
            List<int> depths = GetDepthsFromInput(puzzleInput);

            int increases = 0;
            for (int i = 0; i < depths.Count - 3; i++)
            {
                if (depths[i] + depths[i + 1] + depths[i + 2] < depths[i + 1] + depths[i + 2] + depths[i + 3])
                {
                    increases++;
                }
            }

            return increases;
        }

        private static List<int> GetDepthsFromInput(string puzzleInput)
        {
            return puzzleInput.Split("\r\n").Select(s => s.Parse<int>()).ToList();
        }
    }
}
