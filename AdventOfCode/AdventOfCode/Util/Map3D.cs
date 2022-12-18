namespace AdventOfCode.Util
{
    public class Map3D
    {
        protected readonly char[,,] _map;
        public Map3D(IEnumerable<Spot3D> spots, char spotFill = '#', char fill = '.')
        {
            var maxX = spots.Select(s => s.X).Max();
            var maxY = spots.Select(s => s.Y).Max();
            var maxZ = spots.Select(s => s.Z).Max();
            _map = new char[maxX + 1, maxY + 1, maxZ + 1];
            Fill('.');
            foreach (var spot in spots)
            {
                this[spot] = spotFill;
            }
        }

        public char this[int x, int y, int z]
        {
            get => _map[x, y, z];
            set => _map[x, y, z] = value;
        }
        public char this[Spot3D spot]
        {
            get => _map[spot.X, spot.Y, spot.Z];
            set => _map[spot.X, spot.Y, spot.Z] = value;
        }

        public IEnumerable<Spot3D> Spots
        {
            get
            {
                for (int z = 0; z < _map.GetLength(2); z++)
                {
                    for (int y = 0; y < _map.GetLength(1); y++)
                    {
                        for (int x = 0; x < _map.GetLength(0); x++)
                        {
                            yield return new Spot3D(x, y, z);
                        }
                    }
                }
            }
        }

        public int Width => _map.GetLength(0);
        public int Height => _map.GetLength(1);
        public int Depth => _map.GetLength(2);

        public static bool IsLeftEdge(Spot3D spot) => spot.X == 0;
        public bool IsRightEdge(Spot3D spot) => spot.X == Width - 1;
        public static bool IsTopEdge(Spot3D spot) => spot.Y == 0;
        public bool IsBottomEdge(Spot3D spot) => spot.Y == Height - 1;
        public static bool IsCloseEdge(Spot3D spot) => spot.Z == 0;
        public bool IsFarEdge(Spot3D spot) => spot.Z == Depth - 1;

        public void Fill(char fill) => Spots.ToList().ForEach(s => this[s] = fill);

    }

    public record struct Spot3D(int X, int Y, int Z)
    {
        public Spot3D(string input) : this(0, 0, 0)
        {
            var coords = input.Split(',');
            X = int.Parse(coords[0]);
            Y = int.Parse(coords[1]);
            Z = int.Parse(coords[2]);
        }

        public Spot3D Left => new(X - 1, Y, Z);
        public Spot3D Right => new(X + 1, Y, Z);
        public Spot3D Up => new(X, Y - 1, Z);
        public Spot3D Down => new(X, Y + 1, Z);
        public Spot3D In => new(X, Y, Z + 1);
        public Spot3D Out => new(X, Y, Z - 1);
    }
}
