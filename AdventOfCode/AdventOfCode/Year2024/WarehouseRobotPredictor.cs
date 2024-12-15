using AdventOfCode.Util;
using System.Text;

namespace AdventOfCode.Year2024
{
    public class WarehouseRobotPredictor
    {
        public static long SumGpsCoords(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var map = new Map(parts[0]);
            var directions = parts[1];
            var robot = map.Spots.FirstOrDefault(s => map[s] == '@');
            map[robot] = '.';

            foreach (var directionChar in directions)
            {
                var direction = directionChar switch
                {
                    '^' => Direction.North,
                    '>' => Direction.East,
                    'v' => Direction.South,
                    '<' => Direction.West,
                    _ => Direction.Invalid
                };

                if (direction != Direction.Invalid)
                {
                    var push = robot.InDirection(direction);
                    if (map[push] == '.')
                    {
                        robot = robot.InDirection(direction);
                    }
                    else if (map[push] == 'O')
                    {
                        while (map[push] == 'O') push = push.InDirection(direction);
                        if (map[push] == '.')
                        {
                            robot = robot.InDirection(direction);
                            map[robot] = '.';
                            map[push] = 'O';
                        }
                    }
                }
            }

            return SumGpsForMap(map);
        }

        public static long SumGpsCoordsInWideMap(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var map = new Map(Widen(parts[0]));
            var directions = parts[1];
            var robot = map.Spots.FirstOrDefault(s => map[s] == '@');
            map[robot] = '.';

            void AddPushing(List<Spot> pushedList, HashSet<Spot> pushingList, Spot push)
            {
                if (map[push] == '[')
                {
                    pushingList.Add(push);
                    pushingList.Add(push.East);
                    if (!pushedList.Contains(push))
                    {
                        pushedList.Add(push);
                        pushedList.Add(push.East);
                    }
                }
                else if (map[push] == ']')
                {
                    pushingList.Add(push);
                    pushingList.Add(push.West);
                    if (!pushedList.Contains(push))
                    {
                        pushedList.Add(push);
                        pushedList.Add(push.West);
                    }
                }
                else if (map[push] == '#')
                {
                    pushingList.Add(push);
                }
            }

            foreach (var directionChar in directions)
            {
                var direction = directionChar switch
                {
                    '^' => Direction.North,
                    '>' => Direction.East,
                    'v' => Direction.South,
                    '<' => Direction.West,
                    _ => Direction.Invalid
                };

                if (direction == Direction.North || direction == Direction.South)
                {
                    var push = robot.InDirection(direction);
                    if (map[push] == '.')
                    {
                        robot = robot.InDirection(direction);
                    }
                    else if (map[push] == '[' || map[push] == ']')
                    {
                        var pushed = new List<Spot>();
                        var pushing = new HashSet<Spot>();

                        AddPushing(pushed, pushing, push);

                        while (pushing.Count > 0 && pushing.Any(p => map[p] == '[' || map[p] == ']') && !pushing.Any(p => map[p] == '#'))
                        {
                            var nextPushing = new HashSet<Spot>();
                            foreach (var p in pushing)
                            {
                                if (map[p] == '[' || map[p] == ']')
                                {
                                    AddPushing(pushed, nextPushing, p.InDirection(direction));
                                }
                            }

                            pushing = nextPushing;
                        }

                        if (pushing.All(p => map[p] == '.'))
                        {
                            robot = robot.InDirection(direction);
                            pushed.Reverse();
                            foreach (var p in pushed)
                            {
                                map[p.InDirection(direction)] = map[p];
                                map[p] = '.';
                            }
                        }
                    }
                }
                else if (direction == Direction.East || direction == Direction.West)
                {
                    var push = robot.InDirection(direction);
                    if (map[push] == '.')
                    {
                        robot = robot.InDirection(direction);
                    }
                    else if (map[push] == '[' || map[push] == ']')
                    {
                        var pushed = new List<Spot>();
                        while (map[push] == '[' || map[push] == ']')
                        {
                            pushed.Add(push);
                            push = push.InDirection(direction);
                        }

                        if (map[push] == '.')
                        {
                            robot = robot.InDirection(direction);
                            pushed.Reverse();
                            foreach (var p in pushed)
                            {
                                map[p.InDirection(direction)] = map[p];
                            }

                            map[robot] = '.';
                        }
                    }
                }
            }

            return SumGpsForMap(map);
        }

        public static string Widen(string input)
        {
            var sb = new StringBuilder();
            foreach (var character in input)
            {
                sb.Append(
                    character switch
                    {
                        '#' => "##",
                        '.' => "..",
                        'O' => "[]",
                        '@' => "@.",
                        '\r' => "\r",
                        '\n' => "\n",
                        _ => throw new NotImplementedException()
                    }
                );
            }

            return sb.ToString();
        }

        public static long SumGpsForMap(Map map) =>
            map.Spots.Where(s => map[s] == 'O' || map[s] == '[').Sum(b => (b.Y) * 100 + b.X);
    }
}
