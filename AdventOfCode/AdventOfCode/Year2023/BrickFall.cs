using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class BrickFall
    {
        public BrickFall(string input)
        {
            var rows = input.Split("\r\n");
            Bricks = rows.Select(r => new Brick(r)).ToList();
            Bricks.ForEach(b => b.FindNearbyBricks(Bricks));
        }

        public List<Brick> Bricks { get; private set; }

        public void Drop()
        {
            int dropCount;
            do
            {
                dropCount = 0;
                foreach (var brick in Bricks)
                {
                    if (!brick.IsOnGround() && brick.GetSupportingBrick(brick.NeighbourhoodBricks) == null)
                    {
                        var supportingBrick = brick.GetSupportingBrick(brick.NearbyBricks);
                        if (supportingBrick == null)
                        {
                            brick.Drop();
                            dropCount++;
                        }
                        else
                        {
                            brick.NeighbourhoodBricks.Add(supportingBrick);
                        }
                    }
                }
            }
            while (dropCount > 0);
        }

        public int CountRemovableBricks()
        {
            int canBeRemovedCount = 0;

            foreach (var testBrick in Bricks)
            {
                bool causesFalling = false;
                var otherBricks = Bricks.Except(new List<Brick> { testBrick }).ToList();
                foreach (var brick in otherBricks)
                {
                    if (!brick.IsSupported(brick.NearbyBricks.Except(new List<Brick> { testBrick })))
                    {
                        causesFalling = true;
                        break;
                    }
                }

                if (!causesFalling)
                {
                    canBeRemovedCount++;
                }
            }

            return canBeRemovedCount;
        }

        public int CountFallingBricks()
        {
            int fallingBricksCount = 0;

            int n = 0;
            foreach (var testBrick in Bricks)
            {
                var otherBricks = Bricks.Except(new List<Brick> { testBrick }).ToList();
                List<Brick> fallers = new();
                bool moreFallers;
                do
                {
                    moreFallers = false;
                    foreach (var brick in otherBricks)
                    {
                        if (!brick.IsSupported(brick.NearbyBricks.Except(new List<Brick> { testBrick }).Except(fallers)))
                        {
                            fallers.Add(brick);
                            moreFallers = true;
                        }
                    }

                    fallers.ForEach(f => otherBricks.Remove(f));
                } while (moreFallers);

                fallingBricksCount += fallers.Count;

                n++;
                Console.WriteLine($"{n}/{Bricks.Count} - {fallingBricksCount}");
            }

            return fallingBricksCount;
        }
    }

    public class Brick
    {
        public Brick(string input)
        {
            var ends = input.Split("~");
            var start = ends[0].ParseNumbers<int>();
            var end = ends[1].ParseNumbers<int>();
            Position = new Line3D(
                Math.Min(start[0], end[0]), Math.Min(start[1], end[1]), Math.Min(start[2], end[2]),
                Math.Max(start[0], end[0]), Math.Max(start[1], end[1]), Math.Max(start[2], end[2]));
            if (Position.X1 != Position.X2)
            {
                Orientation = 0;
            }
            else if (Position.Y1 != Position.Y2)
            {
                Orientation = 1;
            }
            else
            {
                Orientation = 2;
            }
        }

        public Line3D Position { get; private set; }
        public int Orientation { get; private set; }

        public void FindNearbyBricks(List<Brick> bricks)
        {
            NearbyBricks = bricks
                .Where(brick =>
                    Position.X1 <= brick.Position.X2 && brick.Position.X1 <= Position.X2 &&
                    Position.Y1 <= brick.Position.Y2 && brick.Position.Y1 <= Position.Y2)
                .Where(brick =>
                    Position.X1 != brick.Position.X1 || Position.X2 != brick.Position.X2 ||
                    Position.Y1 != brick.Position.Y1 || Position.Y2 != brick.Position.Y2 ||
                    Position.Z1 != brick.Position.Z1 || Position.Z2 != brick.Position.Z2)
                .ToList();
        }

        public List<Brick> NearbyBricks { get; private set; } = new();

        public List<Brick> NeighbourhoodBricks { get; private set; } = new();

        public void Drop()
        {
            Position.Z1--;
            Position.Z2--;
        }

        public bool IsOnGround() => Position.Z1 <= 1;

        public bool IsSupported(IEnumerable<Brick> bricks) => IsOnGround() || GetSupportingBrick(bricks) != null;

        public Brick? GetSupportingBrick(IEnumerable<Brick> bricks)
        {
            var under = Orientation == 2
                ? new Line3D(Position.X1, Position.Y1, Position.Z1 - 1, Position.X1, Position.Y1, Position.Z1 - 1)
                : new Line3D(Position.X1, Position.Y1, Position.Z1 - 1, Position.X2, Position.Y2, Position.Z2 - 1);

            foreach (var brick in bricks)
            {
                if (under.X1 <= brick.Position.X2 && brick.Position.X1 <= under.X2 &&
                    under.Y1 <= brick.Position.Y2 && brick.Position.Y1 <= under.Y2 &&
                    under.Z1 <= brick.Position.Z2 && brick.Position.Z1 <= under.Z2)
                {
                    return brick;
                }
            }

            return null;
        }
    }

    public class Line3D
    {
        public Line3D(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            X1 = x1;
            Y1 = y1;
            Z1 = z1;
            X2 = x2;
            Y2 = y2;
            Z2 = z2;
        }

        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Z1 { get; set; }
        public int Z2 { get; set; }
    }
}
