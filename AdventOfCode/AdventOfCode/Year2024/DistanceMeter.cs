using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class DistanceMeter
    {
        public int FindSumOfDistances(string input)
        {
            (var list1, var list2) = GetLists(input);
            var totalDistance = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                totalDistance += Math.Abs(list1[i] - list2[i]);
            }

            return totalDistance;
        }

        public int FindSimilarityIndex(string input)
        {
            (var list1, var list2) = GetLists(input);
            var similarityIndex = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                similarityIndex += list1[i] * list2.Count(n => n == list1[i]);
            }

            return similarityIndex;
        }

        private static (List<int> list1, List<int> list2) GetLists(string input)
        {
            var listItems = input.Split("\r\n");
            var lists = listItems.Select(items =>
            {
                var distances = items.Split("   ").Select(d => d.Parse<int>()).ToList();
                return (distances[0], distances[1]);
            }).ToList();

            var list1 = lists.Select(items => items.Item1).OrderBy(i => i).ToList();
            var list2 = lists.Select(items => items.Item2).OrderBy(i => i).ToList();

            return (list1, list2);
        }
    }
}
