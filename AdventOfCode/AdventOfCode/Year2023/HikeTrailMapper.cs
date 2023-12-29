using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class HikeTrailMapper
    {
        public HikeTrailMapper(string input)
        {
            HikeMap = new HikeTrailMap(input, new Spot(1, 0), 0);
            HikeMap.Map[1, 0] = 'O';
            HikeMap.StepSouth();
            Start = new Spot(1, 1);
            End = new Spot(HikeMap.Map.Width - 2, HikeMap.Map.Height - 1);
            HikeMap.Map[End] = 'E';
        }

        public HikeTrailMap HikeMap { get; private set; }
        public Spot Start { get; private set; }
        public Spot End { get; private set; }

        public HikeTrailMap? FindLongestHike_Old(bool canClimbSlopes = false)
        {
            HikeTrailMap.CanClimbSlopes = canClimbSlopes;
            List<HikeTrailMap> maps = [ HikeMap.Clone() ];
            HikeTrailMap? longestHike = null;
            while (maps.Any())
            {
                var map = maps[0];

                if (map.Map[map.Position.South] == 'E')
                {
                    maps.RemoveAt(0);
                    map.StepSouth();
                    if (longestHike == null || map.Steps > longestHike.Steps)
                    {
                        longestHike = map;
                    }
                }
                else
                {
                    var dirs = new List<Action<HikeTrailMap>>();
                    if (map.CanGoEastOnNewTrail())
                    {
                        dirs.Add((HikeTrailMap m) => m.StepEast());
                    }

                    if (map.CanGoWestOnNewTrail())
                    {
                        dirs.Add((HikeTrailMap m) => m.StepWest());
                    }

                    if (map.CanGoNorthOnNewTrail())
                    {
                        dirs.Add((HikeTrailMap m) => m.StepNorth());
                    }

                    if (map.CanGoSouthOnNewTrail())
                    {
                        dirs.Add((HikeTrailMap m) => m.StepSouth());
                    }

                    if (dirs.Count == 0)
                    {
                        maps.RemoveAt(0);
                    }
                    else
                    {
                        for (int n = 0; n < dirs.Count; n++)
                        {
                            HikeTrailMap m;
                            if (n == dirs.Count - 1)
                            {
                                m = map;
                            }
                            else
                            {
                                m = map.Clone();
                                maps.Add(m);
                            }

                            dirs[n].Invoke(m);
                        }
                    }
                }
            }

            return longestHike;
        }
    }

    public class HikeTrailMap
    {
        public HikeTrailMap(string input, Spot position, int steps)
        {
            Map = new Map(input);
            Position = position;
            Steps = steps;
        }

        public HikeTrailMap(Map map, Spot position, int steps)
        {
            Map = map;
            Position = position;
            Steps = steps;
        }

        public Map Map { get; private set; }
        public Spot Position { get; private set; }
        public int Steps { get; private set; }
        public static bool CanClimbSlopes { get; set; }

        public bool CanGoEastOnNewTrail() => Map[Position.East] != '#' && Map[Position.East] != 'O' && (CanClimbSlopes || Map[Position.East] != '<');
        public bool CanGoWestOnNewTrail() => Map[Position.West] != '#' && Map[Position.West] != 'O' && (CanClimbSlopes || Map[Position.West] != '>');
        public bool CanGoNorthOnNewTrail() => Map[Position.North] != '#' && Map[Position.North] != 'O' && (CanClimbSlopes || Map[Position.North] != 'v');
        public bool CanGoSouthOnNewTrail() => Map[Position.South] != '#' && Map[Position.South] != 'O' && (CanClimbSlopes || Map[Position.South] != '^');

        public int StepEast()
        {
            int steps = 0;
            char nextTerrain;
            do
            {
                steps++;
                Position = Position.East;
                nextTerrain = Map[Position];
                Map[Position] = 'O';
            }
            while (nextTerrain == '>');

            Steps += steps;
            return steps;
        }

        public int StepWest()
        {
            int steps = 0;
            char nextTerrain;
            do
            {
                steps++;
                Position = Position.West;
                nextTerrain = Map[Position];
                Map[Position] = 'O';
            }
            while (nextTerrain == '<');

            Steps += steps;
            return steps;
        }

        public int StepNorth()
        {
            int steps = 0;
            char nextTerrain;
            do
            {
                steps++;
                Position = Position.North;
                nextTerrain = Map[Position];
                Map[Position] = 'O';
            }
            while (nextTerrain == '^');

            Steps += steps;
            return steps;
        }

        public int StepSouth()
        {
            int steps = 0;
            char nextTerrain;
            do
            {
                steps++;
                Position = Position.South;
                nextTerrain = Map[Position];
                Map[Position] = 'O';
            }
            while (nextTerrain == 'v');

            Steps += steps;
            return steps;
        }

        public HikeTrailMap Clone() => new(Map.Clone(), Position, Steps);
    }

    public enum HikerDirection
    {
        North,
        East,
        South,
        West
    }
}
