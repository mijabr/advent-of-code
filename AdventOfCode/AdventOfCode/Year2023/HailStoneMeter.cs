using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class HailStoneMeter
    {
        public HailStoneMeter(string input)
        {
            var rows = input.Split("\r\n");
            HailStones = rows.Select(r => new Projectile(r)).ToList();
            MaxX = HailStones.Max(h => h.Position.X);
            MaxY = HailStones.Max(h => h.Position.Y);
        }

        public List<Projectile> HailStones { get; set; }

        public long MaxX { get; private set; }
        public long MaxY { get; private set; }

        public int FindCollisionsInside(long min, long max)
        {
            int collisionsInArea = 0;
            for (int a = 0; a < HailStones.Count - 1; a++)
            {
                for (int b = a + 1; b < HailStones.Count; b++)
                {
                    if (HailStones[a].IsCollisionInside(HailStones[b], min, max, min, max))
                    {
                        collisionsInArea++;
                    }
                }
            }

            return collisionsInArea;
        }

        public long FindRockThrowPositionSum()
        {
            //var minX = HailStones.Min(h => h.Position.X);
            //var minY = HailStones.Min(h => h.Position.Y);
            //var minZ = HailStones.Min(h => h.Position.Z);
            //var maxX = HailStones.Max(h => h.Position.X);
            //var maxY = HailStones.Max(h => h.Position.Y);
            //var maxZ = HailStones.Max(h => h.Position.Z);
            var midy = HailStones.Average(h => h.Position.Y);
            var midx = HailStones.Average(h => h.Position.X);
            var midz = HailStones.Average(h => h.Position.Z);

            var rock = new Projectile();
            rock.Position = new Point3D<long>((long)midx, (long)midy, (long)midz);
            rock.Velocity = new Point3D<long>(0, 0, 0);

            FindRockVelocityForX(rock);
            FindRockVelocityForY(rock);
            FindRockVelocityForZ(rock);

            Console.WriteLine(rock);
            HailStones.ForEach(h =>
            {
                h.CalculateCollisionPoint(rock);
            });
            while (HailStones.Any(h => h.CollisionPoint.X != (long)h.CollisionPoint.X))
            {
                rock.Position = new Point3D<long>(rock.Position.X - rock.Velocity.X, rock.Position.Y - rock.Velocity.Y, rock.Position.Z - rock.Velocity.Z);
            }


            //var hailStones = HailStones.OrderBy(h => h.CollisionPoint.X).ToList();

            //hailStones.ForEach(h =>
            //{
            //    Console.WriteLine(h.GetCollisionPoint(rock));
            //});
            ////Console.WriteLine(hailStones[0].GetCollisionPoint(rock));
            //Console.WriteLine("-----------------");

            //long lcmx = 0;
            //for (int n = 0; n < hailStones.Count; n++)
            //{
            //    var h = hailStones[n];
            //    var stepAddition = h.Velocity.X - rock.Velocity.X;
            //    if (lcmx > 0)
            //    {
            //        lcmx = LowestCommonMultiple(lcmx, stepAddition);
            //    }
            //    else
            //    {
            //        lcmx = stepAddition;
            //    }
            //}
            //long lcmy = 0;
            //for (int n = 0; n < hailStones.Count; n++)
            //{
            //    var h = hailStones[n];
            //    var stepAddition = h.Velocity.Y - rock.Velocity.Y;
            //    if (lcmy > 0)
            //    {
            //        lcmy = LowestCommonMultiple(lcmy, stepAddition);
            //    }
            //    else
            //    {
            //        lcmy = stepAddition;
            //    }
            //}

            //var hlast = hailStones.First();
            //rock.Position = new Point3D<long>(hlast.Position.X + lcmx, rock.Position.Y + lcmy, rock.Position.Z);


            //hailStones.ForEach(h =>
            //{
            //    if ((long)h.CollisionPoint.X != h.CollisionPoint.X)
            //    {
            //        var add = (long)(-(long)h.CollisionPoint.X + h.CollisionPoint.X) * h.Velocity.X;
            //        yplus += add;
            //    }
            //});

            //for (int n = 0; n < HailStones.Count; n++)
            //{
            //    var h = hailStones[n];
            //    if ((long)h.CollisionPoint.X != h.CollisionPoint.X)
            //    {
            //        var stepAddition = h.Velocity.X - rock.Velocity.X;
            //        var diff = 1 - (h.CollisionPoint.X - (long)h.CollisionPoint.X);
            //        var add = (long)(diff * stepAddition);
            //        long xplus = 0;
            //        if (lcm > 0)
            //        {
            //            xplus = LowestCommonMultiple(lcm, add);
            //            lcm = LowestCommonMultiple(lcm, stepAddition);
            //            //xplus = add;
            //        }
            //        else
            //        {
            //            xplus = add;
            //            lcm = stepAddition;
            //        }

            //        rock.Position = new Point3D<long>(rock.Position.X + xplus, rock.Position.Y, rock.Position.Z);
            //        hailStones.ForEach(h =>
            //        {
            //            h.CalculateCollisionPoint(rock);
            //        });
            //    }

            //    if (n > 1)
            //    break;
            //}

            //hailStones.ForEach(h =>
            //{
            //    h.CalculateCollisionPoint(rock);
            //    Console.WriteLine(h.GetCollisionPoint(rock));
            //});
            //Console.WriteLine(hailStones[0].GetCollisionPoint(rock));

            //int cb = 10;
            //while (hailStones[0].YT != hailStones[0].XT || hailStones[0].XT != hailStones[0].ZT && cb > 0)
            //{
            //    long maxt = Math.Max(hailStones[0].YT, hailStones[0].XT, hailStones[0].ZT);
            //    cb--;
            //    hailStones = HailStones.OrderBy(h => h.XT).ToList();
            //}
            //rock.Position = new Point3D<long>(rock.Position.X + (-138 * 76462016626) - rock.Velocity.X * 76462016626, rock.Position.Y, rock.Position.Z);
            //rock.Position = new Point3D<long>(rock.Position.X, rock.Position.Y + (-346 * 9023715863) - rock.Velocity.Y * 9023715863, rock.Position.Z);
            //Console.WriteLine(rock);
            //HailStones.ForEach(h =>
            //{
            //    h.CalculateXT(rock);
            //});

            //hailStones = HailStones.OrderBy(h => h.XT).ToList();
            //for (var n = 0; n < hailStones.Count; n++)
            //{
            //    Console.WriteLine($"XT {hailStones[n].XT} {hailStones[n].Velocity.X} YT {hailStones[n].YT} {hailStones[n].Velocity.Y} ZT {hailStones[n].ZT} {hailStones[n].Velocity.Z}");
            //}


            return rock.Position.X + rock.Position.Y + rock.Position.Z;
        }

        private long LowestCommonMultiple(long a, long b) => a * b / GreatestCommonDivisor(a, b);

        private long GreatestCommonDivisor(long a, long b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);

        public void FindRockVelocityForX(Projectile rock)
        {
            int leastMissing = HailStones.Count;
            long bestV = 0;
            int cb1 = 1000;
            var missing = HailStones;
            while (missing.Count > 0 && cb1 > 0)
            {
                int cb2 = 10;
                while (HailStones.Count(h => h.XT > 0) < HailStones.Count && cb2 > 0)
                {
                    HailStones.ForEach(h =>
                    {
                        h.CalculateXT(rock);
                    });

                    missing = HailStones.Where(h => h.XT < 0).OrderBy(h => h.XT).ToList();
                    //Console.WriteLine($"Converging on mid Y {HailStones.Count - missing.Count}/{HailStones.Count}");
                    //missing.ForEach(h => Console.WriteLine($"Hail stone Y {h.Position.Y} V {h.Velocity.Y} YT {h.YT} Rock Y {rock.Position.Y}"));
                    if (missing.Count > 0)
                    {
                        rock.Position = new Point3D<long>(missing[0].Position.X, missing[0].Position.Y, rock.Position.Z);
                    }

                    if (missing.Count < leastMissing)
                    {
                        leastMissing = missing.Count;
                        bestV = rock.Velocity.X;
                    }

                    cb2--;
                }

                if (missing.Count > 0)
                {
                    long vx = rock.Velocity.X;
                    if (vx < 0)
                    {
                        vx = -vx;
                    }
                    else
                    {
                        vx++;
                        vx = -vx;
                    }
                    rock.Velocity = new Point3D<long>(vx, rock.Velocity.Y, rock.Velocity.Z);
                }

                cb1--;
            }

            if (missing.Count > 0)
            {
                rock.Velocity = new Point3D<long>(bestV, rock.Velocity.Y, rock.Velocity.Z); 
                Console.WriteLine($"X is missing {leastMissing} stones");
            }
            else
            {
                Console.WriteLine("X is on target!");
            }
        }

        public void FindRockVelocityForY(Projectile rock)
        {
            int cb1 = 1000;
            var missing = HailStones;
            while (missing.Count > 0 && cb1 > 0)
            {
                int cb2 = 10;
                while (HailStones.Count(h => h.YT > 0) < HailStones.Count && cb2 > 0)
                {
                    HailStones.ForEach(h =>
                    {
                        h.CalculateYT(rock);
                    });

                    missing = HailStones.Where(h => h.YT < 0).OrderBy(h => h.YT).ToList();
                    //Console.WriteLine($"Converging on mid Y {HailStones.Count - missing.Count}/{HailStones.Count}");
                    //missing.ForEach(h => Console.WriteLine($"Hail stone Y {h.Position.Y} V {h.Velocity.Y} YT {h.YT} Rock Y {rock.Position.Y}"));
                    if (missing.Count > 0)
                    {
                        rock.Position = new Point3D<long>(rock.Position.X, missing[0].Position.Y, rock.Position.Z);
                    }

                    cb2--;
                }

                if (missing.Count > 0)
                {
                    long vy = rock.Velocity.Y;
                    if (vy < 0)
                    {
                        vy = -vy;
                    }
                    else
                    {
                        vy++;
                        vy = -vy;
                    }
                    rock.Velocity = new Point3D<long>(rock.Velocity.X, vy, rock.Velocity.Z);
                }

                cb1--;
            }

            if (missing.Count > 0)
            {
                Console.WriteLine($"Y is missing {missing.Count} stones");
            }
            else
            {
                Console.WriteLine("Y is on target!");
            }
        }

        public void FindRockVelocityForZ(Projectile rock)
        {
            int leastMissing = HailStones.Count;
            long bestV = 0;

            int cb1 = 1000;
            var missing = HailStones;
            while (missing.Count > 0 && cb1 > 0)
            {
                int cb2 = 10;
                while (HailStones.Count(h => h.ZT > 0) < HailStones.Count && cb2 > 0)
                {
                    HailStones.ForEach(h =>
                    {
                        h.CalculateZT(rock);
                    });

                    missing = HailStones.Where(h => h.ZT < 0).OrderBy(h => h.ZT).ToList();
                    //Console.WriteLine($"Converging on mid Y {HailStones.Count - missing.Count}/{HailStones.Count}");
                    //missing.ForEach(h => Console.WriteLine($"Hail stone Y {h.Position.Y} V {h.Velocity.Y} YT {h.YT} Rock Y {rock.Position.Y}"));
                    if (missing.Count > 0)
                    {
                        rock.Position = new Point3D<long>(rock.Position.X, missing[0].Position.Y, missing[0].Position.Z);
                    }

                    if (missing.Count < leastMissing)
                    {
                        leastMissing = missing.Count;
                        bestV = rock.Velocity.X;
                    }

                    cb2--;
                }

                if (missing.Count > 0)
                {
                    long vz = rock.Velocity.Z;
                    if (vz < 0)
                    {
                        vz = -vz;
                    }
                    else
                    {
                        vz++;
                        vz = -vz;
                    }
                    rock.Velocity = new Point3D<long>(rock.Velocity.X, rock.Velocity.Y, vz);
                }

                cb1--;
            }

            if (missing.Count > 0)
            {
                rock.Velocity = new Point3D<long>(rock.Velocity.X, rock.Velocity.Y, bestV);
                Console.WriteLine($"Z is missing {leastMissing} stones");
            }
            else
            {
                Console.WriteLine("Z is on target!");
            }
        }

        public Map GetView(int viewSizeX, int viewSizeY, Projectile rock)
        {
            var map = new Map((int)(viewSizeX * 1.2), (int)(viewSizeY * 1.2), ' ');
            AddXyView(map, viewSizeX / 3, viewSizeY / 3, rock);
            AddZyView(map, viewSizeX / 3, viewSizeY / 3, rock);
            AddXzView(map, viewSizeX / 3, viewSizeY / 3, rock);
            return map;
        }

        private void AddXyView(Map map, int viewSizeX, int viewSizeY, Projectile rock)
        {
            int n = 0;
            HailStones.ForEach(h =>
            {
                var x = (int)((double)h.Position.X / (double)MaxX * (double)viewSizeX);
                var y = (int)((double)h.Position.Y / (double)MaxY * (double)viewSizeY);
                SafeSetMap(map, x, y, '*', viewSizeX, 1);
                n++;
            });

            var rx = (int)((double)rock.Position.X / (double)MaxX * (double)viewSizeX);
            var ry = (int)((double)rock.Position.Y / (double)MaxY * (double)viewSizeY);
            SafeSetMap(map, rx, ry, 'O', viewSizeX, 1);
        }

        private void AddZyView(Map map, int viewSizeX, int viewSizeY, Projectile rock)
        {
            int n = 0;
            HailStones.ForEach(h =>
            {
                var z = (int)((double)h.Position.Z / (double)MaxX * (double)viewSizeX);
                var y = (int)((double)h.Position.Y / (double)MaxY * (double)viewSizeY);
                SafeSetMap(map, z, y, '*', viewSizeX, 2);
                n++;
            });

            var rz = (int)((double)rock.Position.Z / (double)MaxX * (double)viewSizeX);
            var ry = (int)((double)rock.Position.Y / (double)MaxY * (double)viewSizeY);
            SafeSetMap(map, rz, ry, 'O', viewSizeX, 2);
        }

        private void AddXzView(Map map, int viewSizeX, int viewSizeY, Projectile rock)
        {
            int n = 0;
            HailStones.ForEach(h =>
            {
                var x = (int)((double)h.Position.X / (double)MaxX * (double)viewSizeX);
                var z = (int)((double)h.Position.Z / (double)MaxY * (double)viewSizeY);
                SafeSetMap(map, x, z, '*', viewSizeX, 3);
                n++;
            });

            var rx = (int)((double)rock.Position.X / (double)MaxX * (double)viewSizeX);
            var rz = (int)((double)rock.Position.Z / (double)MaxY * (double)viewSizeY);
            SafeSetMap(map, rx, rz, 'O', viewSizeX, 3);
        }

        private void SafeSetMap(Map map, int x, int y, char c, int viewSizeX, int view)
        {
            if (x >= 0 && y >= 0 && x < map.Width / 3 && y < map.Height)
            {
                x += viewSizeX * (view - 1);
                map[x, y] = c;
            }
        }

        public void Step(long steps, Projectile? rock = null)
        {
            HailStones.ForEach(h =>
            {
                h.Position = new Point3D<long>(
                    h.Position.X + h.Velocity.X * steps,
                    h.Position.Y + h.Velocity.Y * steps,
                    h.Position.Z + h.Velocity.Z * steps);
            });

            if (rock != null)
            {
                rock.Position = new Point3D<long>(
                    rock.Position.X + rock.Velocity.X * steps,
                    rock.Position.Y + rock.Velocity.Y * steps,
                    rock.Position.Z + rock.Velocity.Z * steps);
            }
        }
    }

    public class Projectile
    {
        public Projectile(string input)
        {
            var parts = input.Split('@').Select(p => p.ParseNumbers<long>()).ToList();
            Position = new Point3D<long>(parts[0][0], parts[0][1], parts[0][2]);
            Velocity = new Point3D<long>(parts[1][0], parts[1][1], parts[1][2]);
        }

        public Projectile()
        {
        }

        public Point3D<long> Position { get; set; } = new();
        public Point3D<long> Velocity { get; set; } = new();

        public override string ToString() => $"Position({Position}) Velocity({Velocity})";

        public Point3D<double> GetCollisionPoint(Projectile hb)
        {
            var a = ((double)Velocity.Y / (double)Velocity.X);
            var b = ((double)hb.Velocity.Y / (double)hb.Velocity.X);
            var c = (double)Position.Y - (double)Position.X / ((double)Velocity.X / (double)Velocity.Y);
            var d = (double)hb.Position.Y - (double)hb.Position.X / ((double)hb.Velocity.X / (double)hb.Velocity.Y);
            var x = (d - c) / (a - b);
            var y = a * x + c;
            return new Point3D<double>(x, y, 0);
        }

        public bool IsCollisionInside(Projectile hb, double minX, double maxX, double? minY = null, double? maxY = null)
        {
            if (minY == null) minY = minX;
            if (maxY == null) maxY = maxX;

            var collisionPoint = GetCollisionPoint(hb);
            if (collisionPoint.X >= minX && collisionPoint.X <= maxX &&
                collisionPoint.Y >= minY && collisionPoint.Y <= maxY)
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

        public void CalculateXT(Projectile rock)
        {
            XT = (Velocity.X - rock.Velocity.X == 0) ? Double.NegativeInfinity : (rock.Position.X - Position.X) / (Velocity.X - rock.Velocity.X);
        }

        public void CalculateYT(Projectile rock)
        {
            YT = (Velocity.Y - rock.Velocity.Y == 0) ? Double.NegativeInfinity : (rock.Position.Y - Position.Y) / (Velocity.Y - rock.Velocity.Y);
        }

        public void CalculateZT(Projectile rock)
        {
            ZT = (Velocity.Z - rock.Velocity.Z == 0) ? Double.NegativeInfinity : (rock.Position.Z - Position.Z) / (Velocity.Z - rock.Velocity.Z);
        }

        public void CalculateCollisionPoint(Projectile rock)
        {
            CollisionPoint = GetCollisionPoint(rock);
        }

        public double YT { get; set; }
        public double XT { get; set; }
        public double ZT { get; set; }
        public Point3D<double> CollisionPoint { get; set; }
    }

    public struct Point3D<T>(T x, T y, T z)
    {
        public T X { get; set; } = x;
        public T Y { get; set; } = y;
        public T Z { get; set; } = z;

        public override string ToString() => $"({X},{Y},{Z})";
    }
}
