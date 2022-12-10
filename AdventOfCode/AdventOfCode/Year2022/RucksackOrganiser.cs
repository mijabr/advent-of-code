using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class RucksackOrganiser
    {
        private const string _priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public int GetDuplicateItemPrioritySum(string rucksacks) =>
            rucksacks.Split("\r\n").Select(GetDuplicateItemPriority).Sum();

        public int GetDuplicateItemPriority(string contents)
        {
            var compartment1 = contents.Substring(0, contents.Length / 2).ToArray();
            var compartment2 = contents.Substring(contents.Length / 2, contents.Length / 2).ToArray();
            return GetPriority(compartment1.Intersect(compartment2).Single());
        }

        public int GetGroupBadgePrioritySum(string rucksacks)
        {
            int sum = 0;
            int pos = 0;
            while (pos < rucksacks.Length)
            {
                var end = rucksacks.IndexOfNth("\r\n", 3, pos);
                if (end < 0)
                {
                    sum += GetGroupBadgePriority(rucksacks.Substring(pos));
                    return sum;
                }
                else
                {
                    sum += GetGroupBadgePriority(rucksacks.Substring(pos, end - pos));
                    pos = end + 1;
                }
            }

            return sum;
        }

        public int GetGroupBadgePriority(string threeRucksacks)
        {
            var rucksacks = threeRucksacks.Split("\r\n").Select(r => r.ToArray()).ToList();
            var badge = rucksacks[0].Intersect(rucksacks[1]).Intersect(rucksacks[2]).Single();
            return GetPriority(badge);
        }

        private static int GetPriority(char item)
        {
            return _priority.IndexOf(item) + 1;
        }
    }
}
