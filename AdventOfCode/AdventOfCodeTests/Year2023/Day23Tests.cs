using AdventOfCode.Util;
using AdventOfCode.Year2023;
using AdventOfCodeTests.Util;

namespace AdventOfCodeTests.Year2023
{
    public class Day23Tests
    {
        [Test]
        public void HikeTrailMapper_CanReadInput()
        {
            var hikeTrailMap = new HikeTrailMapper(exampleInput1);

            hikeTrailMap.HikeMap.Map[3, 4].Should().Be('v');
            hikeTrailMap.HikeMap.Map[1, 0].Should().Be('O');
            hikeTrailMap.HikeMap.Steps.Should().Be(1);
            hikeTrailMap.End.Should().Be(new Spot(21, 22));
            hikeTrailMap.HikeMap.Map[21, 22].Should().Be('E');
        }

        [Test]
        public void HikeTrailMapper_CanSolveExample1()
        {
            var hikeTrailMap = new HikeTrailMapper(exampleInput1);

            var longestHike = hikeTrailMap.FindLongestHike_Old();
            longestHike.ShouldNotBeNull();
            longestHike.Steps.Should().Be(94);
        }

        [Test]
        public void HikeTrailMapper_CanSolvePart1()
        {
            var hikeTrailMap = new HikeTrailMapper(input);

            var longestHike = hikeTrailMap.FindLongestHike_Old();
            longestHike.ShouldNotBeNull();
            longestHike.Steps.Should().Be(2502);
        }

        [Test]
        public void HikeTrailMapper_CanSolveExample1Part2()
        {
            var hikeTrailMap = new HikeTrailMapper(exampleInput1);

            var longestHike = hikeTrailMap.FindLongestHike_Old(canClimbSlopes: true);
            longestHike.ShouldNotBeNull();
            longestHike.Steps.Should().Be(154);
        }

        [Test]
        public void HikeTrailMapperSuper_CanConstructTrailNodes()
        {
            var hikeTrailMapper = new HikeTrailMapperSuper(exampleInput1);

            hikeTrailMapper.HikeTrailNodes[new Spot(1, 0)].ShouldConnectTo(new NodeConnection(new Spot(3, 5), 15));
            hikeTrailMapper.HikeTrailNodes[new Spot(3, 5)].ShouldConnectTo(new NodeConnection(new Spot(11, 3), 22), new NodeConnection(new Spot(1, 0), 15), new NodeConnection(new Spot(5, 13), 22));
            hikeTrailMapper.HikeTrailNodes[new Spot(19, 19)].ShouldConnectTo(new NodeConnection(new Spot(13, 19), 10), new NodeConnection(new Spot(21, 11), 10), new NodeConnection(new Spot(21, 22), 5));
            hikeTrailMapper.HikeTrailNodes.Count.Should().Be(9);
        }

        [Test]
        public void HikeTrailMapperSuper_CanConstructTrailNodesForPart2()
        {
            var hikeTrailMapper = new HikeTrailMapperSuper(input);

            hikeTrailMapper.HikeTrailNodes.Count.Should().Be(36);
        }

        [Test]
        public void HikeTrailMapperSuper_CanColveExample1Part2()
        {
            var hikeTrailMapper = new HikeTrailMapperSuper(exampleInput1);

            hikeTrailMapper.FindLongestHike().Should().Be(154);
        }

        [Test]
        [Ignore("Slow, 36s")]
        public void HikeTrailMapperSuper_CanColvePart2()
        {
            var hikeTrailMapper = new HikeTrailMapperSuper(input);

            hikeTrailMapper.FindLongestHike().Should().Be(6726);
        }

        const string exampleInput1 = "#.#####################\r\n#.......#########...###\r\n#######.#########.#.###\r\n###.....#.>.>.###.#.###\r\n###v#####.#v#.###.#.###\r\n###.>...#.#.#.....#...#\r\n###v###.#.#.#########.#\r\n###...#.#.#.......#...#\r\n#####.#.#.#######.#.###\r\n#.....#.#.#.......#...#\r\n#.#####.#.#.#########v#\r\n#.#...#...#...###...>.#\r\n#.#.#v#######v###.###v#\r\n#...#.>.#...>.>.#.###.#\r\n#####v#.#.###v#.#.###.#\r\n#.....#...#...#.#.#...#\r\n#.#########.###.#.#.###\r\n#...###...#...#...#.###\r\n###.###.#.###v#####v###\r\n#...#...#.#.>.>.#.>.###\r\n#.###.###.#.###.#.#v###\r\n#.....###...###...#...#\r\n#####################.#";
        const string input = "#.###########################################################################################################################################\r\n#...#.....#.....................#...#.........###...###...###...#...#.......#...###.....#...#.......###.........#...........#.............###\r\n###.#.###.#.###################.#.#.#.#######.###.#.###.#.###.#.#.#.#.#####.#.#.###.###.#.#.#.#####.###.#######.#.#########.#.###########.###\r\n#...#...#...###...#.............#.#.#.......#.....#...#.#.#...#...#.#.....#.#.#...#...#...#...#...#.#...#.......#.........#.#.#.........#...#\r\n#.#####.#######.#.#.#############.#.#######.#########.#.#.#.#######.#####.#.#.###.###.#########.#.#.#.###.###############.#.#.#.#######.###.#\r\n#.......###...#.#.#...............#...#.....#.........#.#...#.......#.....#...#...###.....#...#.#...#...#.#...###...###...#.#.#.#...###.....#\r\n###########.#.#.#.###################.#.#####.#########.#####.#######.#########.#########.#.#.#.#######.#.#.#.###.#.###.###.#.#.#.#.#########\r\n#.........#.#...#.....................#.....#.###.....#.....#...#...#.......#...#...#####...#.#.#...###.#.#.#.....#...#.#...#.#...#.........#\r\n#.#######.#.###############################.#.###.###.#####.###.#.#.#######.#.###.#.#########.#.#.#.###.#.#.#########.#.#.###.#############.#\r\n#.......#...#.....###.....#...###.....###...#...#.#...#...#.#...#.#.....#...#...#.#.###...#...#...#.#...#.#.#.....#...#.#...#.#.............#\r\n#######.#####.###.###.###.#.#.###.###.###.#####.#.#.###.#.#.#.###.#####.#.#####.#.#.###.#.#.#######.#.###.#.#.###.#.###.###.#.#.#############\r\n#.....#.....#.#...#...#...#.#...#...#...#.#...#...#...#.#.#.#...#.....#.#.#.....#.#.###.#.#...#.....#...#.#...#...#.###.#...#.#.......#...###\r\n#.###.#####.#.#.###.###.###.###.###.###.#.#.#.#######.#.#.#.###.#####.#.#.#.#####.#.###.#.###.#.#######.#.#####.###.###.#.###.#######.#.#.###\r\n#...#.......#.#...#...#...#.#...###...#.#.#.#.........#.#.#.#...#...#.#.#.#.###...#.#...#.....#.###...#.#.#...#...#...#.#...#.#.......#.#.###\r\n###.#########.###.###.###.#.#.#######.#.#.#.###########.#.#.#.###.#.#.#.#.#.###.###.#.#########.###.#.#.#.#.#.###.###.#.###.#.#.#######.#.###\r\n###.....#...#.#...###...#.#.#.#.>.>...#.#.#...#.......#.#.#.#.###.#.#.#.#.#.###.#...#.........#...#.#.#.#...#.>.>.#...#...#.#.#.....#...#...#\r\n#######.#.#.#.#.#######.#.#.#.#.#v#####.#.###.#.#####.#.#.#.#.###.#.#.#.#.#.###.#.###########.###.#.#.#.#######v###.#####.#.#.#####.#.#####.#\r\n#...###...#...#.#.....#.#.#.#.#.#.#...#...#...#...#...#.#.#.#.###.#.#.#.#.#.###.#.#...###...#...#.#.#.#.#.....#.#...#...#.#.#.#.....#...#...#\r\n#.#.###########v#.###.#.#.#.#.#.#.#.#.#####.#####.#.###.#.#.#.###.#.#.#.#.#.###.#.#.#.###.#.###.#.#.#.#.#.###.#.#.###.#.#.#.#.#.#######.#.###\r\n#.#.....#...###.>.###.#.#.#.#.#.#.#.#...###.....#.#.#...#.#.#.>.>.#.#.#.#.#...#.#.#.#.>.>.#...#.#.#.#...#...#.#.#...#.#.#.#.#.#...###...#...#\r\n#.#####.#.#.###v#####.#.#.#.#.#.#.#.###.#######.#.#.#.###.#.###v###.#.#.#.###.#.#.#.###v#####.#.#.#.#######.#.#.###.#.#.#.#.#.###.###.#####.#\r\n#.#...#...#.#...###...#.#.#.#.#.#.#.#...#.....#.#.#.#...#.#...#...#...#.#.###.#.#.#.#...#...#...#...###.....#.#...#.#.#.#.#.#.###...#.#.....#\r\n#.#.#.#####.#.#####.###.#.#.#.#.#.#.#.###.###.#.#.#.###.#.###.###.#####.#.###.#.#.#.#.###.#.###########.#####.###.#.#.#.#.#.#.#####.#.#.#####\r\n#...#.....#.#.....#.#...#.#.#.#.#.#.#.....#...#...#...#.#.#...###...#...#...#...#...#...#.#.###...#...#.....#...#.#.#.#.#.#...###...#.#.....#\r\n#########.#.#####.#.#.###.#.#.#.#.#.#######.#########.#.#.#.#######.#.#####.###########.#.#.###.#.#.#.#####.###.#.#.#.#.#.#######.###.#####.#\r\n###...###.#.#...#.#.#.#...#.#.#.#...###...#.....#.....#.#.#.#.......#.......#.....#.....#.#.#...#...#...#...###.#.#.#.#...###...#...#.#.....#\r\n###.#.###.#.#.#.#.#.#.#.###.#.#.#######.#.#####.#.#####.#.#.#.###############.###.#.#####.#.#.#########.#.#####.#.#.#.#######.#.###.#.#.#####\r\n#...#.#...#...#...#...#.#...#...#.......#.......#.......#...#.....#.......###...#.#.......#.#.........#...#...#.#.#.#.....#...#.....#.#.#...#\r\n#.###.#.###############.#.#######.###############################.#.#####.#####.#.#########.#########.#####.#.#.#.#.#####.#.#########.#.#.#.#\r\n#...#.#...............#...#...###.....#.......#.....#.....#.....#...#.....#.....#.........#.#...#...#.#...#.#.#...#.#...#.#...........#...#.#\r\n###.#.###############.#####.#.#######.#.#####.#.###.#.###.#.###.#####.#####.#############.#.#.#.#.#.#v#.#.#.#.#####.#.#.#.#################.#\r\n#...#...#...#.....#...#...#.#.###...#...#.....#...#.#.#...#...#.#.....#####...........###.#.#.#...#.>.>.#...#...###...#...###...#.........#.#\r\n#.#####.#.#.#.###.#.###.#.#.#.###.#.#####.#######.#.#.#.#####.#.#v###################.###.#.#.#######v#########.#############.#.#.#######.#.#\r\n#.#...#...#.#.###...#...#...#...#.#.#...#.......#.#...#...#...#.>.>.....#.......#...#...#.#.#.......#.....#.....#...#...#.....#.#.......#.#.#\r\n#.#.#.#####.#.#######.#########.#.#.#.#.#######.#.#######.#.#####v#####.#.#####.#.#.###.#.#.#######.#####.#.#####.#.#.#.#.#####.#######.#.#.#\r\n#.#.#.#...#...#...###.......#...#.#.#.#.###.....#.......#.#...#...#.....#.....#...#.....#...#...###...#...#...###.#...#.#.....#.........#.#.#\r\n#.#.#v#.#.#####.#.#########.#.###.#.#.#.###.###########.#.###.#.###.#########.###############.#.#####.#.#####.###.#####.#####.###########.#.#\r\n#.#.#.>.#.###...#...#...#...#...#.#.#.#...#.....#...#...#.....#...#.#.....###.............#...#.......#...###.#...#.....#...#...........#.#.#\r\n#.#.#v###.###.#####.#.#.#.#####.#.#.#.###.#####.#.#.#.###########.#.#.###.###############.#.#############.###.#.###.#####.#.###########.#.#.#\r\n#.#.#...#...#.....#.#.#.#.#.....#.#.#...#.#.....#.#...#.......#...#.#.#...#...#...#.......#.............#...#...###.#...#.#.#...#.......#...#\r\n#.#.###.###.#####.#.#.#.#.#.#####.#.###.#.#v#####.#####.#####.#.###.#.#.###.#.#.#.#.###################.###.#######.#.#.#.#.#.#.#.###########\r\n#.#.###...#.....#.#.#.#.#.#.#...#.#...#.#.>.>...#.......#.....#...#.#.#.###.#.#.#.#...###...#...#.....#...#...#.....#.#.#.#.#.#.#...#...#...#\r\n#.#.#####.#####.#.#.#.#.#.#.#.#.#.###.#.###v###.#########.#######.#.#.#.###.#.#.#.###v###.#.#.#.#.###.###.###.#.#####.#.#.#.#.#.###v#.#.#.#.#\r\n#...#.....#...#...#...#.#.#.#.#.#...#.#.###...#.#...#...#...###...#...#...#.#.#.#...>.>.#.#.#.#.#.###.....#...#.....#.#.#.#.#.#.#.>.#.#...#.#\r\n#####.#####.#.#########.#.#.#.#.###.#.#.#####.#.#.#.#.#.###.###.#########.#.#.#.#####v#.#.#.#.#.#.#########.#######.#.#.#.#.#.#.#.#v#.#####.#\r\n#.....#...#.#.#.......#.#.#...#.#...#...#.....#...#...#.#...#...#...#####...#.#.###...#.#.#.#.#.#.#.......#.......#.#.#.#.#...#...#...#...#.#\r\n#.#####.#.#.#.#.#####.#.#.#####.#.#######.#############.#.###.###.#.#########.#.###.###.#.#.#.#.#.#.#####.#######.#.#.#.#.#############.#.#.#\r\n#.......#...#...#.....#...#.....#.###...#...........###.#.#...#...#.........#...#...###...#.#.#.#.#.....#.......#.#...#...#.............#...#\r\n#################.#########.#####.###.#.###########.###.#.#.###.###########.#####.#########.#.#.#.#####.#######.#.#########.#################\r\n#.............#...#...#...#.#.....#...#...#.........#...#.#...#.#.......#...###...#.......#.#.#.#.#...#.......#...#.......#.................#\r\n#.###########.#.###.#.#.#.#.#.#####.#####.#.#########.###.###.#.#.#####.#.#####.###.#####.#.#.#.#.#.#.#######.#####.#####.#################.#\r\n#...........#...###.#.#.#.#...#...#.....#...#...#...#...#...#...#.....#.#.#.....###.#.....#...#.#.#.#.........###...#...#...#...............#\r\n###########.#######.#.#.#.#####.#.#####.#####.#.#.#.###.###.#########.#.#.#.#######.#.#########.#.#.#############.###.#.###.#.###############\r\n#...........#.......#...#.#...#.#.#...#.......#...#...#.#...###.......#...#.........#...###...#...#.............#...#.#.....#...........#...#\r\n#.###########.###########.#.#.#.#.#.#.###############.#.#.#####.#######################.###.#.#################.###.#.#################.#.#.#\r\n#...#.........#...........#.#.#.#.#.#.#...#.........#.#...#...#.........#.............#...#.#.#...#.........#...###.#.....#...#...###...#.#.#\r\n###.#.#########.###########.#.#.#.#.#.#.#.#.#######.#.#####.#.#########.#.###########.###.#.#.#.#.#.#######.#.#####.#####.#.#.#.#.###v###.#.#\r\n###.#.#.....#...#...#.....#.#.#.#.#.#.#.#...#...###...#...#.#.#...#.....#...........#.#...#.#...#.#.....#...#.....#...#...#.#.#.#.#.>.###.#.#\r\n###.#.#.###.#.###.#v#.###.#.#.#.#.#.#.#.#####.#.#######.#.#.#.#.#.#.###############.#.#.###.#####.#####.#.#######.###.#.###.#.#.#.#.#v###.#.#\r\n#...#.#...#...#...#.>.#...#.#.#.#.#.#.#.......#.....#...#.#.#...#...#.......#.......#...#...#.....###...#.........#...#.#...#.#.#.#.#.....#.#\r\n#.###.###.#####.###v###.###.#.#.#.#.#.#############.#.###.#.#########.#####.#.###########.###.#######.#############.###.#.###.#.#.#.#######.#\r\n#.....###.......#...###...#.#.#.#.#.#.###...........#...#.#...........#.....#...#.....###...#.#.....#.#...#.....#...#...#...#...#...#.....#.#\r\n#################.#######.#.#.#.#.#.#.###.#############.#.#############.#######.#.###.#####.#.#.###.#.#.#.#.###.#.###.#####.#########.###.#.#\r\n#.................###.....#.#.#.#.#.#...#...#.........#.#...#...........#...###.#.#...#...#.#.#.#...#...#...#...#...#.#.....#...#.....#...#.#\r\n#.###################.#####.#.#.#.#.###.###v#.#######.#.###.#.###########.#.###v#.#.###.#.#.#.#.#.###########.#####.#.#.#####.#.#.#####.###.#\r\n#...................#.......#.#.#.#...#...>.>.#.......#.#...#.......#...#.#.#.>.>.#.###.#.#.#.#.#.###...#...#.###...#.#...#...#.#.....#...#.#\r\n###################.#########.#.#.###.#####v###.#######.#.#########v#.#.#.#.#.#v###.###.#.#.#.#.#.###.#.#.#.#v###.###.###.#.###.#####.###.#.#\r\n#...................###.....#.#.#.#...#.....###.#.....#.#.......#.>.>.#.#.#.#.#...#.#...#.#.#...#.....#...#.>.>.#...#.#...#...#.#...#...#.#.#\r\n#.#####################.###.#.#.#.#.###.#######.#.###.#.#######.#.#v###.#.#.#.###.#.#.###.#.#################v#.###.#.#.#####.#.#.#.###.#.#.#\r\n#.....................#...#.#...#...###.#.....#.#.###.#.....###...#...#.#.#...###.#...###.#.......#.........#.#.#...#...#...#.#.#.#.#...#.#.#\r\n#####################.###.#.###########.#.###.#.#.###.#####.#########.#.#.#######.#######.#######.#.#######.#.#.#.#######.#.#.#.#.#.#.###.#.#\r\n#.....................#...#.#...#.....#...#...#.#.#...#.....#...#...#.#.#.#.......###...#.........#.......#.#.#...#.....#.#...#.#.#...#...#.#\r\n#.#####################.###.#.#.#.###.#####.###.#.#.###.#####.#.#.#.#.#.#.#.#########.#.#################.#.#.#####.###.#.#####.#.#####.###.#\r\n#.........#...#...#...#...#.#.#.#...#.#...#.###.#.#.....#.....#.#.#...#.#.#...........#.........#.......#.#...#...#.#...#.....#...#...#.....#\r\n#########.#.#.#.#v#.#.###.#.#.#.###.#.#.#.#v###.#.#######.#####.#.#####.#.#####################.#.#####.#.#####.#.#.#.#######v#####.#.#######\r\n#.......#...#...#.>.#...#.#.#.#.#...#.#.#.>.>.#...#...###...###.#.....#...#####.................#.....#...#...#.#.#.#.....#.>.#...#.#.#...###\r\n#.#####.#########v#####.#.#.#.#.#.###.#.###v#.#####.#.#####.###.#####.#########.#####################.#####.#.#.#.#.#####.#.#v#.#.#.#.#.#.###\r\n#.....#.###...#...#####.#.#...#.#...#...###.#...#...#.#...#...#.......###...#...#...###...#...###...#.###...#.#.#.#...#...#.#...#...#...#...#\r\n#####.#.###.#.#.#######.#.#####.###.#######.###.#.###.#.#.###.###########.#.#.###.#.###.#.#.#.###.#.#v###.###.#.#.###.#.###.###############.#\r\n#.....#.....#.#.......#.#.#.....#...#...#...#...#.#...#.#.#...###...#...#.#.#.....#.#...#...#.#...#.>.>.#.###.#.#...#.#.....#.......#.......#\r\n#.###########.#######.#.#.#.#####.###.#.#.###.###.#.###.#.#.#####.#.#.#.#.#.#######v#.#######.#.#####v#.#.###.#.###.#.#######.#####.#.#######\r\n#.......#...#.#.......#...#...#...#...#.#...#.#...#...#.#.#.#...#.#.#.#.#.#.#...#.>.>.#.....#.#...###.#...#...#...#.#.#.......#...#.#.....###\r\n#######.#.#.#.#.#############.#.###.###.###.#.#.#####.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#v###.###.#.###.###.#####.#####.#.#.#.#######.#.#.#####.###\r\n#...###...#.#.#.............#...#...#...#...#.#...#...#.#.#.#.#.#.#.#.#...#.#.#.#.#.###...#.#...#.#...#...#.......#...#.........#.#.#...#...#\r\n#.#.#######.#.#############.#####.###.###.###.###.#.###.#.#v#.#.#.#.#.#####.#.#.#.#.#####.#.###.#.#.###.#.#######################.#.#.#.###.#\r\n#.#.........#...............###...###...#...#.....#.....#.>.>.#...#.#.....#...#...#.......#...#...#.....#.....#...................#...#.....#\r\n#.#############################.#######.###.###############v#######.#####.###################.###############.#.#############################\r\n#.........#.............#.......###...#.#...###...#...#...#.###...#...#...#.................#.#...............#.........#...............#...#\r\n#########.#.###########.#.#########.#.#.#.#####.#.#.#.#.#.#.###.#.###.#.###.###############.#.#.#######################.#.#############.#.#.#\r\n#.......#...#...........#...........#.#.#...#...#...#.#.#.#.....#...#...###...............#.#.#.#.............###.......#.#.............#.#.#\r\n#.#####.#####.#######################.#.###.#.#######.#.#.#########.#####################.#.#.#.#.###########.###.#######.#.#############.#.#\r\n#.....#.....#...........#.............#.....#.......#.#.#.#...#.....#...#.................#...#...###...#...#...#.....#...#...........#...#.#\r\n#####.#####.###########.#.#########################.#.#.#.#.#.#.#####.#.#.###########################.#.#.#.###.#####.#.#############.#.###.#\r\n#...#.....#.#...#...#...#.............#...###.......#...#.#.#.#...#...#.#.....#.....#.....#...#.......#...#.#...#.....#.#...#.........#.#...#\r\n#.#.#####.#.#.#.#.#.#.###############.#.#.###.###########.#.#.###.#.###.#####.#.###.#.###.#.#.#.###########.#.###.#####.#.#.#.#########.#.###\r\n#.#.......#...#...#...#.......#.......#.#...#...........#.#.#.#...#.#...#...#...###...#...#.#.#...........#...###...#...#.#...#.........#...#\r\n#.#####################.#####.#.#######.###.###########.#.#.#.#.###.#.###.#.###########.###.#.###########.#########.#.###.#####.###########.#\r\n#...#...#...#.....#...#.....#.#.......#.#...#...###.....#...#...#...#...#.#...#.......#.#...#.###...#.....#.....###...#...#.....#...........#\r\n###.#.#.#.#.#.###.#.#.#####.#.#######.#.#.###.#.###.#############.#####.#.###.#.#####.#.#.###.###.#.#.#####.###.#######.###.#####.###########\r\n###.#.#.#.#...###...#.#.....#.#.......#.#...#.#.#...#...........#...#...#.#...#.....#...#.#...#...#...#####...#...#...#.....#...#...........#\r\n###.#.#.#.###########.#.#####.#v#######.###.#.#.#.###.#########.###.#.###.#.#######.#####.#.###.#############.###.#.#.#######.#.###########.#\r\n###.#.#.#.#...........#.....#.>.>.......#...#.#.#.....#.........###.#...#.#.#...###...###.#.###...........#...#...#.#.#.......#.#.....#...#.#\r\n###.#.#.#.#.###############.###v#########.###.#.#######.###########.###.#.#.#.#.#####.###.#.#############.#.###.###.#.#.#######.#.###.#.#.#.#\r\n###...#...#.......#...#####.#...#.........#...#...#...#...#.......#...#...#.#.#.......#...#.#...#.........#...#...#.#.#.......#...###...#...#\r\n#################.#.#.#####.#.###.#########.#####.#.#.###.#.#####.###.#####.#.#########.###.#.#.#.###########.###.#.#.#######.###############\r\n###...#...###...#...#.###...#...#.#####...#.....#.#.#.#...#.#.....#...#.....#.........#...#.#.#.#.....###...#...#.#.#.###.....#.......#.....#\r\n###.#.#.#.###.#.#####.###.#####.#.#####.#.#####.#.#.#.#v###.#.#####.###.#############.###.#.#.#.#####v###.#.###.#.#.#.###.#####.#####.#.###.#\r\n#...#...#...#.#.#.....#...###...#...#...#.#...#.#.#.#.>.>...#...###...#.......#.......#...#.#.#.#...>.>.#.#.#...#.#.#...#.......#.....#...#.#\r\n#.#########.#.#.#.#####.#####.#####.#.###.#.#.#.#.#.###v#######.#####.#######.#.#######.###.#.#.#.###v#.#.#.#.###.#.###.#########.#######.#.#\r\n#.........#.#.#.#...#...#...#.#...#...###.#.#...#.#.###.....#...#...#.#.......#.....#...###...#...###.#.#.#.#...#.#.#...#...#...#...#...#.#.#\r\n#########.#.#.#.###.#.###.#.#.#.#.#######.#.#####.#.#######.#.###.#.#.#.###########v#.###############.#.#.#.###.#.#.#.###.#.#v#.###.#.#.#.#.#\r\n###...#...#.#.#.#...#.....#.#.#.#.#...###.#.....#.#.#.......#...#.#.#.#...#.......>.>.#...............#...#.....#.#.#...#.#.>.#.....#.#...#.#\r\n###.#.#.###.#.#.#v#########.#.#.#.#.#.###.#####.#.#.#.#########.#.#.#.###.#.#######v###.#########################.#.###.#.###v#######.#####.#\r\n#...#.#...#.#.#.#.>.#.....#.#.#.#...#...#.......#...#.........#...#...#...#.#.......###.....#.....#...#.........#.#.#...#.#...###...#.#.....#\r\n#.###.###.#.#.#.#v#.#.###.#.#.#.#######.#####################.#########.###.#.#############.#.###.#.#.#.#######.#.#.#.###.#.#####.#.#.#.#####\r\n#...#.....#.#.#.#.#.#...#.#.#.#.#...###.........#.............#.....###.....#.......###...#...#...#.#.#.#.......#...#.....#...#...#...#.....#\r\n###.#######.#.#.#.#.###.#.#.#.#.#.#.###########.#.#############.###.###############.###.#.#####.###.#.#.#.###################.#.###########.#\r\n###...#...#.#.#.#.#.....#...#...#.#...#.........#...#...#.......#...#...###...#...#...#.#.....#.....#...#.#...........#.......#.###.........#\r\n#####.#.#.#.#.#.#.###############.###.#.###########.#.#.#.#######.###.#.###.#.#.#.###.#.#####.###########.#.#########.#.#######.###.#########\r\n#.....#.#.#...#...###.....#...###...#...###...#####...#...#.......#...#.#...#...#.....#.....#.#...#...###...#.....#...#...#...#...#.........#\r\n#.#####.#.###########.###.#.#.#####.#######.#.#############.#######.###.#.#################.#.#.#.#.#.#######.###.#.#####.#.#.###.#########.#\r\n#.......#.#...#...#...#...#.#.....#.......#.#...#...#...###.......#.#...#.#.....###...#...#.#...#.#.#.###...#...#...#...#.#.#.....#.........#\r\n#########.#.#.#.#.#.###.###.#####.#######.#.###.#.#.#.#.#########.#.#.###.#.###.###.#.#.#.#.#####.#.#.###.#.###v#####.#.#.#.#######.#########\r\n#.........#.#.#.#.#...#.###.#.....#...#...#.#...#.#.#.#.#...#...#.#.#.###...###...#.#.#.#.#.....#...#...#.#.#.>.>...#.#.#...#...###.......###\r\n#.#########.#.#.#.###.#.###.#.#####.#.#v###.#.###.#.#.#.#.#.#.#.#v#.#.###########.#.#.#.#.#####.#######.#.#.#.#####.#.#.#####.#.#########v###\r\n#.........#.#.#.#...#.#...#.#...#...#.>.>...#...#.#.#.#.#.#.#.#.>.>.#.#...#...#...#.#.#.#.#...#.....###.#.#.#...#...#.#...#...#.#.....#.>.###\r\n#########.#.#.#.###.#.###.#.###.#.#############.#.#.#.#.#.#.#.#######.#.#.#.#.#.###.#.#.#.#.#.#####.###.#.#.###.#.###.###.#.###.#.###.#.#v###\r\n#.........#.#...#...#...#.#...#.#.#...#.........#.#.#.#...#.#.#.....#...#...#.#.....#.#.#.#.#.#...#...#.#.#.#...#.#...#...#.#...#...#...#...#\r\n#.#########.#####.#####.#.###.#.#.#.#.#.#########.#.#.#####.#.#.###.#########.#######.#.#.#.#.#.#.###.#.#.#.#.###.#.###.###.#.#####.#######.#\r\n#.........#.....#.#...#.#.#...#.#...#.#...#.....#.#.#.#.....#.#...#...........#.......#.#...#...#.#...#...#.#...#.#...#...#.#...#...#.......#\r\n#########.#####.#.#.#.#.#.#.###.#####.###.#.###.#.#.#.#.#####.###.#############.#######.#########.#.#######.###.#.###.###.#.###.#.###.#######\r\n###.......#...#.#...#...#.#.###.....#.#...#.###.#.#.#.#...#...###.......#.....#.###...#.......#...#.......#.#...#.#...#...#.#...#.###.......#\r\n###.#######.#.#.#########.#.#######.#.#.###.###.#.#.#.###.#.###########.#.###.#v###.#.#######.#.#########.#.#.###.#.###.###.#.###.#########.#\r\n#...#...#...#.#...#...#...#.......#...#.....#...#.#...#...#.....###.....#.###.>.>.#.#.#.......#.....#...#.#.#.#...#.#...#...#...#...#.......#\r\n#.###.#.#.###.###.#.#.#.#########.###########.###.#####.#######.###.#####.#######.#.#.#.###########.#.#.#.#.#.#.###.#.###.#####.###.#.#######\r\n#.#...#.#.###...#...#.#.#...#...#.###...#.....#...#.....#.....#.#...#...#.#.......#.#.#...#.......#.#.#...#.#.#.#...#.#...#.....#...#.......#\r\n#.#.###.#.#####.#####.#.#.#.#.#.#.###.#.#.#####.###.#####.###.#.#.###.#.#.#.#######.#.###.#.#####.#.#.#####.#.#.#.###.#.###.#####.#########.#\r\n#.#.#...#.....#...#...#.#.#.#.#.#.#...#...#...#...#.#...#.#...#.#...#.#.#.#.....#...#...#...#...#.#.#.#.....#.#.#.#...#.#...#...#.#.........#\r\n#.#.#.#######.###.#.###.#.#.#.#.#.#.#######.#.###.#.#.#.#.#.###.###.#.#.#.#####.#.#####.#####.#.#.#.#.#.#####.#.#.#.###.#.###.#.#.#.#########\r\n#...#.........###...###...#...#...#.........#.....#...#...#.....###...#...#####...#####.......#...#...#.......#...#.....#.....#...#.........#\r\n###########################################################################################################################################.#";
    }

    public record NodeConnection(Spot Spot, int Steps);

    public static class HikeTrailExtensions
    {
        public static void ShouldConnectTo(this HikeTrailNode node, params NodeConnection[] connections)
        {
            node.ConnectingNodes.Select(c => new NodeConnection(c.ConnectingNode.Spot, c.Steps)).Should().BeEquivalentTo(connections);
        }
    }
}
