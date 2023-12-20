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
                paths[0] = Follow(paths[0]);
                if (paths[0].Spot == paths[1].Spot) break;
                paths[1] = Follow(paths[1]);
                steps++;
            }

            return steps;
        }

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

        private Path Follow(Path path) => FindNextPipePath(path.Spot, path.ComeFrom);

        private Path FindNextPipePath(Spot spot, Direction fromDirection)
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

            throw new Exception("Path ended...");
        }

        private record Path(Spot Spot, Direction ComeFrom);

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
