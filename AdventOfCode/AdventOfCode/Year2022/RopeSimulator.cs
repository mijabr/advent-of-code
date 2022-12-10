using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class RopeSimulator
    {
        public int Move(string input, int knots)
        {
            var rope = Enumerable.Range(1, knots).Select(i => new Spot(0, 0)).ToArray();
            var tailPositions = new HashSet<Spot> { rope[knots - 1] };
            foreach (var move in input.Split("\r\n"))
            {
                var direction = move[0];
                var distance = move.Parse<int>(2);

                while (distance > 0)
                {
                    rope[0] = direction switch
                    {
                        'U' => new Spot(rope[0].X, rope[0].Y - 1),
                        'D' => new Spot(rope[0].X, rope[0].Y + 1),
                        'L' => new Spot(rope[0].X - 1, rope[0].Y),
                        'R' => new Spot(rope[0].X + 1, rope[0].Y) ,
                        _ => throw new Exception("Bad direction")
                    };

                    for (int knot = 1; knot < knots; knot++)
                    {
                        var leading = rope[knot - 1];
                        var following = rope[knot];
                        if (Math.Abs(leading.X - following.X) > 1 || Math.Abs(leading.Y - following.Y) > 1)
                        {
                            following.X += Math.Sign(leading.X - following.X);
                            following.Y += Math.Sign(leading.Y - following.Y);
                            rope[knot] = following;
                        }
                    }

                    tailPositions.Add(rope[knots - 1]);

                    distance--;
                }
            }

            return tailPositions.Count;
        }
    }
}
