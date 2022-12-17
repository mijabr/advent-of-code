using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class RockFall : Map
    {
        private readonly int _caveDepth;

        public RockFall(string input, int caveDepth = 20000) : base(7, caveDepth)
        {
            Wind = input;
            _caveDepth = caveDepth;
            RockDepth = caveDepth;
        }

        public string Wind { get; }

        private int _windPos = 0;

        private int _nextRockType = 0;

        public Spot[]? Rock { get; private set; }

        public int RockDepth { get; private set; }

        public int RockHeightFromBottom => _caveDepth - RockDepth;

        public int RockCount { get; set; }

        public RockFallPattern Pattern { get; set; } = new();

        private List<Spot[]> _rocks = new List<Spot[]>()
        {
            new Spot[] { new Spot(2, -4), new Spot(3, -4), new Spot(4, -4), new Spot(5, -4) },
            new Spot[] { new Spot(3, -6), new Spot(2, -5), new Spot(3, -5), new Spot(4, -5), new Spot(3, -4) },
            new Spot[] { new Spot(4, -6), new Spot(4, -5), new Spot(2, -4), new Spot(3, -4), new Spot(4, -4) },
            new Spot[] { new Spot(2, -7), new Spot(2, -6), new Spot(2, -5), new Spot(2, -4) },
            new Spot[] { new Spot(2, -5), new Spot(3, -5), new Spot(2, -4), new Spot(3, -4) },
        };

        public void DropRocks(int rocksToDrop)
        {
            rocksToDrop = TryDropRock(rocksToDrop);

            while (Rock != null)
            {
                ApplyWind();
                ApplyDrop();
                rocksToDrop = TryDropRock(rocksToDrop);
            }
        }

        private int TryDropRock(int rocksToDrop)
        {
            if (rocksToDrop > 0)
            {
                if (DropRock())
                {
                    rocksToDrop--;
                }
            }

            return rocksToDrop;
        }

        public void FindPattern()
        {
            DropRock();
            while (!Pattern.IsPatternFound)
            {
                ApplyWind();
                ApplyDrop();
                var didDropRock = DropRock();
                if (_nextRockType == 0 && didDropRock)
                {
                   Pattern.TryFindPattern();
                }
            }
        }

        public long GetHeightUsingPattern(long rocksToDrop)
        {
            FindPattern();
            long height = Pattern.StartHeight;
            rocksToDrop -= Pattern.StartRock;
            height += (rocksToDrop / (long)Pattern.RockCountPattern) * (long)Pattern.HeightPattern;
            int remainingRocks = (int)(rocksToDrop % (long)Pattern.RockCountPattern);
            if (remainingRocks != 0)
            {
                height += Pattern.GetRemainder(remainingRocks);
            }

            return height;
        }

        private bool DropRock()
        {
            if (Rock == null)
            {
                if (_nextRockType == 0)
                {
                    Pattern.Attribs.Add(new RockFallPatternAttribs
                    {
                        Height = RockHeightFromBottom,
                        WindPos = _windPos,
                        RockCount = RockCount
                    });
                }

                NextRock();
                RockCount++;
                return true;
            }

            return false;
        }

        private void NextRock()
        {
            Rock = _rocks[_nextRockType].Select(s => new Spot(s.X, RockDepth + s.Y)).ToArray();
            _nextRockType++;
            if (_nextRockType >= _rocks.Count)
            {
                _nextRockType = 0;
            }
        }

        private void ApplyWind()
        {
            var wind = Wind[_windPos++] == '<' ? -1 : 1;
            if (_windPos >= Wind.Length)
            {
                _windPos = 0;
            }

            if (Rock == null)
            {
                throw new Exception("No Rock for wind!");
            }

            var rock = Rock.Select(r => new Spot(r.X + wind, r.Y)).ToArray();
            if (rock.Any(s => s.X < 0 || s.X >= Width || this[s] != '.'))
            {
                return;
            }

            Rock = rock;
        }

        private void ApplyDrop()
        {
            if (Rock == null)
            {
                throw new Exception("No Rock for wind!");
            }

            var rock = Rock.Select(r => new Spot(r.X, r.Y + 1)).ToArray();
            if (rock.Any(s => s.Y >= Height || this[s] != '.'))
            {
                foreach (var spot in Rock)
                {
                    this[spot] = '#';
                    if (spot.Y < RockDepth) RockDepth = spot.Y;
                }

                Rock = null;
                return;
            }

            Rock = rock;
        }

        private void Display(int lastRows)
        {
            var start = _caveDepth - lastRows;
            var map = Rows(start, _caveDepth - 1);
            if (Rock != null)
            {
                foreach (var spot in Rock)
                {
                    if (spot.Y - start > 0)
                    {
                        map[spot.X, spot.Y - start] = '@';
                    }
                }
            }

            Console.WriteLine(map);
        }
    }

    public class RockFallPattern
    {
        public List<RockFallPatternAttribs> Attribs { get; set; } = new();
        public bool IsPatternFound { get; set; }
        public int StartHeight { get; set; }
        public int HeightPattern { get; set; }
        public int StartRock { get; set; }
        public int RockCountPattern { get; set; }
        public int StartAttribute { get; set; }
        public int AttributePattern { get; set; }

        public void TryFindPattern()
        {
            for (int a = 1; a < Attribs.Count - 2; a++)
            {
                for (int b = a - 1; b >= 0; b--)
                {
                    if (Attribs[a].WindPos == Attribs[b].WindPos && Attribs[a + 1].WindPos == Attribs[b + 1].WindPos && Attribs[a + 2].WindPos == Attribs[b + 2].WindPos)
                    {
                        StartHeight = Attribs[b].Height;
                        HeightPattern = Attribs[a].Height - Attribs[b].Height;
                        StartRock = Attribs[b].RockCount;
                        RockCountPattern = Attribs[a].RockCount - Attribs[b].RockCount;
                        StartAttribute = b;
                        AttributePattern = a - b;
                        IsPatternFound = true;
                        break;
                    }
                }
            }
        }

        public int GetRemainder(int remainingRocks) => Attribs[StartAttribute + (remainingRocks / 5)].Height - StartHeight;
    }

    public class RockFallPatternAttribs
    {
        public int WindPos { get; set; }
        public int Height { get; set; }
        public int RockCount { get; set; }
    }
}
