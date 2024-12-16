using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AdventOfCode.Util
{
    public class Map
    {
        protected char[,] _map;

        public Map(string map, char defaultContent = '.') : this(map.Split("\r\n"), defaultContent)
        {
        }

        public Map(string[] rows, char defaultContent = '.')
        {
            var width = rows.Max(row => row.Length);
            _map = new char[width, rows.Length];
            for (int y = 0; y < rows.Length; y++)
            {
                var row = rows[y];
                for (int x = 0; x < width; x++)
                {
                    _map[x, y] = x < row.Length ? row[x] : defaultContent;
                }
            }
        }

        public Map(Map other)
        {
            _map = new char[other.Width, other.Height];
            Array.Copy(other._map, 0, _map, 0, other._map.Length);
        }

        public Map(char spotFill, IEnumerable<Spot> spots, char emptyFill = '.', int? width = null, int? height = null)
        {
            _map = new char[width ?? spots.Select(s => s.X).Max() + 1, height ?? spots.Select(s => s.Y).Max() + 1];
            Fill(emptyFill);
            foreach (var spot in spots)
            {
                this[spot] = spotFill;
            }
        }

        public Map(IEnumerable<Spot> spots, char origin = 's', char fill = '#')
        {
            var smallestX = spots.Select(s => s.X).Min();
            var smallestY = spots.Select(s => s.Y).Min();
            var adjustX = smallestX < 0 ? -smallestX : 0;
            var adjusty = smallestY < 0 ? -smallestY : 0;
            _map = new char[spots.Select(s => s.X).Max() + 1 + adjustX, spots.Select(s => s.Y).Max() + 1+ adjusty];
            Fill('.');
            foreach (var spot in spots)
            {
                this[new Spot(spot.X + adjustX, spot.Y + adjusty)] = fill;
            }

            this[new Spot(adjustX, adjusty)] = origin;
        }

        public Map(int width, int height, char fill = '.')
        {
            _map = new char[width, height];
            Fill(fill);
        }

        public int GetDimenstionLength(int dimension) => _map.GetLength(dimension);
        public int Width => _map.GetLength(0);
        public int Height => _map.GetLength(1);
        public static bool IsLeftEdge(Spot spot) => spot.X == 0;
        public bool IsRightEdge(Spot spot) => spot.X == Width - 1;
        public static bool IsTopEdge(Spot spot) => spot.Y == 0;
        public bool IsBottomEdge(Spot spot) => spot.Y == Height - 1;
        public bool IsInBounds(Spot spot) => spot.X >= 0 && spot.X < Width && spot.Y >= 0 && spot.Y < Height;
        public char Get(Spot spot) => IsInBounds(spot) ? this[spot] : '\0';
        public char Get(int x, int y) => Get(new Spot(x, y));

        public char this[int x, int y]
        {
            get => _map[x, y];
            set => _map[x, y] = value;
        }
        public char this[Spot spot]
        {
            get => _map[spot.X, spot.Y];
            set => _map[spot.X, spot.Y] = value;
        }

        public Spot GetDestinationWithWrapping(int x, int y, int dx, int dy) => new(WrappedCoordinate(0, x, dx), WrappedCoordinate(1, y, dy));

        private int WrappedCoordinate(int dimension, int n, int dn) =>
            n + dn < 0
                ? _map.GetLength(dimension) - (n - dn)
                : n + dn >= _map.GetLength(dimension)
                    ? dn - (_map.GetLength(dimension) - n)
                    : n + dn;

        public IEnumerable<Spot> Spots
        {
            get
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    for (int x = 0; x < _map.GetLength(0); x++)
                    {
                        yield return new Spot(x, y);
                    }
                }
            }
        }

        public void Fill(char fill) => Spots.ToList().ForEach(s => this[s] = fill);

        public void FillLine(Spot from, Spot to, char fill)
        {
            this[from] = fill;
            while (from != to)
            {
                from = new Spot(from.X + Compare(from.X, to.X), from.Y + Compare(from.Y, to.Y));
                this[from] = fill;
            }
        }

        private static int Compare(int n1, int n2) => n1 == n2 ? 0 : n1 < n2 ? 1 : -1;

        public Map Clone() => new Map(this);

        public char[] Row(int y)
        {
            char[] row = new char[Width];
            for (int x = 0; x < Width; x++)
            {
                row[x] = this[x, y];
            }

            return row;
        }

        public Map Rows(int start, int end)
        {
            var map = new Map(Width, end - start + 1);
            var dy = 0;
            for (int y = start; y <= end; y++, dy++)
            {
                for (int x = 0; x < Width; x++)
                {
                    map[x, dy] = this[x, y];
                }
            }

            return map;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    sb.Append(_map[x, y]);
                }

                sb.Append("\r\n");
            }

            return sb.ToString();
        }

        public void DrawRect(int x1, int y1, int x2, int y2, char fillchar = '#')
        {
            for (int x = 0; x < Width; x++)
            {
                this[x, 0] = fillchar;
                this[x, Height - 1] = fillchar;
            }
            for (int y = 1; y < Height - 2; y++)
            {
                this[0, y] = fillchar;
                this[Width - 1, y] = fillchar;
            }
        }

        public void FloodFill(Spot seed, char fill, char boundary)
        {
            if (this[seed] == boundary || this[seed] == fill)
            {
                return;
            }

            this[seed] = fill;

            var seedSpots = new List<Spot> { seed };
            while (seedSpots.Count > 0)
            {
                var nextSeedSpots = new List<Spot>();
                foreach (var spot in seedSpots)
                {
                    if (IsInBounds(spot.East) && this[spot.East] != boundary && this[spot.East] != fill)
                    {
                        nextSeedSpots.Add(spot.East);
                        this[spot.East] = fill;
                    }
                    if (IsInBounds(spot.West) && this[spot.West] != boundary && this[spot.West] != fill)
                    {
                        nextSeedSpots.Add(spot.West);
                        this[spot.West] = fill;
                    }
                    if (IsInBounds(spot.South) && this[spot.South] != boundary && this[spot.South] != fill)
                    {
                        nextSeedSpots.Add(spot.South);
                        this[spot.South] = fill;
                    }
                    if (IsInBounds(spot.North) && this[spot.North] != boundary && this[spot.North] != fill)
                    {
                        nextSeedSpots.Add(spot.North);
                        this[spot.North] = fill;
                    }
                }

                seedSpots = nextSeedSpots;
            }
        }
    }

    public record struct Spot(int X, int Y) : IEqualityComparer<Spot>
    {
        public Spot(string input) : this(0, 0)
        {
            var coords = input.Split(',');
            X = int.Parse(coords[0]);
            Y = int.Parse(coords[1]);
        }

        public Spot North => new(X, Y - 1);
        public Spot NorthEast => new(X + 1, Y - 1);
        public Spot East => new(X + 1, Y);
        public Spot SouthEast => new(X + 1, Y + 1);
        public Spot South => new(X, Y + 1);
        public Spot SouthWest => new(X - 1, Y + 1);
        public Spot West => new(X - 1, Y);
        public Spot NorthWest => new(X - 1, Y - 1);
        public Spot InDirection(Direction direction) => direction switch
        {
            Direction.North => North,
            Direction.East => East,
            Direction.South => South,
            Direction.West => West,
            _ => throw new NotSupportedException()
        };

        public bool Equals(Spot a, Spot b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public int GetHashCode([DisallowNull] Spot obj)
        {
            return obj.Y * 17 + obj.X;
        }

        public override string ToString() => $"({X}, {Y})";
    }

    public enum Direction
    {
        Invalid,
        North,
        East,
        South,
        West
    }

    public static class EnumExtensions
    {
        public static Direction TurnLeft(this Direction direction) =>
            direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => throw new NotSupportedException()
            };
        public static Direction TurnRight(this Direction direction) =>
            direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new NotSupportedException()
            };
    }
}
