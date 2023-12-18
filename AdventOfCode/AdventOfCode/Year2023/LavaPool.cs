using AdventOfCode.Util;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023
{
    public class LavaPool
    {
        public LavaPool(string input)
        {
            var rows = input.Split("\r\n");
            Digs = rows.Select(r => new LavaPoolDig(r)).ToList();
            Map = MakeMap();
            DigEdges();
            DigMiddle();
        }

        public List<LavaPoolDig> Digs { get; private set; }
        public Map Map { get; private set; }
        public Spot StartingSpot { get; private set; }

        private Map MakeMap()
        {
            int minx = 0;
            int miny = 0;
            int maxx = 0;
            int maxy = 0;
            int x = 0;
            int y = 0;
            foreach (var dig in Digs)
            {
                if (dig.Direction == "U")
                {
                    y -= dig.Distance;
                }
                else if (dig.Direction == "D")
                {
                    y += dig.Distance;
                }
                else if (dig.Direction == "L")
                {
                    x -= dig.Distance;
                }
                else if (dig.Direction == "R")
                {
                    x += dig.Distance;
                }

                if (x < minx) minx = x;
                if (y < miny) miny = y;
                if (x > maxx) maxx = x;
                if (y > maxy) maxy = y;
            }

            StartingSpot = new Spot(minx < 0 ? -minx : 0, miny < 0 ? -miny : 0);

            return new Map(maxx + 1 + StartingSpot.X, maxy + 1 + StartingSpot.Y);
        }

        private void DigEdges()
        {
            int x = StartingSpot.X;
            int y = StartingSpot.Y;
            Map[x, y] = '#';
            foreach (var dig in Digs)
            {
                if (dig.Direction == "U")
                {
                    var distance = dig.Distance;
                    while (distance > 0)
                    {
                        Map[x, --y] = '#';
                        distance--;
                    }
                }
                else if (dig.Direction == "D")
                {
                    var distance = dig.Distance;
                    while (distance > 0)
                    {
                        Map[x, ++y] = '#';
                        distance--;
                    }
                }
                else if (dig.Direction == "L")
                {
                    var distance = dig.Distance;
                    while (distance > 0)
                    {
                        Map[--x, y] = '#';
                        distance--;
                    }
                }
                else if (dig.Direction == "R")
                {
                    var distance = dig.Distance;
                    while (distance > 0)
                    {
                        Map[++x, y] = '#';
                        distance--;
                    }
                }
            }
        }

        private void DigMiddle()
        {
            var spotInPool = FindASpotInThePool();
            Map[spotInPool] = '#';
            var seedSpots = new List<Spot> { spotInPool };
            while (seedSpots.Count > 0)
            {
                Console.WriteLine(seedSpots.Count);
                var nextSeedSpots = new List<Spot>();
                foreach (var spot in seedSpots)
                {
                    if (Map[spot.East] == '.')
                    {
                        nextSeedSpots.Add(spot.East);
                        Map[spot.East] = '#';
                    }
                    if (Map[spot.West] == '.')
                    {
                        nextSeedSpots.Add(spot.West);
                        Map[spot.West] = '#';
                    }
                    if (Map[spot.South] == '.')
                    {
                        nextSeedSpots.Add(spot.South);
                        Map[spot.South] = '#';
                    }
                    if (Map[spot.North] == '.')
                    {
                        nextSeedSpots.Add(spot.North);
                        Map[spot.North] = '#';
                    }
                }

                seedSpots = nextSeedSpots;
            }
        }

        private Spot FindASpotInThePool()
        {
            for (int y = 0; y < Map.Height; y++)
            {
                if (FindAspotInARow(y, out Spot spot))
                {
                    return spot;
                }
            }

            throw new Exception("Cant find a spot in the pool");
        }

        private bool FindAspotInARow(int y, out Spot spot)
        {
            for (int x = 0; x < Map.Width - 1; x++)
            {
                if (Map[x, y] == '#')
                {
                    if (Map[x + 1, y] == '.')
                    {
                        spot = new Spot(x + 1, y);
                        return true;
                    }
                    else if (Map[x + 1, y] == '#')
                    {
                        spot = new Spot(0, 0);
                        return false;
                    }
                }
            }

            spot = new Spot(0, 0);
            return false;
        }

        public int Volume
        {
            get
            {
                return Map.Spots.Count(s => Map[s] == '#');
            }
        }
    }

    public class LavaPoolDig
    {
        public LavaPoolDig(string input)
        {
            var parts = input.Split(' ');
            Direction = parts[0];
            Distance = parts[1].Parse<int>();
            Colour = string.Join("", Regex.Matches(parts[2], "[0-9,a-f]").Select(m => m.Value).ToList());
        }

        public string Direction { get; private set; }
        public int Distance { get; private set; }
        public string Colour { get; private set; }
    }
}
