using AdventOfCode.Util;
using System.Diagnostics;

namespace AdventOfCode.Year2023
{
    public class HikeTrailMapperSuper
    {
        public HikeTrailMapperSuper(string input)
        {
            var map = new Map(input);
            Start = new Spot(1, 0);
            End = new Spot(map.Width - 2, map.Height - 1);
            var startNode = new HikeTrailNode(Start);
            startNode.TrailDirections.Add(HikerDirection.South);
            HikeTrailNodes = new Dictionary<Spot, HikeTrailNode> { [startNode.Spot] = startNode };

            var workingNodes = new Queue<HikeTrailNode>();
            workingNodes.Enqueue(startNode);

            while (workingNodes.Count > 0)
            {
                var node = workingNodes.Dequeue();
                foreach (var direction in node.TrailDirections)
                {
                    var walker = new HikeTrailWalker(map, node.Spot, direction);
                    walker.FollowToNextNode();
                    if (!HikeTrailNodes.TryGetValue(walker.Position, out var nextNode))
                    {
                        nextNode = new HikeTrailNode(walker.Position);
                        nextNode.TrailDirections.AddRange(walker.GetAvailableDirections());
                        workingNodes.Enqueue(nextNode);
                        HikeTrailNodes.Add(nextNode.Spot, nextNode);
                    }

                    node.ConnectingNodes.Add(new HikeTrailNodeConnection(nextNode, walker.Steps));
                }
            }
        }

        public Spot Start { get; private set; }
        public Spot End { get; private set; }

        public Dictionary<Spot, HikeTrailNode> HikeTrailNodes { get; set; }

        public int FindLongestHike()
        {
            var timer = Stopwatch.StartNew();
            var longWalkers = new Queue<LongWalker>();
            longWalkers.Enqueue(new LongWalker(HikeTrailNodes[new Spot(1, 0)]));
            int longest = 0;
            while (longWalkers.Count > 0)
            {
                if (timer.Elapsed.TotalSeconds > 1)
                {
                    Console.WriteLine($"Following {longWalkers.Count} trails - longest so far is {longest}");
                    timer.Restart();
                }
                var longWalker = longWalkers.Dequeue();
                var newPlaces = longWalker.Position.ConnectingNodes.Where(s => !longWalker.VisitedNodeSpots.Contains(s.ConnectingNode.Spot)).ToList();
                for (int n = 0; n < newPlaces.Count; n++)
                {
                    LongWalker nextLongWalker;
                    if (n == newPlaces.Count - 1)
                    {
                        nextLongWalker = longWalker;
                    }
                    else
                    {
                        nextLongWalker = longWalker.Clone();
                    }

                    nextLongWalker.Position = newPlaces[n].ConnectingNode;
                    nextLongWalker.Steps += newPlaces[n].Steps;
                    nextLongWalker.VisitedNodeSpots.Add(nextLongWalker.Position.Spot);
                    if (nextLongWalker.Position.Spot == End)
                    {
                        if (nextLongWalker.Steps > longest)
                        {
                            longest = nextLongWalker.Steps;
                        }
                    }
                    else
                    {
                        longWalkers.Enqueue(nextLongWalker);
                    }
                }
            }

            return longest;
        }
    }

    public class LongWalker(HikeTrailNode position)
    {
        public LongWalker(HikeTrailNode position, List<Spot> visitedNodeSpots, int steps) : this(position)
        {
            VisitedNodeSpots.Clear();
            VisitedNodeSpots.AddRange(visitedNodeSpots);
            Steps = steps;
        }

        public HikeTrailNode Position { get; set; } = position;
        public List<Spot> VisitedNodeSpots { get; } = new() { position.Spot };
        public int Steps { get; set; }

        public LongWalker Clone() => new LongWalker(Position, VisitedNodeSpots, Steps);
    }

    public class HikeTrailNode(Spot spot)
    {
        public Spot Spot { get; set; } = spot;
        public List<HikerDirection> TrailDirections { get; } = new();
        public List<HikeTrailNodeConnection> ConnectingNodes { get; } = new();
    }

    public record HikeTrailNodeConnection(HikeTrailNode ConnectingNode, int Steps);

    public class HikeTrailWalker(Map map, Spot position, HikerDirection facing)
    {
        public Map Map { get; } = map;
        public Spot Position { get; set; } = position;
        public HikerDirection Facing { get; set; } = facing;
        public int Steps { get; set; }

        public void FollowToNextNode()
        {
            StepInDirection(Facing);
            List<HikerDirection> directions;
            do
            {
                directions = new();
                if (Facing != HikerDirection.East && Map[Position.West] != '#')
                {
                    directions.Add(HikerDirection.West);
                }

                if (Facing != HikerDirection.West && Map[Position.East] != '#')
                {
                    directions.Add(HikerDirection.East);
                }

                if (Facing != HikerDirection.South && !Map.IsTopEdge(Position) && Map[Position.North] != '#')
                {
                    directions.Add(HikerDirection.North);
                }

                if (Facing != HikerDirection.North && !Map.IsBottomEdge(Position) && Map[Position.South] != '#')
                {
                    directions.Add(HikerDirection.South);
                }

                if (directions.Count == 1)
                {
                    StepInDirection(directions[0]);
                }
            }
            while (directions.Count == 1);
        }

        private void StepInDirection(HikerDirection direction)
        {
            switch (direction)
            {
                case HikerDirection.East: StepEast(); break;
                case HikerDirection.West: StepWest(); break;
                case HikerDirection.North: StepNorth(); break;
                case HikerDirection.South: StepSouth(); break;
            }
        }

        public void StepWest()
        {
            Facing = HikerDirection.West;
            do
            {
                Position = Position.West;
                Steps++;
            }
            while (Map[Position] == '<');
        }

        public void StepEast()
        {
            Facing = HikerDirection.East;
            do
            {
                Steps++;
                Position = Position.East;
            }
            while (Map[Position] == '>');
        }

        public void StepNorth()
        {
            Facing = HikerDirection.North;
            do
            {
                Position = Position.North;
                Steps++;
            }
            while (Map[Position] == '^');
        }

        public void StepSouth()
        {
            Facing = HikerDirection.South;
            do
            {
                Position = Position.South;
                Steps++;
            }
            while (Map[Position] == 'v');
        }

        public IEnumerable<HikerDirection> GetAvailableDirections()
        {
            if (Map[Position.West] != '#')
            {
                yield return HikerDirection.West;
            }

            if (Map[Position.East] != '#')
            {
                yield return HikerDirection.East;
            }

            if (Map[Position.North] != '#')
            {
                yield return HikerDirection.North;
            }

            if (!Map.IsBottomEdge(Position) && Map[Position.South] != '#')
            {
                yield return HikerDirection.South;
            }
        }
    }
}
