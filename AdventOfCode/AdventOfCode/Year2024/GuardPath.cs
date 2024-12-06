using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class GuardPath
    {
        public static long CountAllVisitedLocations(string input)
        {
            var map = new Map(input);
            var guard = new Guard(0, map.Spots.First(s => map[s] == '^'));
            return (FindVisitedLocations(map, guard) ?? []).Count;
        }

        public static long CountLoopObtructions(string input)
        {
            var map = new Map(input);
            var guard = new Guard(0, map.Spots.First(s => map[s] == '^'));
            var visited = FindVisitedLocations(map, guard) ?? [];
            var loopObstructionCount = 0;
            foreach (var location in visited.Skip(1))
            {
                map[location] = '#';
                if (FindVisitedLocations(map, guard) == null)
                {
                    loopObstructionCount++;
                }

                map[location] = '.';
            }

            return loopObstructionCount;
        }

        private static HashSet<Spot>? FindVisitedLocations(Map map, Guard guard)
        {
            HashSet<Spot> guardVisitedPositions = [guard.Position];
            HashSet<Guard> guardStates = [guard];
            while (map.IsInBounds(guard.Position))
            {
                switch (guard.Direction)
                {
                    case 0:
                        if (map.Get(guard.Position.North) == '#')
                        {
                            guard = new Guard(guard.Direction + 1, guard.Position);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        else
                        {
                            guardVisitedPositions.Add(guard.Position);
                            guard = new Guard(guard.Direction, guard.Position.North);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        break;
                    case 1:
                        if (map.Get(guard.Position.East) == '#')
                        {
                            guard = new Guard(guard.Direction + 1, guard.Position);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        else
                        {
                            guardVisitedPositions.Add(guard.Position);
                            guard = new Guard(guard.Direction, guard.Position.East);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        break;
                    case 2:
                        if (map.Get(guard.Position.South) == '#')
                        {
                            guard = new Guard(guard.Direction + 1, guard.Position);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        else
                        {
                            guardVisitedPositions.Add(guard.Position);
                            guard = new Guard(guard.Direction, guard.Position.South);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        break;
                    case 3:
                        if (map.Get(guard.Position.West) == '#')
                        {
                            guard = new Guard(0, guard.Position);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        else
                        {
                            guardVisitedPositions.Add(guard.Position);
                            guard = new Guard(guard.Direction, guard.Position.West);
                            if (guardStates.Contains(guard)) return null;
                            guardStates.Add(guard);
                        }
                        break;
                }
            }

            return guardVisitedPositions;
        }
    }

    public record struct Guard(int Direction, Spot Position);
}
