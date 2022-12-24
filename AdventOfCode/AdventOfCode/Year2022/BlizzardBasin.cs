using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class BlizzardBasin
    {
        public BlizzardBasin(string input)
        {
            var map = new Map(input);

            Blizzards = map.Spots
                .Where(s => map[s] == '>' || map[s] == '<' || map[s] == 'v' || map[s] == '^')
                .Select(s => new Blizzard(s, map[s]))
                .ToList();

            Width = map.Width;
            Height = map.Height;
            End = new(Width - 2, Height - 1);
            Start = new(1, 0);
        }

        public List<Blizzard> Blizzards { get; set; }

        public int Width { get; }
        public int Height { get; }

        public HashSet<Spot> PossibleLocations { get; set; } = new() { new(1, 0) };
        public Spot Start { get; }
        public Spot End { get; }
        public int Minutes { get; set; }

        public void TickTillDone(int maxMinutes)
        {
            PossibleLocations = new() { new(1, 0) };
            while (!PossibleLocations.Contains(End) && Minutes < maxMinutes)
            {
                Tick();
            }
        }

        public void TickTillBackAgain(int maxMinutes)
        {
            PossibleLocations = new() { End };
            while (!PossibleLocations.Contains(Start) && Minutes < maxMinutes)
            {
                Tick();
            }
        }

        public void Ticks(int count)
        {
            while (count > 0)
            {
                Tick();
                count--;
            }
        }

        public void Tick()
        {
            Log.Info($"Starting minute {Minutes} - possible locations {PossibleLocations.Count}");
            foreach (var blizzard in Blizzards)
            {
                switch (blizzard.Direction)
                {
                    case '>':
                        blizzard.Location = blizzard.Location.X < Width - 2 ? blizzard.Location.East : new Spot(1, blizzard.Location.Y);
                        break;

                    case '<':
                        blizzard.Location = blizzard.Location.X > 1 ? blizzard.Location.West : new Spot(Width - 2, blizzard.Location.Y);
                        break;

                    case 'v':
                        blizzard.Location = blizzard.Location.Y < Height - 2 ? blizzard.Location.South : new Spot(blizzard.Location.X, 1);
                        break;

                    case '^':
                        blizzard.Location = blizzard.Location.Y > 1 ? blizzard.Location.North : new Spot(blizzard.Location.X, Height - 2);
                        break;
                }
            }

            var map = GetMap();
            var next = new HashSet<Spot>();
            foreach (var possibleLocation in PossibleLocations)
            {
                if (map[possibleLocation] == '.')
                {
                    next.Add(possibleLocation);
                }

                if (possibleLocation.Y > 0 && map[possibleLocation.North] == '.')
                {
                    next.Add(possibleLocation.North);
                }

                if (possibleLocation.Y < Height - 1 && map[possibleLocation.South] == '.')
                {
                    next.Add(possibleLocation.South);
                }

                if (possibleLocation.X > 1 && map[possibleLocation.West] == '.')
                {
                    next.Add(possibleLocation.West);
                }

                if (possibleLocation.X < Width - 2 && map[possibleLocation.East] == '.')
                {
                    next.Add(possibleLocation.East);
                }
            }

            PossibleLocations = next;

            Minutes++;
        }

        public Map GetMap()
        {
            var map = new Map('#', Blizzards.Select(b => b.Location).ToHashSet(), '.', Width, Height);
            map.DrawRect(0, 0, Width - 1, Height - 1, '#');
            map[Start] = '.';
            map[End] = '.';
            return map;
        }
    }

    public class Blizzard
    {
        public Blizzard(Spot spot, char direction)
        {
            Location = spot;
            Direction = direction;
        }

        public Spot Location { get; set; }
        public char Direction { get; set; }
    }
}
