using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2021
{
    public class AmphipodOrganiser
    {
        public int Organise(string input)
        {
            var houses = new List<AmphipodHouse> { new AmphipodHouse(input) };

            while (houses.Count > 0)
            {
                var nextHouses = new List<AmphipodHouse>();

                houses.ForEach(ho =>
                {
                    foreach (var amphipod in ho.Amphipods)
                    {
                        if (ho.TryMoveAmphipodToHome(amphipod))
                        {
                            nextHouses.Add(ho);
                            break;
                        }
                    }
                    
                });
            }

            return 0;
        }

        //  0123456789012
        // 0#############
        // 1#...........#
        // 2###A#B#C#D###
        // 3  #A#B#C#D#
        // 4  #########

        private class AmphipodHouse
        {
            private readonly Map _map;
            private readonly static List<Spot> _openSpots = new()
            {
                new(1, 1), new(1, 2), new(1, 3), new(1, 4), new(1, 5), new(1, 6), new(1, 7), new(1, 8), new(1, 9), new(1, 10), new(1, 11),
                new(3, 2), new(3, 3),
                new(5, 2), new(5, 3),
                new(7, 2), new(7, 3),
                new(9, 2), new(9, 3),
            };
            private readonly static int _hallwayRow = 1;

            public AmphipodHouse(string state)
            {
                state = state.Replace(' ', '#');
                _map = new Map(state, '#');
            }

            public AmphipodHouse(AmphipodHouse other)
            {
                _map = other._map.Clone();
            }

            public AmphipodHouse Clone()
            {
                return new AmphipodHouse(this);
            }

            public IEnumerable<Amphipod> Amphipods =>
                _openSpots
                    .Where(s => _map[s] != '.')
                    .Select(s => new Amphipod(_map[s], s));

            public bool TryMoveAmphipodToHome(Amphipod amphipod)
            {
                if (IsAmphipodAlreadyHome(amphipod))
                {
                    return false;
                }

                var path = FindPath(amphipod.CurrentlyAt, _map[amphipod.Home[1]] == amphipod.Type ? amphipod.Home[1] : amphipod.Home[0]).ToList();
                if (path.Any(s => _map[s] != '.'))
                {
                    return false;
                }

                _map[path[0]] = '.';
                _map[path[^1]] = amphipod.Type;

                return true;
            }

            private static IEnumerable<Spot> FindPath(Spot from, Spot to)
            {
                while (from.X != to.X && from.Y > _hallwayRow)
                {
                    from.Y--;
                    yield return from;
                }

                while (from.X != to.X && from.Y == _hallwayRow)
                {
                    from.X += from.X < to.X ? -1 : 1;
                    yield return from;
                }

                while (from.X == to.X && from.Y != to.Y)
                {
                    from.Y++;
                    yield return from;
                }
            }

            public bool IsAmphipodAlreadyHome(Amphipod amphipod) =>
                (amphipod.CurrentlyAt == amphipod.Home[1] ||
                (amphipod.CurrentlyAt == amphipod.Home[0] && _map[amphipod.Home[1]] == amphipod.Type));
        }

        private record Amphipod(char Type, Spot CurrentlyAt)
        {
            public readonly static Dictionary<char, Spot[]> _homes = new()
            {
                ['A'] = new Spot[] { new(3, 2), new(3, 3) },
                ['B'] = new Spot[] { new(5, 2), new(5, 3) },
                ['C'] = new Spot[] { new(7, 2), new(7, 3) },
                ['D'] = new Spot[] { new(9, 2), new(9, 3) }
            };

            public Spot[] Home => _homes[Type];
        }
    }
}
