using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class BeaconCave
    {
        private List<Sensor> _sensors;

        public BeaconCave(string input)
        {
            _sensors = input.Split("\r\n").Select(i => new Sensor(i)).ToList();
        }

        public int FindExcludedForRow(int row)
        {
            var rowCoverage = GetCoverageForRow(row);
            var beaconsInRow = _sensors.Where(s => s.NearestBeacon.Y == row).Select(s => s.NearestBeacon).Distinct().Count();
            var totalCovered = rowCoverage.GetCoverage();

            return totalCovered - beaconsInRow;
        }

        private CoverageGroup GetCoverageForRow(int row)
        {
            var coverageGroup = new CoverageGroup();
            foreach (var sensor in _sensors)
            {
                var exclusion = sensor.GetRowCoverage(row);
                if (exclusion.Start <= exclusion.End)
                {
                    coverageGroup.Add(exclusion);
                }
            }

            return coverageGroup;
        }

        public long GetBeaconTuningFrequencyForMaxCoords(int maxCoords, int startAt = 0)
        {
            for (int row = startAt; row < maxCoords; row++)
            {
                var rowCoverage = GetCoverageForRow(row).Coverage.FirstOrDefault();
                if (rowCoverage != null)
                {
                    if (rowCoverage.Start > 0)
                    {
                        return Frequency(0, row);
                    }
                    else if (rowCoverage.End < maxCoords)
                    {
                        Console.WriteLine($"{rowCoverage.End + 1}, {row}");
                        return Frequency(rowCoverage.End + 1, row);
                    }
                }
            }

            return 0;
        }

        private long Frequency(long x, long y) => x * 4000000 + y;
    }

    public class Sensor
    {
        public Sensor(string input)
        {
            SensorLocation = new Spot(input.ParseAfter<int>("Sensor at x="), input.ParseAfter<int>(", y="));
            NearestBeacon = new Spot(input.ParseAfter<int>("closest beacon is at x="), input.ParseAfter<int>(", y=", 25));
        }

        public Spot SensorLocation { get; set; }
        public Spot NearestBeacon { get; set; }

        public int CubicRadius => Math.Abs(SensorLocation.X - NearestBeacon.X) + Math.Abs(SensorLocation.Y - NearestBeacon.Y);

        public Coverage GetRowCoverage(int row)
        {
            int start = SensorLocation.X - CubicRadius;
            int end = SensorLocation.X + CubicRadius;
            int rowDistance = Math.Abs(SensorLocation.Y - row);
            return new Coverage(start + rowDistance, end - rowDistance);
        }
    }

    public record Coverage(int Start, int End);

    public class CoverageGroup
    {
        private List<Coverage> _coverages = new();

        public IReadOnlyList<Coverage> Coverage => _coverages;

        public void Add(Coverage coverage)
        {
            _coverages.Add(coverage);


            var didCondense = true;
            _coverages = _coverages.OrderBy(c => c.Start).ToList();
            while (didCondense)
            {
                didCondense = false;
                int n = 1;
                while (n < _coverages.Count)
                {
                    // left is totally contained
                    if (_coverages[n - 1].Start >= _coverages[n].Start && _coverages[n - 1].End <= _coverages[n].End)
                    {
                        _coverages.RemoveAt(n - 1);
                        didCondense = true;
                        continue;
                    }

                    // right is totally contained
                    if (_coverages[n - 1].Start <= _coverages[n].Start && _coverages[n - 1].End >= _coverages[n].End)
                    {
                        _coverages.RemoveAt(n);
                        didCondense = true;
                        continue;
                    }

                    // left extends start of right
                    if (_coverages[n - 1].Start < _coverages[n].Start && _coverages[n - 1].End >= _coverages[n].Start && _coverages[n - 1].End <= _coverages[n].End)
                    {
                        _coverages[n] = new Coverage(_coverages[n - 1].Start, _coverages[n].End);
                        _coverages.RemoveAt(n - 1);
                        didCondense = true;
                        continue;
                    }

                    // left extends end of right
                    if (_coverages[n - 1].Start >= _coverages[n].Start && _coverages[n - 1].End > _coverages[n].End)
                    {
                        _coverages[n] = new Coverage(_coverages[n].Start, _coverages[n - 1].End);
                        _coverages.RemoveAt(n - 1);
                        didCondense = true;
                        continue;
                    }

                    n++;
                    _coverages = _coverages.OrderBy(c => c.Start).ToList();
                }
            }
        }

        public int GetCoverage() => _coverages.Sum(g => g.End - g.Start + 1);

        public override string ToString() => string.Join("->", _coverages.Select(c => $"({c.Start}, {c.End})"));
    }
}
