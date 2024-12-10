using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class TrailFinder
    {
        public static int SumTrailScores(string input, bool summits = false)
        {
            var map = new Map(input);
            var trailHeads = map.Spots.Where(s => map[s] == '0').ToList();
            if (summits)
            {
                return trailHeads.Sum(th => FindTrailHeadScore(map, th).summits);
            }
            else
            {
                return trailHeads.Sum(th => FindTrailHeadScore(map, th).trails);
            }
        }

        private static (int trails, int summits) FindTrailHeadScore(Map map, Spot th)
        {
            var candidates = new Stack<Spot>();
            candidates.Push(th);
            var trails = 0;
            var summits = new HashSet<Spot>();
            while (candidates.Count > 0)
            {
                var candidate = candidates.Pop();
                var height = map[candidate];
                if (height == '9')
                {
                    summits.Add(candidate);
                    trails++;
                }
                else
                {
                    if (map.IsInBounds(candidate.North) && map[candidate.North] == height + 1)
                    {
                        candidates.Push(candidate.North);
                    }

                    if (map.IsInBounds(candidate.East) && map[candidate.East] == height + 1)
                    {
                        candidates.Push(candidate.East);
                    }

                    if (map.IsInBounds(candidate.South) && map[candidate.South] == height + 1)
                    {
                        candidates.Push(candidate.South);
                    }

                    if (map.IsInBounds(candidate.West) && map[candidate.West] == height + 1)
                    {
                        candidates.Push(candidate.West);
                    }
                }
            }

            return (trails, summits.Count);
        }
    }
}
