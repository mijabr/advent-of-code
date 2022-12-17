using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class SandCave : Map
    {
        public SandCave(string input, bool floor = false) : base(999, 500)
        {
            var maxY = 0;
            var lines = input.Split("\r\n");
            foreach (var line in lines)
            {
                var spots = line.Split("->").Select(s => new Spot(s)).ToList();
                var lineMaxY = spots.Select(s => s.Y).Max();
                if (lineMaxY > maxY) maxY = lineMaxY;
                for (int i = 1; i < spots.Count; i++)
                {
                    FillLine(spots[i - 1], spots[i], '#');
                }
            }

            if (floor)
            {
                FillLine(new Spot(0, maxY + 2), new Spot(998, maxY + 2), '#');
            }
        }

        private static Spot _sandDrop = new Spot(500, 0);

        public int SandCount { get; set; }

        public void DropSand()
        {
            var sandInAbyss = false;

            do
            {
                var sand = _sandDrop;
                var sandAtRest = false;
                while (!sandAtRest && !sandInAbyss && this[_sandDrop] == '.')
                {
                    if (sand.Y + 1 >= Height)
                    {
                        sandInAbyss = true;
                    }
                    else if (this[sand.X, sand.Y + 1] == '.')
                    {
                        sand = new Spot(sand.X, sand.Y + 1);
                    }
                    else if (this[sand.X - 1, sand.Y + 1] == '.')
                    {
                        sand = new Spot(sand.X - 1, sand.Y + 1);
                    }
                    else if (this[sand.X + 1, sand.Y + 1] == '.')
                    {
                        sand = new Spot(sand.X + 1, sand.Y + 1);
                    }
                    else
                    {
                        this[sand] = 'o';
                        sandAtRest = true;
                        SandCount++;
                    }
                }

            } while (!sandInAbyss && this[_sandDrop] == '.');
        }
    }
}
