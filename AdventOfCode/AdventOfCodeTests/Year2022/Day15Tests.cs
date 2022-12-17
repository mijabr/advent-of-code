using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class Day15Tests
    {
        [Test]
        public void Sensor_ShouldInitialseTheSensor()
        {
            var sensor = new Sensor("Sensor at x=8, y=7: closest beacon is at x=2, y=10");

            sensor.SensorLocation.Should().Be(new Spot(8, 7));
            sensor.NearestBeacon.Should().Be(new Spot(2, 10));
            sensor.CubicRadius.Should().Be(9);
            sensor.GetRowCoverage(7).Should().BeEquivalentTo(new Coverage(-1, 17));
            sensor.GetRowCoverage(10).Should().BeEquivalentTo(new Coverage(2, 14));
            sensor.GetRowCoverage(18).Should().BeEquivalentTo(new Coverage(10, 6));
        }

        [Test]
        public void AddCoverage_ShouldAddCoverageBefore()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(5, 8));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(5, 8),
                new Coverage(10, 20)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldJoinWithFirstCoverage()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(5, 10));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(5, 20)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldJoinWithMultipleCoverages()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(25, 30));
            coverageGroup.Add(new Coverage(5, 26));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(5, 30)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldExtendEndOfExisting()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(15, 30));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(10, 30)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldIgnoreTotallyEncapsulated()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(12, 18));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(10, 20)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldCheckEnd_row11example()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 13));
            coverageGroup.Add(new Coverage(15, 25));

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(10, 13),
                new Coverage(15, 25)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void AddCoverage_ShouldCheckEnJoinTwoInTheMiddle_row10example()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(-2, 14));
            Console.WriteLine(coverageGroup.ToString());
            coverageGroup.Add(new Coverage(16, 24));
            Console.WriteLine(coverageGroup.ToString());
            coverageGroup.Add(new Coverage(14, 18));
            Console.WriteLine(coverageGroup.ToString());

            coverageGroup.Coverage.Should().BeEquivalentTo(new List<Coverage>
            {
                new Coverage(-2, 24)
            }, cfg => cfg.WithStrictOrdering());
        }

        [Test]
        public void GetCoverage_ShouldReturnTheTotalCoverage()
        {
            var coverageGroup = new CoverageGroup();

            coverageGroup.Add(new Coverage(10, 20));
            coverageGroup.Add(new Coverage(15, 30));
            coverageGroup.Add(new Coverage(20, 40));

            coverageGroup.GetCoverage().Should().Be(31);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForExample1_row9()
        {
            var becaonFinder = new BeaconCave(_exampleInput);

            var result = becaonFinder.FindExcludedForRow(9);

            result.Should().Be(25);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForExample1_row11()
        {
            var becaonFinder = new BeaconCave(_exampleInput);

            var result = becaonFinder.FindExcludedForRow(11);

            result.Should().Be(28);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForExample1()
        {
            var becaonFinder = new BeaconCave(_exampleInput);

            var result = becaonFinder.FindExcludedForRow(10);

            result.Should().Be(26);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForPart1()
        {
            var thing = new BeaconCave(_puzzleInput);

            var result = thing.FindExcludedForRow(2000000);

            result.Should().Be(5299855);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForExample2()
        {
            var becaonFinder = new BeaconCave(_exampleInput);

            var result = becaonFinder.GetBeaconTuningFrequencyForMaxCoords(20);

            result.Should().Be(56000011);
        }

        [Test]
        public void FindExcludedForRow_ShouldFindThePuzzleAnswerForPart2()
        {
            var becaonFinder = new BeaconCave(_puzzleInput);

            var result = becaonFinder.GetBeaconTuningFrequencyForMaxCoords(4000000, startAt: 3289729);

            result.Should().Be(13615843289729);
        }

        private const string _exampleInput = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15\r\nSensor at x=9, y=16: closest beacon is at x=10, y=16\r\nSensor at x=13, y=2: closest beacon is at x=15, y=3\r\nSensor at x=12, y=14: closest beacon is at x=10, y=16\r\nSensor at x=10, y=20: closest beacon is at x=10, y=16\r\nSensor at x=14, y=17: closest beacon is at x=10, y=16\r\nSensor at x=8, y=7: closest beacon is at x=2, y=10\r\nSensor at x=2, y=0: closest beacon is at x=2, y=10\r\nSensor at x=0, y=11: closest beacon is at x=2, y=10\r\nSensor at x=20, y=14: closest beacon is at x=25, y=17\r\nSensor at x=17, y=20: closest beacon is at x=21, y=22\r\nSensor at x=16, y=7: closest beacon is at x=15, y=3\r\nSensor at x=14, y=3: closest beacon is at x=15, y=3\r\nSensor at x=20, y=1: closest beacon is at x=15, y=3";

        private const string _puzzleInput = "Sensor at x=3772068, y=2853720: closest beacon is at x=4068389, y=2345925\r\nSensor at x=78607, y=2544104: closest beacon is at x=-152196, y=4183739\r\nSensor at x=3239531, y=3939220: closest beacon is at x=3568548, y=4206192\r\nSensor at x=339124, y=989831: closest beacon is at x=570292, y=1048239\r\nSensor at x=3957534, y=2132743: closest beacon is at x=3897332, y=2000000\r\nSensor at x=1882965, y=3426126: closest beacon is at x=2580484, y=3654136\r\nSensor at x=1159443, y=3861139: closest beacon is at x=2580484, y=3654136\r\nSensor at x=2433461, y=287013: closest beacon is at x=2088099, y=-190228\r\nSensor at x=3004122, y=3483833: closest beacon is at x=2580484, y=3654136\r\nSensor at x=3571821, y=799602: closest beacon is at x=3897332, y=2000000\r\nSensor at x=2376562, y=1539540: closest beacon is at x=2700909, y=2519581\r\nSensor at x=785113, y=1273008: closest beacon is at x=570292, y=1048239\r\nSensor at x=1990787, y=38164: closest beacon is at x=2088099, y=-190228\r\nSensor at x=3993778, y=3482849: closest beacon is at x=4247709, y=3561264\r\nSensor at x=3821391, y=3986080: closest beacon is at x=3568548, y=4206192\r\nSensor at x=2703294, y=3999015: closest beacon is at x=2580484, y=3654136\r\nSensor at x=1448314, y=2210094: closest beacon is at x=2700909, y=2519581\r\nSensor at x=3351224, y=2364892: closest beacon is at x=4068389, y=2345925\r\nSensor at x=196419, y=3491556: closest beacon is at x=-152196, y=4183739\r\nSensor at x=175004, y=138614: closest beacon is at x=570292, y=1048239\r\nSensor at x=1618460, y=806488: closest beacon is at x=570292, y=1048239\r\nSensor at x=3974730, y=1940193: closest beacon is at x=3897332, y=2000000\r\nSensor at x=2995314, y=2961775: closest beacon is at x=2700909, y=2519581\r\nSensor at x=105378, y=1513086: closest beacon is at x=570292, y=1048239\r\nSensor at x=3576958, y=3665667: closest beacon is at x=3568548, y=4206192\r\nSensor at x=2712265, y=2155055: closest beacon is at x=2700909, y=2519581";
    }
}
