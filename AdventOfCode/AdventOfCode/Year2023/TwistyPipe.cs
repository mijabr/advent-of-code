using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class TwistyPipe
    {
        public TwistyPipe(string input)
        {
            Map = new Map(input);
        }

        public Map Map { get; private set; }

        public int CountStepsToFurthestPoint()
        {
            var start = Map.Spots.Single(s => Map[s] == Start);
            var paths = FindConnectingPipePaths(start).ToList();
            var steps = 1;
            while (paths[0].Spot != paths[1].Spot)
            {
                var next = Follow(paths[0]);
                if (next == null) throw new Exception("path ended...");
                paths[0] = next;

                if (paths[0].Spot == paths[1].Spot) break;
                next = Follow(paths[1]);
                if (next == null) throw new Exception("path ended...");
                paths[1] = next;
                steps++;
            }

            return steps;
        }

        public int FindEnclosedTiles()
        {
            var start = Map.Spots.Single(s => Map[s] == Start);
            var path = FindConnectingPipePaths(start).ToList()[1];
            var fillSeedsRight = new List<Spot>();
            var fillSeedsLeft = new List<Spot>();
            var rightTurnCount = 0;

            while (path != null)
            {
                fillSeedsRight.Add(path.GetSpotToTheRight());
                fillSeedsLeft.Add(path.GetSpotToTheLeft());
                var nextPath = Follow(path);
                if (nextPath != null)
                {
                    if (path.ComeFrom == rightTurns[nextPath.ComeFrom])
                    {
                        rightTurnCount++;
                    }
                    else if (path.ComeFrom == leftTurns[nextPath.ComeFrom])
                    {
                        rightTurnCount--;
                    }

                    if (Map[nextPath.Spot] == PipeNorthEast)
                    {
                        if (nextPath.ComeFrom == Direction.East)
                        {
                            fillSeedsLeft.Add(nextPath.Spot.SouthWest);
                            fillSeedsLeft.Add(nextPath.Spot.West);
                        }

                        if (nextPath.ComeFrom == Direction.North)
                        {
                            fillSeedsRight.Add(nextPath.Spot.SouthWest);
                            fillSeedsRight.Add(nextPath.Spot.South);
                        }
                    }
                    else if (Map[nextPath.Spot] == PipeSouthWest)
                    {
                        if (nextPath.ComeFrom == Direction.West)
                        {
                            fillSeedsLeft.Add(nextPath.Spot.NorthEast);
                            fillSeedsLeft.Add(nextPath.Spot.East);
                        }

                        if (nextPath.ComeFrom == Direction.South)
                        {
                            fillSeedsRight.Add(nextPath.Spot.NorthEast);
                            fillSeedsRight.Add(nextPath.Spot.North);
                        }
                    }
                    else if (Map[nextPath.Spot] == PipeNorthWest)
                    {
                        if (nextPath.ComeFrom == Direction.North)
                        {
                            fillSeedsLeft.Add(nextPath.Spot.SouthEast);
                            fillSeedsLeft.Add(nextPath.Spot.South);
                        }

                        if (nextPath.ComeFrom == Direction.West)
                        {
                            fillSeedsRight.Add(nextPath.Spot.SouthEast);
                            fillSeedsRight.Add(nextPath.Spot.East);
                        }
                    }
                    else if (Map[nextPath.Spot] == PipeSouthEast)
                    {
                        if (nextPath.ComeFrom == Direction.South)
                        {
                            fillSeedsLeft.Add(nextPath.Spot.NorthWest);
                            fillSeedsLeft.Add(nextPath.Spot.North);
                        }

                        if (nextPath.ComeFrom == Direction.East)
                        {
                            fillSeedsRight.Add(nextPath.Spot.NorthWest);
                            fillSeedsRight.Add(nextPath.Spot.West);
                        }
                    }
                }

                Map[path.Spot] = '#';

                path = nextPath;
            }

            var insideSeeds = rightTurnCount > 0 ? fillSeedsRight : fillSeedsLeft;
            foreach (var seed in insideSeeds.Where(s => Map.IsInBounds(s) && Map[s] != '#'))
            {
                Map.FloodFill(seed, 'I', '#');
            }

            return Map.Spots.Count(s => Map[s] == 'I');
        }

        private Dictionary<Direction, Direction> rightTurns = new()
        {
            [Direction.North] = Direction.West,
            [Direction.East] = Direction.North,
            [Direction.South] = Direction.East,
            [Direction.West] = Direction.South
        };

        private Dictionary<Direction, Direction> leftTurns = new()
        {
            [Direction.North] = Direction.East,
            [Direction.East] = Direction.South,
            [Direction.South] = Direction.West,
            [Direction.West] = Direction.North
        };

        private IEnumerable<Path> FindConnectingPipePaths(Spot spot)
        {
            if (!Map.IsLeftEdge(spot) && PipeDoesConnectEast(Map[spot.West]))
            {
                yield return new Path(spot.West, Direction.East);
            }

            if (!Map.IsTopEdge(spot) && PipeDoesConnectSouth(Map[spot.North]))
            {
                yield return new Path(spot.North, Direction.South);
            }

            if (!Map.IsRightEdge(spot) && PipeDoesConnectWest(Map[spot.East]))
            {
                yield return new Path(spot.East, Direction.West);
            }

            if (!Map.IsBottomEdge(spot) && PipeDoesConnectNorth(Map[spot.South]))
            {
                yield return new Path(spot.South, Direction.North);
            }
        }

        private Path? Follow(Path path) => FindNextPipePath(path.Spot, path.ComeFrom);

        private Path? FindNextPipePath(Spot spot, Direction fromDirection)
        {
            if (fromDirection != Direction.East && PipeDoesConnectEast(Map[spot]))
            {
                return new Path(spot.East, Direction.West);
            }

            if (fromDirection != Direction.South && PipeDoesConnectSouth(Map[spot]))
            {
                return new Path(spot.South, Direction.North);
            }

            if (fromDirection != Direction.West && PipeDoesConnectWest(Map[spot]))
            {
                return new Path(spot.West, Direction.East);
            }

            if (fromDirection != Direction.North && PipeDoesConnectNorth(Map[spot]))
            {
                return new Path(spot.North, Direction.South);
            }

            return null;
        }

        private record Path(Spot Spot, Direction ComeFrom)
        {
            public Spot GetSpotToTheRight() => 
                ComeFrom switch
                {
                    Direction.North => Spot.West,
                    Direction.East => Spot.North,
                    Direction.South => Spot.East,
                    Direction.West => Spot.South,
                    _ => throw new Exception("No come from direction...")
                };

            public Spot GetSpotToTheLeft() =>
                ComeFrom switch
                {
                    Direction.North => Spot.East,
                    Direction.East => Spot.South,
                    Direction.South => Spot.West,
                    Direction.West => Spot.North,
                    _ => throw new Exception("No come from direction...")
                };
        }

        private static bool PipeDoesConnectEast(char pipe) => pipe == PipeEastWest || pipe == PipeNorthEast || pipe == PipeSouthEast;
        private static bool PipeDoesConnectSouth(char pipe) => pipe == PipeNorthSouth || pipe == PipeSouthWest || pipe == PipeSouthEast;
        private static bool PipeDoesConnectWest(char pipe) => pipe == PipeEastWest || pipe == PipeNorthWest || pipe == PipeSouthWest;
        private static bool PipeDoesConnectNorth(char pipe) => pipe == PipeNorthSouth || pipe == PipeNorthEast || pipe == PipeNorthWest;

        private static readonly char PipeNorthSouth = '|';
        private static readonly char PipeEastWest = '-';
        private static readonly char PipeNorthEast = 'L';
        private static readonly char PipeNorthWest = 'J';
        private static readonly char PipeSouthWest = '7';
        private static readonly char PipeSouthEast = 'F';
        private static readonly char Start = 'S';

        private enum Direction
        {
            North,
            East,
            South,
            West
        }
    }
}
