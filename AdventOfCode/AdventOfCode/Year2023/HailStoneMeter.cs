using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class HailStoneMeter
    {
        public HailStoneMeter(string input)
        {
            var rows = input.Split("\r\n");
            HailStones = rows.Select(r => new HailStone(r)).ToList();
        }

        public List<HailStone> HailStones { get; private set; }

        public int FindCollisionsInside(long min, long max)
        {
            int collisionsInArea = 0;
            for (int a = 0; a < HailStones.Count - 1; a++)
            {
                for (int b = a + 1; b < HailStones.Count; b++)
                {
                    if (HailStones[a].IsCollisionInside(HailStones[b], min, max))
                    {
                        collisionsInArea++;
                    }
                }

            }

            return collisionsInArea;
        }
    }

    public class HailStone
    {
        public HailStone(string input)
        {
            var parts = input.Split('@').Select(p => p.ParseNumbers<long>()).ToList();
            Position = new Point3D<long>(parts[0][0], parts[0][1], parts[0][2]);
            Velocity = new Point3D<long>(parts[1][0], parts[1][1], parts[1][2]);
        }

        public Point3D<long> Position { get; set; }
        public Point3D<long> Velocity { get; set; }

        public Point3D<double> GetCollisionPoint(HailStone hb)
        {
            var a = ((double)Velocity.Y / (double)Velocity.X);
            var b = ((double)hb.Velocity.Y / (double)hb.Velocity.X);
            var c = (double)Position.Y - (double)Position.X / ((double)Velocity.X / (double)Velocity.Y);
            var d = (double)hb.Position.Y - (double)hb.Position.X / ((double)hb.Velocity.X / (double)hb.Velocity.Y);
            var x = (d - c) / (a - b);
            var y = a * x + c;
            return new Point3D<double>(x, y, 0);
        }

        public bool IsCollisionInside(HailStone hb, double min, double max)
        {
            var collisionPoint = GetCollisionPoint(hb);
            if (collisionPoint.X >= min && collisionPoint.X <= max &&
                collisionPoint.Y >= min && collisionPoint.Y <= max)
            {
                if (Velocity.X > 0)
                {
                    if (collisionPoint.X < Position.X)
                    {
                        return false;
                    }
                }
                if (Velocity.X < 0)
                {
                    if (collisionPoint.X > Position.X)
                    {
                        return false;
                    }
                }
                if (Velocity.Y > 0)
                {
                    if (collisionPoint.Y < Position.Y)
                    {
                        return false;
                    }
                }
                if (Velocity.Y < 0)
                {
                    if (collisionPoint.Y > Position.Y)
                    {
                        return false;
                    }
                }

                if (hb.Velocity.X > 0)
                {
                    if (collisionPoint.X < hb.Position.X)
                    {
                        return false;
                    }
                }
                if (hb.Velocity.X < 0)
                {
                    if (collisionPoint.X > hb.Position.X)
                    {
                        return false;
                    }
                }
                if (hb.Velocity.Y > 0)
                {
                    if (collisionPoint.Y < hb.Position.Y)
                    {
                        return false;
                    }
                }
                if (hb.Velocity.Y < 0)
                {
                    if (collisionPoint.Y > hb.Position.Y)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }

    public struct Point3D<T>(T x, T y, T z)
    {
        public T X { get; set; } = x;
        public T Y { get; set; } = y;
        public T Z { get; set; } = z;
    }
}
