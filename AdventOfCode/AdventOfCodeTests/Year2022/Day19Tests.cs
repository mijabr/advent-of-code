using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class Day19Tests
    {
        [Test]
        public void RobotMining_CanInitialiseFromInput()
        {
            var robotMining = new RobotMining(_exampleInput);

            robotMining.Blueprints[0].Number.Should().Be(1);
            robotMining.Blueprints[0].OreRobotCost.Should().Be(4);
            robotMining.Blueprints[0].ClayRobotCost.Should().Be(2);
            robotMining.Blueprints[0].ObsidianRobotCost.Should().Be((3, 14));
            robotMining.Blueprints[0].GeodeRobotCost.Should().Be((2, 7));
        }

        //[Test]
        public void TEST1_FindQuanlityLevelSum_ShouldSolveBlueprint1InExample1()
        {
            var robotMining = new RobotMining(_exampleInput.Split("\r\n")[0]);

            var result = robotMining.FindQuanlityLevelSum();

            result.Should().Be(9);
        }


        //[Test]
        public void TEST2_FindQuanlityLevelSum_ShouldSolveBlueprint2InExample1()
        {
            var robotMining = new RobotMining(_exampleInput.Split("\r\n")[1]);

            var result = robotMining.FindQuanlityLevelSum();

            result.Should().Be(24);
        }

        //[Test]
        public void TEST3_FindQuanlityLevelSum_ShouldFindThePuzzleAnswerForExample1()
        {
            var robotMining = new RobotMining(_exampleInput);

            var result = robotMining.FindQuanlityLevelSum();

            result.Should().Be(33);
        }

        //[Test]
        public void TEST4_FindQuanlityLevelSum_ShouldFindThePuzzleAnswerForPart1()
        {
            var robotMining = new RobotMining(_puzzleInput);

            var result = robotMining.FindQuanlityLevelSum();

            result.Should().Be(1365);
        }

        //[Test]
        public void TEST5_FindMaxGeodes_ShouldFindThePuzzleAnswerForExample2_Blueprint1()
        {
            var robotMining = new RobotMining(_exampleInput);

            var result = robotMining.FindMaxGeodes(robotMining.Blueprints[0], 32);

            result.Should().Be(56);
        }

        //[Test]
        public void TEST11_FindMaxGeodes_ShouldFindThePuzzleAnswerForPart2_Blueprint1()
        {
            var robotMining = new RobotMining(_puzzleInput);

            var result = robotMining.FindMaxGeodes(robotMining.Blueprints[0], 32);

            result.Should().Be(56);
        }

        private const string _exampleInput = "Blueprint 1:  Each ore robot costs 4 ore.  Each clay robot costs 2 ore.  Each obsidian robot costs 3 ore and 14 clay.  Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";

        private const string _puzzleInput = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 17 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 3: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 13 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 4: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 14 clay. Each geode robot costs 3 ore and 17 obsidian.\r\nBlueprint 5: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 19 clay. Each geode robot costs 2 ore and 20 obsidian.\r\nBlueprint 6: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 3 ore and 13 obsidian.\r\nBlueprint 7: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 2 ore and 19 obsidian.\r\nBlueprint 8: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 9: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 4 ore and 17 obsidian.\r\nBlueprint 10: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 3 ore and 11 obsidian.\r\nBlueprint 11: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 14 obsidian.\r\nBlueprint 12: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 13 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 13: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 14: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 10 clay. Each geode robot costs 3 ore and 10 obsidian.\r\nBlueprint 15: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 16: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 10 clay. Each geode robot costs 4 ore and 8 obsidian.\r\nBlueprint 17: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 13 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 18: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 2 ore and 20 obsidian.\r\nBlueprint 19: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 20: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 21: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 12 obsidian.\r\nBlueprint 22: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 4 ore and 8 obsidian.\r\nBlueprint 23: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 4 ore and 20 obsidian.\r\nBlueprint 24: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 25: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 5 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 26: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 8 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 27: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 28: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 4 ore and 20 obsidian.\r\nBlueprint 29: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 30: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 13 clay. Each geode robot costs 3 ore and 11 obsidian.";
    }
}
