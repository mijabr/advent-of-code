using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class UnstableDiffusion
    {
        private static readonly Func<Elf, Map, Spot?> _lookNorth = (Elf elf, Map map) =>
            (Map.IsTopEdge(elf.Location) || map[elf.Location.North] == '.') &&
            (Map.IsTopEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.NorthWest] == '.') &&
            (Map.IsTopEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.NorthEast] == '.')
            ? elf.Location.North : null;

        private static readonly Func<Elf, Map, Spot?> _lookSouth = (Elf elf, Map map) =>
            (map.IsBottomEdge(elf.Location) || map[elf.Location.South] == '.') &&
            (map.IsBottomEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.SouthWest] == '.') &&
            (map.IsBottomEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.SouthEast] == '.')
            ? elf.Location.South : null;

        private static readonly Func<Elf, Map, Spot?> _lookWest = (Elf elf, Map map) =>
            (Map.IsLeftEdge(elf.Location) || map[elf.Location.West] == '.') &&
            (map.IsBottomEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.SouthWest] == '.') &&
            (Map.IsTopEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.NorthWest] == '.')
            ? elf.Location.West : null;

        private static readonly Func<Elf, Map, Spot?> _lookEast = (Elf elf, Map map) =>
            (map.IsRightEdge(elf.Location) || map[elf.Location.East] == '.') &&
            (map.IsBottomEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.SouthEast] == '.') &&
            (Map.IsTopEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.NorthEast] == '.')
            ? elf.Location.East : null;

        private readonly List<Func<Elf, Map, Spot?>> _looks = new()
        {
            _lookNorth, _lookSouth, _lookWest, _lookEast
        };

        public UnstableDiffusion(string input)
        {
            var map = new Map(input);
            Elves = map.Spots.Where(s => map[s] == '#').Select(s => new Elf(s)).ToList();
        }

        public List<Elf> Elves { get; }

        public Map ElvesMap => new('#', Elves.Select(e => e.Location));

        public int SpreadOut(int maxMoves = 10)
        {
            var moves = 0;
            var movedCount = 99;
            while ((maxMoves == -1 || moves < maxMoves) && movedCount > 0)
            {
                Log.Info($"Step {moves}: Building map ");
                var map = ElvesMap;

                Log.Info($"Step {moves}: Heading elves ");
                foreach (var elf in Elves)
                {
                    elf.WhereTo(map, _looks);
                }

                Log.Info($"Step {moves}: Moving elves ");
                movedCount = 0;
                foreach (var elf in Elves)
                {
                    movedCount += elf.MoveTo(Elves);
                }

                CycleLooks();

                NormaliseElves();

                moves++;
            }

            return moves;
        }

        public void CycleLooks()
        {
            var look = _looks[0];
            _looks.RemoveAt(0);
            _looks.Add(look);
        }

        private void NormaliseElves()
        {
            int adjustX = Elves.Min(e => e.Location.X);
            adjustX = adjustX < 0 ? -adjustX : 0;
            int adjustY = Elves.Min(e => e.Location.Y);
            adjustY = adjustY < 0 ? -adjustY : 0;
            foreach (var elf in Elves)
            {
                elf.Location = new Spot(elf.Location.X + adjustX, elf.Location.Y + adjustY);
            }
        }

        public int EmptySpaces
        {
            get
            {
                int sizeX = Elves.Max(e => e.Location.X) - Elves.Min(e => e.Location.X) + 1;
                int sizeY = Elves.Max(e => e.Location.Y) - Elves.Min(e => e.Location.Y) + 1;
                return sizeX * sizeY - Elves.Count;
            }
        }
    }

    public class Elf
    {
        private static readonly Func<Elf, Map, bool> _emptyAllAround = (Elf elf, Map map) =>
            (Map.IsTopEdge(elf.Location) || map[elf.Location.North] == '.') &&
            (map.IsRightEdge(elf.Location) || map[elf.Location.East] == '.') &&
            (map.IsBottomEdge(elf.Location) || map[elf.Location.South] == '.') &&
            (Map.IsLeftEdge(elf.Location) || map[elf.Location.West] == '.') &&
            (map.IsBottomEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.SouthWest] == '.') &&
            (map.IsBottomEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.SouthEast] == '.') &&
            (Map.IsTopEdge(elf.Location) || Map.IsLeftEdge(elf.Location) || map[elf.Location.NorthWest] == '.') &&
            (Map.IsTopEdge(elf.Location) || map.IsRightEdge(elf.Location) || map[elf.Location.NorthEast] == '.');

        public Elf(Spot location)
        {
            Location = location;
        }

        public Spot Location { get; set; }
        public Spot? Heading { get; set; }

        public void WhereTo(Map map, List<Func<Elf, Map, Spot?>> looks)
        {
            Heading = null;
            if (_emptyAllAround(this, map))
            {
                return;
            }
            foreach (var look in looks)
            {
                var heading = look(this, map);
                if (heading != null)
                {
                    Heading = heading.Value;
                    break;
                }
            }
        }

        public int MoveTo(List<Elf> elves)
        {
            if (Heading != null && !elves.Any(e => e != this && e.Heading == Heading))
            {
                Location = Heading.Value;
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{Location.X}, {Location.Y}";
        }
    }
}
