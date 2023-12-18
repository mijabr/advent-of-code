using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public abstract class SeedMapper
    {
        public static SeedMapper Create(string input, bool rangedSeedInput = false)
        {
            var sections = input.Split("\r\n\r\n");
            if (rangedSeedInput)
            {
                return new RangedSeedMapper(sections);
            }
            else
            {
                return new SimpleSeedMapper(sections);
            }
        }

        protected SeedMapper(string[] sections)
        {
            Maps = sections
                .Skip(1)
                .Select(s =>
                {
                    var rows = s.Split("\r\n");
                    var typeParts = rows[0].Split(' ')[0].Split('-');
                    var from = typeParts[0];
                    var to = typeParts[2];
                    return KeyValuePair.Create(from, new SeedRangeMap(from, to, rows.Skip(1)));
                })
                .ToDictionary(kv => kv.Key, kv => kv.Value);

        }

        public Dictionary<string, SeedRangeMap> Maps { get; private set; }
        public abstract object SourceSeeds { get; }
        public abstract long Lowest(string type);
    }

    public class SimpleSeedMapper : SeedMapper
    {
        internal SimpleSeedMapper(string[] sections) : base(sections)
        {
            _sourceSeeds = sections[0].Split(':')[1].ParseNumbers<long>();
        }

        private List<long> _sourceSeeds;
        public override object SourceSeeds => _sourceSeeds;

        public override long Lowest(string type) =>
            _sourceSeeds.Min(seed =>
            {
                var value = seed;
                var map = Maps["seed"];
                while (map.To != type)
                {
                    value = map.Convert(value);
                    map = Maps[map.To];
                }

                return map.Convert(value);
            });
    }

    public class RangedSeedMapper : SeedMapper
    {
        internal RangedSeedMapper(string[] sections) : base(sections)
        {
            var numbers = sections[0].Split(':')[1].ParseNumbers<long>();
            _sourceSeeds = new List<SeedRange>();
            for (int i = 0; i < numbers.Count; i += 2)
            {
                _sourceSeeds.Add(new SeedRange(numbers[i], numbers[i + 1]));
            }
        }

        private List<SeedRange> _sourceSeeds;
        public override object SourceSeeds => _sourceSeeds;

        public override long Lowest(string type)
        {
            long lowestValue = long.MaxValue;

            foreach (var seedRange in _sourceSeeds)
            {
                long seed = seedRange.StartSeed;
                while (seed <= seedRange.EndSeed)
                {
                    var value = seed;
                    var minCeiling = long.MaxValue;
                    var map = Maps["seed"];
                    while (map.To != type)
                    {
                        var oldValue = value;
                        value = map.ConvertWithCeiling(value, out var ceiling2);
                        minCeiling = Math.Min(ceiling2, minCeiling);
                        map = Maps[map.To];
                    }

                    value = map.ConvertWithCeiling(value, out var ceiling);
                    lowestValue = Math.Min(lowestValue, value);
                    minCeiling = Math.Min(ceiling, minCeiling);

                    seed += Math.Max(1, minCeiling);
                }
            }

            return lowestValue;
        }
    }

    public class SeedRangeMap
    {
        public SeedRangeMap(string from, string to, IEnumerable<string> input)
        {
            From = from;
            To = to;
            RangeMapSegements = input
                .Select(i =>
                {
                    var numbers = i.ParseNumbers<long>();
                    return new RangeMapSegement(numbers[0], numbers[1], numbers[2]);
                })
                .ToList();
        }

        public string From { get; set; }
        public string To { get; set; }
        public List<RangeMapSegement> RangeMapSegements { get; private set; }

        public long Convert(long sourceValue)
        {
            foreach (var segment in RangeMapSegements)
            {
                if (segment.SourceRange <= sourceValue && segment.SourceRange + segment.RangeLength > sourceValue)
                {
                    return segment.DestinationRange + (sourceValue - segment.SourceRange);
                }
            }

            return sourceValue;
        }

        public long ConvertWithCeiling(long sourceValue, out long ceiling)
        {
            foreach (var segment in RangeMapSegements)
            {
                if (segment.SourceRange <= sourceValue && segment.SourceRange + segment.RangeLength > sourceValue)
                {
                    ceiling = segment.SourceRangeEnd - sourceValue;
                    return segment.DestinationRange + (sourceValue - segment.SourceRange);
                }
            }

            var remainingSegments = RangeMapSegements.Where(r => r.SourceRange > sourceValue);
            ceiling = remainingSegments.Any() ? (remainingSegments.Min(r => r.SourceRange) - sourceValue) : long.MaxValue;

            return sourceValue;
        }
    }

    public record RangeMapSegement(long DestinationRange, long SourceRange, long RangeLength)
    {
        public long SourceRangeEnd => SourceRange + RangeLength;
    }
    public record SeedRange(long StartSeed, long RangeLength)
    {
        public long EndSeed => StartSeed + RangeLength - 1;
    }
}
