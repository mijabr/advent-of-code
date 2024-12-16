using AdventOfCode.Util;
using System.Collections.ObjectModel;

namespace AdventOfCode.Year2024
{
    public class ReindeerMaze
    {
        public static int FindCheapestPath(string input)
        {
            return FindSolutions(input).Min(s => s.Score);
        }

        public static int CountBestSeats(string input)
        {
            var solutions = FindSolutions(input, true);
            var minScore = solutions.Min(s => s.Score);
            var minSolutions = solutions.Where(s => s.Score == minScore).ToList();
            var visited = minSolutions.SelectMany(s => s.Visited).ToHashSet();

            return visited.Count;
        }

        private static List<Candidate> FindSolutions(string input, bool includeAllBest = false)
        {
            var map = new Map(input);
            var start = map.Spots.FirstOrDefault(s => map[s] == 'S');
            var end = map.Spots.FirstOrDefault(s => map[s] == 'E');
            var candidates = new Queue<Candidate>([
                new([new (start, Direction.East)], [start], 0)
            ]);
            var solutions = new List<Candidate>();
            var stateBestTimes = new Dictionary<ReindeerState, int>
            {
                [new ReindeerState(start, Direction.East)] = 0,
            };

            while (candidates.Count > 0)
            {
                var candidate = candidates.Dequeue();
                var reindeer = candidate.Path.Last();
                var ahead = reindeer.Spot.InDirection(reindeer.Facing);
                if (map[ahead] == '.')
                {
                    if (!candidate.Visited.Contains(ahead))
                    {
                        var forward = new ReindeerState(ahead, reindeer.Facing);
                        if (!stateBestTimes.TryGetValue(forward, out var best) || (includeAllBest && candidate.Score + 1 <= best) || (!includeAllBest && candidate.Score + 1 < best))
                        {
                            Candidate newCandidate = new([.. candidate.Path, forward], [.. candidate.Visited, ahead], candidate.Score + 1);
                            stateBestTimes[forward] = candidate.Score + 1;
                            candidates.Enqueue(newCandidate);
                        }
                    }
                }
                else if (map[ahead] == 'E')
                {
                    var forward = new ReindeerState(ahead, reindeer.Facing);
                    Candidate newCandidate = new([.. candidate.Path, forward], [.. candidate.Visited, ahead], candidate.Score + 1);
                    solutions.Add(newCandidate);
                    continue;
                }

                if (map[reindeer.Spot.InDirection(reindeer.Facing.TurnLeft())] != '#')
                {
                    var turnLeft = new ReindeerState(reindeer.Spot, reindeer.Facing.TurnLeft());
                    var forward = new ReindeerState(turnLeft.Spot.InDirection(turnLeft.Facing), turnLeft.Facing);
                    if (!candidate.Visited.Contains(forward.Spot))
                    {
                        if (!stateBestTimes.TryGetValue(forward, out var best) || (includeAllBest && candidate.Score + 1001 <= best) || (!includeAllBest && candidate.Score + 1001 < best))
                        {
                            Candidate newCandidate = new([.. candidate.Path, turnLeft, forward], [.. candidate.Visited, forward.Spot], candidate.Score + 1001);
                            stateBestTimes[forward] = candidate.Score + 1001;
                            candidates.Enqueue(newCandidate);
                        }
                    }
                }

                if (map[reindeer.Spot.InDirection(reindeer.Facing.TurnRight())] != '#')
                {
                    var turnRight = new ReindeerState(reindeer.Spot, reindeer.Facing.TurnRight());
                    var forward = new ReindeerState(turnRight.Spot.InDirection(turnRight.Facing), turnRight.Facing);
                    if (!candidate.Visited.Contains(forward.Spot))
                    {
                        if (!stateBestTimes.TryGetValue(forward, out var best) || (includeAllBest && candidate.Score + 1001 <= best) || (!includeAllBest && candidate.Score + 1001 < best))
                        {
                            Candidate newCandidate = new([.. candidate.Path, turnRight, forward], [.. candidate.Visited, forward.Spot], candidate.Score + 1001);
                            candidates.Enqueue(newCandidate);
                        }
                    }
                }
            }

            return solutions;
        }
    }

    public sealed record Candidate(List<ReindeerState> Path, HashSet<Spot> Visited, int Score);

    public record struct ReindeerState(Spot Spot, Direction Facing);

    public class OrderedHashSet<T> : KeyedCollection<T, T> where T : notnull
    {
        protected override T GetKeyForItem(T item)
        {
            return item;
        }
    }
}
