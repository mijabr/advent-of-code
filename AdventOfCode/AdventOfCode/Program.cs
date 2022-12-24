// See https://aka.ms/new-console-template for more information

using AdventOfCode.Util;
using AdventOfCodeTests.Year2022;

class Mains
{
    static void Main(string[] args)
    {
        Log.Enabled = true;

        if (args.Length < 3)
        {
            Log.Info("Usage:");
            Log.Info("AdventOfCode <year> <day> <test>");
            Log.Info("see code for available long tests to run");
            return;
        }

        var year = args[0].Parse<int>();
        var day = args[1].Parse<int>();
        var test = args[2].Parse<int>();
        Log.Info($"year = {year} day = {day} test = {test}");

        if (year == 2022 && day == 19)
        {
            Year2022Day19(test);
        }
        else if(year == 2022 && day == 23)
        {
            Year2022Day23(test);
        }
        else
        {
            Log.Info("no test found");
            Log.Info("see code for available long tests to run");
        }
    }

    static void Year2022Day23(int test)
    {
        Log.Info($"Unstable Diffusion - test {test}");

        var _puzzleInput = "#.##.....#.#...###.##.##.##.##...##..####.#.#.##..#.#####......###..###.###\r\n#.#....#.##..#.#..#...#####.####....#.#...#...#.####.###.#.#.#..#.####.##..\r\n##.####..#.##.....##...#.#.#.#...###.#..#####..##.........#...###..#..#..##\r\n.#..###..#...#.####..#.#.#.####....###.##....#.##...........#..###...###.##\r\n#.###...##.#....###..####..#.....#######..###.####.#...#...##.#..##.###.###\r\n#.#.###..#...#.##...##.##.##.#.....##..##.##...####.######.#.#.#...#####..#\r\n.#..###....##......#####.#.###..#..##..##.#.######..###..#....#.####.######\r\n#...###..####..#.....#.####.#.##...#..#..###..###...#....##..#..#####.....#\r\n#.#####.#..#..#..####.##.#....###..##..###...###.##.#.#.##.#.#..##.#.#####.\r\n###.#.#.##....##.....#..#..#.####.#....#...#.####.#.#.....#.###..####..##.#\r\n.##.#...###.###..#.#..##.###.##....#.#....#####....#.#.###.###.#...#.......\r\n...####.####....#.....######.###.###...###.#...##...###..###..###.##.#.##.#\r\n#.#..#.####.###..##...###.#..######...##.#####.........###..###...#.#.#.###\r\n##..####...###.##..###.###..#...##..##...###.#......####.#.#...#..#.####..#\r\n.#...#.#..#.#.####.#.#.###..###..#.#..#....######..#...##.##.....##..#.#..#\r\n......###..#.....##.###.##...#.###.####..#####.###.#.###....####.#...##..#.\r\n..#.###..###....#....#...#.#..#.#.##.#.#.#.####.##..####.##..##......##.###\r\n#...#..####.#.#...##..#.#..#.####.##.###.##.##.##.#...#.#.##...##.#..#.#.##\r\n##....#..#......#....#.####...#..##..##.###...##..####.##...#.#############\r\n###.#....#..#.##...#.##..###..#....#.#..#..#..#...#...####.#.###.##.#..##.#\r\n....##..#.##..###.#.#.##..##..#.#..#...##.##.###....#.#.#.#....####....#...\r\n##.##.#.#...##...#..####.#.###....####.#.#........#..#.#####..##....##.###.\r\n#.#.##.#.....#..##.##.#..#....#...#..##..#####.####.##...##......###...#...\r\n.#.####...#.##..##.##.######.#...##.#..##.##..#.##....##..#.##...#.#####.#.\r\n#...#..#..#.#..##.#.##.#..###.##...##..#.##..#.#..##...#.##.###...###..#.#.\r\n#..##.....##.###.#..#.#.#######.###.#....#...#.#.####...##.#.#..##.#.#####.\r\n#.......#..##..#.###.....#....###.#.###.##...##.##.###.#..##.###....#..#...\r\n#.....#########.#.#..#.#.#.#..###.......#..#..#...##.#.#.####..#.##.#####..\r\n#...#.#....#####.#.#..#..#...##.#.###....##.##.#....###.#.###.....#..#.##.#\r\n#...#..##....#.##.##.##.##..###.#......#..###.###..##.####.##...#..###.####\r\n####..#.#...###....#......###.####..#.##......#.....#.....#..#.##..###..##.\r\n..##.##.##.########.#.####..#..#.#..#.###....###.#..#...#.##.##.#...#.#.###\r\n....#.....####.######.#.#..#.#.##.#.#..#..#.#..#.#.###.#.#..#####..##.##.#.\r\n.#...##..#..#########..#....#....#.#...#..#.#.#.#.######.#.##....#..#..#..#\r\n.###.#.##...##..#.##.#..#...###.##.###.####.....#..#..###...#.#.#....#.##..\r\n##.##..#####.##..###.##.##.#.#.#..#.#.####.#.#.##....#.####..#..##.##...##.\r\n#####...########..##...###.##..#..####.#.#.##.#.#..##....#..####.#.#.#..##.\r\n.#..#.#.##....#..###..###...####...###......#.#.#..#.##.####.#######.......\r\n###...#..##...#.#.#.#.##...#....####.#...#..#....##.##.#.##..#..##.#...##..\r\n..##...##.#.#.###...##.......#.#.###..##..#.##.#.#.###...####.#.#.#.##.#.#.\r\n##...#...#.###.#.##.#.#....#.##..#..#...#..##.#..#..##..#.#.#.#.#..#..####.\r\n####..##..#.#.#.#####..#......##.#....#..####..#.#.#####.#.....#..#...##...\r\n#..#.#.#.####...##..#..###.#.#...#.#.#.#..###....##.#.#....#..######.###.##\r\n#.###.#....#.#.#.#.###...#...###..#.#.#..#........#...#.##.####..#.#.#..#.#\r\n.###...####.##.#....##.###..##.###.#.#.....#...#.#..#..#...#.#####.#...#...\r\n......#....#.####..#.#.#..#..##.###...#..###.####.#.###..###.#....##.###.#.\r\n....###..##.#..#.###.#..#.#.#.####..#####..#.#.###..#.....##.#......#..##.#\r\n.#...#....#.##.......#.#..#####.#.#######.........###.#.###.#...###..#####.\r\n.#....#.#......#.###....#..##..####........#.#..#.#.#.##.#.#..##.#..#..#.#.\r\n.##.###.##.#.#.#....##..#.###...#...#.##..#.#..#..#....###..#...#.##.#...##\r\n###.....##.###.####.#...#####......#..###..#...###..#...##.##..###.....#...\r\n####......###.#...#..##.##.#..###.#.####.#.##..####...#.#...#....#..#..#...\r\n.###.###.#..#...#..###.#####...###.#####....#.....#...##.##..#..##..#...#.#\r\n.##.#.####..###.#.#.##.##.#####..##...#########.#..#########..#.#..###..#.#\r\n.####.#..#.###.#########..#..#.###.#...#.#.#.##...###...#.#.#..###.#.#....#\r\n##.########...#..#.....#..###..#...##....#.#.#..........#..###...####..#.##\r\n####.#####...###..#..##..###.#.#..#..###.####.#.####.###..#...#.##.#..#.###\r\n#..#.#.#.#..###.#.....##.#....#####..#.#..#...#.##.#....##.##.#..#.###.###.\r\n.###....#.#######.######...##......#....#..##.##.....#..#....#..#.#.....#..\r\n#####..#.#.##..###..##.#.#.##..####.#..#.#..#####.#....##.##..#..##..###..#\r\n..#.#..##.#.##.#..#.#.#.#.#.##.##...#...#....##..##.##...#........##.#####.\r\n##.#..######.#.......#.##..#.###.######..######.#.#.##..#####.#.####.#.#...\r\n.##.#####.##.#.#.##....##...#####.#...##......#.#..#..#..#.##......#.##..##\r\n..##..#.####..#.###..#....##.##..#..#####.#.#.#...#....#.###.###..##.##...#\r\n......#.##.....#.####....#....#...###....#..######...#.#...###..#####.##...\r\n#.#...##..##.#.#..###.#....#.#..#..#....####..#..##.##.#..#.#...###..#..###\r\n.#.#.##..#####..##.###..#...##..##.#.#.######.#...#.#.##..#.....#....#.###.\r\n#..###.####.###..#.##.......#.#..###..#.###.##.##..#.......#...#.#..###..#.\r\n...#......####.##.#.##..#.#.#.#.#####.#.##.##..##.##.###.....#.#####.#..#..\r\n.##..#.##..#.####...#...#####.#.###..#.##.##.....###...##..#...#....#.###.#\r\n.##.##.#######.###.###......#.#.###.##..#.##.######.##.#.....###..##..#####\r\n#######.#..#..#..#.#.#..##..#..#.#.#.##......#.##.####.#.###.#..#...##.####\r\n.##.#..#...........#.#..#.##.###....#..#....#..##.####.######.......#.#.###\r\n.##...###.####.###.#.###.#..#.#.#.##..#.##.###.#.#.##..##..#.##.#.......###\r\n##.#.#......##.#.#.##.###....#.###..#.###.#...##...#####.#..#..#.####...#..";

        if (test == 1)
        {
            var unstableDiffusion = new UnstableDiffusion(_puzzleInput);

            var result = unstableDiffusion.SpreadOut(-1);

            Log.Info($"Moves = {result}");
            if (result == 980) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 980");
        }
    }

    static void Year2022Day19(int test)
    {
        Log.Info($"Robot Mining Race - test {test}");
        const string _exampleInput = "Blueprint 1:  Each ore robot costs 4 ore.  Each clay robot costs 2 ore.  Each obsidian robot costs 3 ore and 14 clay.  Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        const string _puzzleInput = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 17 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 3: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 13 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 4: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 14 clay. Each geode robot costs 3 ore and 17 obsidian.\r\nBlueprint 5: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 19 clay. Each geode robot costs 2 ore and 20 obsidian.\r\nBlueprint 6: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 3 ore and 13 obsidian.\r\nBlueprint 7: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 2 ore and 19 obsidian.\r\nBlueprint 8: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 9: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 4 ore and 17 obsidian.\r\nBlueprint 10: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 3 ore and 11 obsidian.\r\nBlueprint 11: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 14 obsidian.\r\nBlueprint 12: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 13 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 13: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 14: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 10 clay. Each geode robot costs 3 ore and 10 obsidian.\r\nBlueprint 15: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 16: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 10 clay. Each geode robot costs 4 ore and 8 obsidian.\r\nBlueprint 17: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 13 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 18: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 2 ore and 20 obsidian.\r\nBlueprint 19: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 20: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 21: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 12 obsidian.\r\nBlueprint 22: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 4 ore and 8 obsidian.\r\nBlueprint 23: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 4 ore and 20 obsidian.\r\nBlueprint 24: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 25: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 5 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 26: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 8 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 27: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 28: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 4 ore and 20 obsidian.\r\nBlueprint 29: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 30: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 13 clay. Each geode robot costs 3 ore and 11 obsidian.";

        if (test == 1)
        {
            var robotMining = new RobotMining(_exampleInput.Split("\r\n")[0]);
            var result = robotMining.FindQuanlityLevelSum();
            Log.Info($"FindQuanlityLevelSum = {result}");
            if (result == 9) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 9");
        }
        else if (test == 2)
        {
            var robotMining = new RobotMining(_exampleInput.Split("\r\n")[1]);
            var result = robotMining.FindQuanlityLevelSum();
            Log.Info($"FindQuanlityLevelSum = {result}");
            if (result == 24) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 24");
        }
        else if (test == 3)
        {
            var robotMining = new RobotMining(_exampleInput);
            var result = robotMining.FindQuanlityLevelSum();
            Log.Info($"FindQuanlityLevelSum = {result}");
            if (result == 33) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 33");
        }
        else if (test == 4)
        {
            var robotMining = new RobotMining(_puzzleInput);
            var result = robotMining.FindQuanlityLevelSum();
            Log.Info($"FindQuanlityLevelSum = {result}");
            if (result == 1365) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 1365");
        }
        else if (test == 5)
        {
            var robotMining = new RobotMining(_exampleInput);
            var result = robotMining.FindProductOfFirstThree();
            Log.Info($"FindProductOfFirstThree = {result}");
            if (result == 0) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 0");
        }
        else if (test == 5)
        {
            var robotMining = new RobotMining(_exampleInput.Split("\r\n")[0]);
            var result = robotMining.FindMaxGeodes(robotMining.Blueprints[0], 32);
            Log.Info($"FindMaxGeodes = {result}");
            if (result == 56) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 56");
        }
        else if (test == 11)
        {
            var robotMining = new RobotMining(_puzzleInput.Split("\r\n")[0]);
            var result = robotMining.FindMaxGeodesWithSplit(robotMining.Blueprints[0], 32);
            Log.Info($"FindMaxGeodes = {result}");
            if (result == 5) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 5");
        }
        else if (test == 12)
        {
            var robotMining = new RobotMining(_puzzleInput.Split("\r\n")[1]);
            var result = robotMining.FindMaxGeodesWithSplit(robotMining.Blueprints[0], 32);
            Log.Info($"FindMaxGeodes = {result}");
            if (result == 12) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 12");
        }
        else if (test == 13)
        {
            var robotMining = new RobotMining(_puzzleInput.Split("\r\n")[2]);
            var result = robotMining.FindMaxGeodesWithSplit(robotMining.Blueprints[0], 32);
            Log.Info($"FindMaxGeodes = {result}");
            if (result == 38) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 38");
        }
        else if (test == 14)
        {
            var robotMining = new RobotMining(_puzzleInput);
            var result = robotMining.FindProductOfFirstThree();
            Log.Info($"FindMaxGeodes = {result}");
            if (result == 2280) Log.Info($"Passed");
            else Log.Info($"Failed. Expected to be 2280"); // nope... too low
        }
    }
}
