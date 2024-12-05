using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class XmasWordSearch
    {
        public static int CountXmasOccurances(string input)
        {
            var map = new Map(input);
            int xmas = 0;

            foreach (var spot in map.Spots.Where(s => map[s] == 'X'))
            {
                if (map.Get(spot.North) == 'M' && map.Get(spot.X, spot.Y - 2) == 'A' && map.Get(spot.X, spot.Y - 3) == 'S') xmas++;
                if (map.Get(spot.East) == 'M' && map.Get(spot.X + 2, spot.Y) == 'A' && map.Get(spot.X + 3, spot.Y) == 'S') xmas++;
                if (map.Get(spot.South) == 'M' && map.Get(spot.X, spot.Y + 2) == 'A' && map.Get(spot.X, spot.Y + 3) == 'S') xmas++;
                if (map.Get(spot.West) == 'M' && map.Get(spot.X - 2, spot.Y) == 'A' && map.Get(spot.X - 3, spot.Y) == 'S') xmas++;
                if (map.Get(spot.NorthEast) == 'M' && map.Get(spot.X + 2, spot.Y - 2) == 'A' && map.Get(spot.X + 3, spot.Y - 3) == 'S') xmas++;
                if (map.Get(spot.SouthEast) == 'M' && map.Get(spot.X + 2, spot.Y + 2) == 'A' && map.Get(spot.X + 3, spot.Y + 3) == 'S') xmas++;
                if (map.Get(spot.SouthWest) == 'M' && map.Get(spot.X - 2, spot.Y + 2) == 'A' && map.Get(spot.X - 3, spot.Y + 3) == 'S') xmas++;
                if (map.Get(spot.NorthWest) == 'M' && map.Get(spot.X - 2, spot.Y - 2) == 'A' && map.Get(spot.X - 3, spot.Y - 3) == 'S') xmas++;
            }

            return xmas;
        }

        public static int CountMasOccurances(string input)
        {
            var map = new Map(input);
            int xmas = 0;
            foreach (var spot in map.Spots.Where(s => map[s] == 'A'))
            {
                if (((map.Get(spot.NorthEast) == 'S' && map.Get(spot.SouthWest) == 'M') || (map.Get(spot.NorthEast) == 'M' && map.Get(spot.SouthWest) == 'S')) &&
                    ((map.Get(spot.NorthWest) == 'M' && map.Get(spot.SouthEast) == 'S') || (map.Get(spot.NorthWest) == 'S' && map.Get(spot.SouthEast) == 'M'))) xmas++;
            }

            return xmas;
        }
    }
}
