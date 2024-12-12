
using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class FenceCostCalculator
    {
        public static long SumCostOfAllFences(string input, bool bulkDiscount = false)
        {
            var map = new Map(input);
            var gardens = new List<Garden>();
            foreach (var spot in map.Spots)
            {
                if (map[spot] == '.') continue;

                var plant = map[spot];
                var seeds = new Stack<Spot>();
                var gardenSpots = new HashSet<Spot>();
                seeds.Push(spot);
                while (seeds.Count > 0)
                {
                    var seed = seeds.Pop();
                    gardenSpots.Add(seed);
                    if (map.IsInBounds(seed.North) && map[seed.North] == plant) seeds.Push(seed.North);
                    if (map.IsInBounds(seed.East) && map[seed.East] == plant) seeds.Push(seed.East);
                    if (map.IsInBounds(seed.South) && map[seed.South] == plant) seeds.Push(seed.South);
                    if (map.IsInBounds(seed.West) && map[seed.West] == plant) seeds.Push(seed.West);
                    map[seed] = '.';
                }

                var area = gardenSpots.Count;
                var northFences = new List<Spot>();
                var eastFences = new List<Spot>();
                var southFences = new List<Spot>();
                var westFences = new List<Spot>();
                foreach (var gardenSpot in gardenSpots)
                {
                    if (!gardenSpots.Contains(gardenSpot.North)) northFences.Add(gardenSpot);
                    if (!gardenSpots.Contains(gardenSpot.East)) eastFences.Add(gardenSpot);
                    if (!gardenSpots.Contains(gardenSpot.South)) southFences.Add(gardenSpot);
                    if (!gardenSpots.Contains(gardenSpot.West)) westFences.Add(gardenSpot);
                    map[gardenSpot] = '.';
                }

                gardens.Add(new Garden(plant, area, northFences, eastFences, southFences, westFences));
            }

            return gardens.Sum(g => g.Area * (bulkDiscount ? g.Sides : g.Perimeter));
        }

        public sealed record Garden(char Plant, int Area, List<Spot> NorthFences, List<Spot> EastFences, List<Spot> SouthFences, List<Spot> WestFences)
        {
            public int Perimeter => NorthFences.Count + EastFences.Count + SouthFences.Count + WestFences.Count;

            public int Sides =>
                CountHorizontalSides(NorthFences) +
                CountHorizontalSides(SouthFences) +
                CountVerticalSides(EastFences) +
                CountVerticalSides(WestFences);

            private static int CountHorizontalSides(List<Spot> spots) => spots
                .GroupBy(s => s.Y).Sum(g => CountSides([..g.Select(s => s.X).OrderBy(x => x)]));

            private static int CountVerticalSides(List<Spot> spots) => spots
                .GroupBy(s => s.X).Sum(g => CountSides([..g.Select(s => s.Y).OrderBy(y => y)]));

            private static int CountSides(List<int> fences)
            {
                var last = fences[0];
                var sides = 1;
                for (int n = 1; n < fences.Count; n++)
                {
                    if (last != fences[n] - 1) sides++;
                    last = fences[n];
                }

                return sides;
            }
        }
    }
}
