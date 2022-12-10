namespace AdventOfCodeTests.Year2022
{
    public class ReindeerFoodCalculator
    {
        public int GetHighestCaloriesCarryingCount(string input) => GetCounts(input).Max();

        public int GetSumOfHighestThreeCaloriesCarryingCount(string input) => GetCounts(input).OrderByDescending(i => i).Take(3).Sum();

        private static List<int> GetCounts(string input) =>
            input
            .Split("\r\n")
            .Select(line => line.Trim())
            .Aggregate(new List<int> { 0 }, (List<int> counts, string line) =>
            {
                if (string.IsNullOrEmpty(line))
                {
                    counts.Add(0);
                }
                else
                {
                    counts[^1] += int.Parse(line);
                }

                return counts;
            });
    }
}
