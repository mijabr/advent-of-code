using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class AntinodeDetector
    {
        public static long CountUnqueAntinodes(string input, bool includeHarmonics = false)
        {
            var map = new Map(input);
            Dictionary<char, List<Spot>> antennas = FindAntennas(map);

            var antinodes = new HashSet<Spot>();
            bool addAntinode(Spot spot)
            {
                if (map.IsInBounds(spot))
                {
                    antinodes.Add(spot);
                    return true;
                }

                return false;
            }

            foreach (var antennaGroup in antennas.Values)
            {
                foreach (var (antenna1, antenna2) in antennaGroup.Combinations())
                {
                    var a1 = antenna1;
                    var a2 = antenna2;
                    var diffx = a1.X - a2.X;
                    var diffy = a1.Y - a2.Y;
                    if (includeHarmonics)
                    {
                        while (addAntinode(new Spot(a1.X, a1.Y)))
                        {
                            a1 = new Spot(a1.X + diffx, a1.Y + diffy);
                        }

                        while (addAntinode(new Spot(a2.X, a2.Y)))
                        {
                            a2 = new Spot(a2.X - diffx, a2.Y - diffy);
                        }
                    }
                    else
                    {
                        addAntinode(new Spot(a1.X + diffx, a1.Y + diffy));
                        addAntinode(new Spot(a2.X - diffx, a2.Y - diffy));
                    }
                }
            }

            return antinodes.Count;
        }

        private static Dictionary<char, List<Spot>> FindAntennas(Map map)
        {
            var antennas = new Dictionary<char, List<Spot>>();
            foreach (var spot in map.Spots)
            {
                var v = map[spot];
                if (v != '.')
                {
                    if (!antennas.TryGetValue(v, out var a))
                    {
                        a = new List<Spot>();
                        antennas[v] = a;
                    }

                    a.Add(spot);
                }
            }

            return antennas;
        }
    }
}
