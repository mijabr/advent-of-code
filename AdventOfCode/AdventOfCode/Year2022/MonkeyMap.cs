using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class MonkeyMap : Map
    {
        public MonkeyMap(string input) : base(input.Split("\r\n")[..^2].ToArray(), ' ')
        {
            MovePath = input.Split("\r\n").Last();
            int x = 0;
            while (x < Width)
            {
                if (this[x, 0] == '.')
                {
                    Current = new Spot(x, 0);
                    break;
                }

                x++;
            }
        }

        public string MovePath { get; set; }

        public Spot Current { get; set; }

        public Facing Facing { get; set; }
        public int Password => (1000 * (Current.Y + 1)) + (4 * (Current.X + 1)) + (int)Facing;

        public void MoveOnPath()
        {
            int pos = 0;
            while (pos < MovePath.Length)
            {
                if (MovePath[pos] == 'R')
                {
                    Facing++;
                    if (Facing == Facing.OffBottom) Facing = Facing.Right;
                    pos++;
                }
                else if (MovePath[pos] == 'L')
                {
                    Facing--;
                    if (Facing == Facing.OffTop) Facing = Facing.Up;
                    pos++;
                }
                else
                {
                    Move(MovePath.Parse<int>(pos));
                    while (pos < MovePath.Length && "0123456789".Contains(MovePath[pos]))
                    {
                        pos++;
                    }
                }
            }
        }

        private void Move(int distance)
        {
            while (distance > 0)
            {
                var inFront = WhatsInFront();
                if (inFront == '#')
                {
                    return;
                }

                Current = NextWrappedCoord(Current, Facing);
                distance--;
            }
        }

        private char WhatsInFront() => this[NextWrappedCoord(Current, Facing)];

        public Spot NextWrappedCoord(Spot spot, Facing facing)
        {
            var next = NextCoord(spot, facing);
            if (this[next] == ' ')
            {
                while (true)
                {
                    var next2 = BeforeCoord(next, facing);
                    if (next2.X < 0 || next2.Y < 0 || next2.X >= Width || next2.Y >= Height || this[next2] == ' ')
                    {
                        break;
                    }

                    next = next2;
                }
            }

            return next;
        }

        private Spot NextCoord(Spot spot, Facing facing) =>
            facing switch
            {
                Facing.Right => GetDestinationWithWrapping(spot.X, spot.Y, 1, 0),
                Facing.Down => GetDestinationWithWrapping(spot.X, spot.Y, 0, 1),
                Facing.Left => GetDestinationWithWrapping(spot.X, spot.Y, -1, 0),
                Facing.Up => GetDestinationWithWrapping(spot.X, spot.Y, 0, -1),
                _ => throw new Exception("Bad facing")
            };

        private Spot BeforeCoord(Spot spot, Facing facing) =>
            facing switch
            {
                Facing.Right => GetDestinationWithWrapping(spot.X, spot.Y, -1, 0),
                Facing.Down => GetDestinationWithWrapping(spot.X, spot.Y, 0, -1),
                Facing.Left => GetDestinationWithWrapping(spot.X, spot.Y, 1, 0),
                Facing.Up => GetDestinationWithWrapping(spot.X, spot.Y, 0, 1),
                _ => throw new Exception("Bad facing")
            };
    }

    public enum Facing
    {
        OffTop = -1,
        Right,
        Down,
        Left,
        Up,
        OffBottom
    }
}
