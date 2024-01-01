using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class CosmicTelescope
    {
        public CosmicTelescope(string input)
        {
            Universe = new Map(input);
            Galaxies = Universe.Spots
                .Where(s => Universe[s] == '#')
                .Select(g => new LongSpot(g.X, g.Y))
                .ToList();
        }

        public Map Universe { get; }
        public List<LongSpot> Galaxies { get; private set; }

        public void ExpandUniverse(int expansion = 2)
        {
            var newRows = Enumerable.Range(0, Universe.Height - 1).Where(r => !Galaxies.Any(g => r == g.Y)).ToList();
            var newColumns = Enumerable.Range(0, Universe.Width - 1).Where(r => !Galaxies.Any(g => r == g.X)).ToList();
            Galaxies = Galaxies
                .Select(g => new LongSpot(
                    g.X + (newColumns.Count(n => n < g.X) * (expansion - 1)),
                    g.Y + (newRows.Count(n => n < g.Y) * (expansion - 1))))
                .ToList();
        }

        public long SumGalaxyPairDistance()
        {
            long distance = 0;
            for (var a = 0; a < Galaxies.Count - 1; a++)
            {
                for (var b = a + 1; b < Galaxies.Count; b++)
                {
                    distance += Math.Abs(Galaxies[a].X - Galaxies[b].X) + Math.Abs(Galaxies[a].Y - Galaxies[b].Y);
                }
            }

            return distance;
        }
    }

    public record struct LongSpot(long X, long Y);
}
