using AdventOfCode.Util;
using System.Text;

namespace AdventOfCode.Year2024
{
    public class ToiletRobotPredictor(string input)
    {
        public List<ToiletRobot> Robots { get; } = input.Split("\r\n").Select(i => new ToiletRobot(i)).ToList();

        public int FindSafetyFactor(int sizeX, int sizeY, int seconds, bool print = false)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < seconds; i++)
            {
                foreach (var robot in Robots)
                {
                    robot.Move(sizeX, sizeY);
                }

                if (print)
                {
                    sb.AppendLine($"seconds={i + 1}");
                    Print(sb, sizeX, sizeY);
                }
            }

            if (print)
            {
                File.WriteAllText("C:\\MB\\Sandbox\\toilet-robots.txt", sb.ToString());
            }

            int[] quadrants = [0, 0, 0, 0];
            foreach (var robot in Robots)
            {
                var quadrant = robot.Quadrant(sizeX, sizeY);
                if (quadrant >= 0) quadrants[quadrant]++;
            }

            return quadrants[0] * quadrants[1] * quadrants[2] * quadrants[3];
        }

        public void Print(StringBuilder sb, int sizeX, int sizeY)
        {
            var counts = Robots.GroupBy(r => (r.X, r.Y)).Select(g => (g.Key, g.Count())).ToDictionary(c => c.Item1, c => c.Item2);
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    var count = counts.TryGetValue((x, y), out var c) ? c : 0;
                    sb.Append(count == 0 ? '.' : '*');
                }

                sb.Append("\r\n");
            }
        }
    }

    public class ToiletRobot(string input)
    {
        public int X { get; set; } = input.Split(' ')[0].ParseAfter<int>("p=");
        public int Y { get; set; } = input.Split(' ')[0].ParseAfter<int>(",");
        public int VX { get; set; } = input.Split(' ')[1].ParseAfter<int>("v=");
        public int VY { get; set; } = input.Split(' ')[1].ParseAfter<int>(",");
        public int Quadrant(int sizeX, int sizeY)
        {
            if (X == sizeX / 2 || Y == sizeY / 2) return -1;
            return ((X < sizeX / 2) ? 0 : 1) + ((Y < sizeY / 2) ? 0 : 2);
        }


        public void Move(int sizeX, int sizeY)
        {
            X += VX;
            if (X >= sizeX) X -= sizeX;
            if (X < 0) X += sizeX;

            Y += VY;
            if (Y >= sizeY) Y -= sizeY;
            if (Y < 0) Y += sizeY;
        }
    }
}
