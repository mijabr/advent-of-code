using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class Day24Tests
    {
        [Test]
        public void BlizzardBasin_CanIntialise()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Blizzards[0].Should().BeEquivalentTo(new Blizzard(new Spot(1, 1), '>'));
            blizzardBasin.Blizzards[18].Should().BeEquivalentTo(new Blizzard(new Spot(6, 4), '>'));
            blizzardBasin.PossibleLocations.ToList()[0].Should().Be(new Spot(1, 0));
            blizzardBasin.Minutes.Should().Be(0);
        }

        [Test]
        public void BlizzardBasin_CanFindPossibleLocationsAfter1Minute_GivenExample1()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Tick();

            blizzardBasin.PossibleLocations.ToList()[0].Should().Be(new Spot(1, 0)); // Stay put
            blizzardBasin.PossibleLocations.ToList()[1].Should().Be(new Spot(1, 1)); // Moved down
            blizzardBasin.PossibleLocations.Count().Should().Be(2);
        }

        [Test]
        public void BlizzardBasin_CanFindPossibleLocationsAfter2Minute_GivenExample1()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Ticks(2);

            blizzardBasin.PossibleLocations.Contains(new Spot(1, 2)).Should().BeTrue();
        }

        [Test]
        public void BlizzardBasin_CanFindPossibleLocationAfter10Minute_GivenExample1()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Ticks(10);

            blizzardBasin.PossibleLocations.Contains(new Spot(3, 1)).Should().BeTrue();
        }

        [Test]
        public void BlizzardBasin_CanFindPossibleLocationAfter17Minute_GivenExample1()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Ticks(17);

            blizzardBasin.PossibleLocations.Contains(new Spot(6, 4)).Should().BeTrue();
        }

        [Test]
        public void BlizzardBasin_CanFindPossibleLocationAfter18Minute_GivenExample1()
        {
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.Ticks(18);

            blizzardBasin.PossibleLocations.Contains(new Spot(6, 5)).Should().BeTrue();
        }

        [Test]
        public void BlizzardBasin_CanFindSolutionToPart1_GivenExample1()
        {
            Log.Enabled = true;
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.TickTillDone(100);

            blizzardBasin.Minutes.Should().Be(18);
        }

        [Test]
        public void BlizzardBasin_CanFindSolutionToPart1_GivenPuzzleInput()
        {
            Log.Enabled = true;
            var blizzardBasin = new BlizzardBasin(_puzzleInput);

            blizzardBasin.TickTillDone(1000);

            blizzardBasin.Minutes.Should().Be(343);
        }

        [Test]
        public void BlizzardBasin_CanFindSolutionToPart2_GivenExample1()
        {
            Log.Enabled = true;
            var blizzardBasin = new BlizzardBasin(_exampleInput);

            blizzardBasin.TickTillDone(100);
            var there = blizzardBasin.Minutes;
            blizzardBasin.TickTillBackAgain(100);
            var back = blizzardBasin.Minutes;
            blizzardBasin.TickTillDone(100);
            var thereAgain = blizzardBasin.Minutes;

            there.Should().Be(18);
            back.Should().Be(41);
            thereAgain.Should().Be(54);
        }

        [Test]
        public void BlizzardBasin_CanFindSolutionToPart2_GivenPuzzleInput()
        {
            Log.Enabled = true;
            var blizzardBasin = new BlizzardBasin(_puzzleInput);

            blizzardBasin.TickTillDone(1000);
            var there = blizzardBasin.Minutes;
            blizzardBasin.TickTillBackAgain(1000);
            var back = blizzardBasin.Minutes;
            blizzardBasin.TickTillDone(1000);
            var thereAgain = blizzardBasin.Minutes;

            there.Should().Be(343);
            back.Should().Be(663);
            thereAgain.Should().Be(960);
        }

        private const string _exampleInput = "#E######\r\n#>>.<^<#\r\n#.<..<<#\r\n#>v.><>#\r\n#<^v^^>#\r\n######.#";

        private const string _puzzleInput = "#.######################################################################################################################################################\r\n#><v><>..v<<vv^vvv><.^v<v>^>v<<>v<v.>.<><<^v..v>><>^v.vvv<<v<>vv<^.>^>v^<<.>^^>^^<vv^<<v.v^>><<^>v>^v^<<>^^<.>>^<>><v<^^v><^<>vvv<^^^<<>^v..^vv>^>^^v><#\r\n#<<v<^v^<>^v><v>v^<><v^^^><>><<vv<><^><^.<>^><><v^><^<<^^<<.^v^v^<v<<>.^.>>v.v>..>v><<<<<<.vv^>.<<v<<v>v>^v<><<^.>.<.<<.>v<v><v>.v>v^.^<.<v.>><.^v<<<..#\r\n#<>vvv^^^^<v^<><..vv.>>^vv^<^<>><^v>^<>.>v>^v>vv<>^..^^.v<<v<vv^<><<^<v^.v^v<vv.>v><^<>>>v<^<vv>.<vv.>^<v<vv>^<^vv^<.v.vv^^><>><><v><v<>^v<<.<<v<<^v.v<#\r\n#.><<<<^<>>^<^^>^><>v>^.vv<>v<^v><><<^v<v<><^.<<^v<<><<vv<<v^>.<.<>^v<>v.>><.><^^^v^v>^<<>v>v>>>^><^^>>><<<<<<^v>.<>v.<^v^^>v^v^>>>v>v^<<^v>^v>>^><>^><#\r\n#.^^<^vv<<<.>>v<<<>v<v^<>...^^<>>v^.<^<<>v^v^>>^^^.^^v>v^^>>.>v<v^vv^^v^<v^<^v>>>>vv><^.v>^.v^><.^><v^>^^>v>v<^v>v^^.<..<.<<v<>.^^<v>.>><>^^v^<.^.vv<<<#\r\n#<>>.^^^v>>>^v<>>^>v^v<v^>v<v<<v<^.v><.>>><<<.v<v<.vv><v<>v>><<^.^<.v<>^><><^>.<>.^^<.><<v..><v^v>^.v^><.>v.v<v>v>>>^^<<^<<.v>><vv><<>>^<^^v><.v><.<><>#\r\n#<<v^<v>>.^<>v>vv^^>v^^>^>>^>...^^^><^<>^v<vvv><^<v<><v^.v^.>>^v^<^^.v.<<<.^>>^<>^.<><.^>vv.<^<^...vv>.v^<^<^^<>v<v.<^v<^^>^>v><^.>v<>^v<^v^<.vv<^<<<><#\r\n#><<v<v^<^^<v<v<<>>^<v^><><<v.>..<v<<<<>><^<>.^<^.>><v<^.^.<>^>>><vvv<<^<<<^v<.>^^v^^>v<>v>^^<v><v<v<v>^v^^v>v.>><^.><v>v<>.^^vv^<^^^^.^.^<^>>>^>.^.^v<#\r\n#<><.^^>vvvv<.>vv^v>>v>>^<<><^>v>vv<v<v>^.^^<v<>^<>^.<>>v^.>>^>>^.v>^>.>><v<^v^<<v^.<^^v<<>>^v>^>v<<.^^<v>^<<.^v^><<<v.^^^^<<v>.v<<<v.^<^<^^^..<<^^>^^>#\r\n#.v.>>^.<vv>^>.v>v<vv><^^<v>^>vv>>^v^vv.^.>^>vv^v<v^.^<^^<v<<<>^<>^<vvv^^^^>^^<^>^>.<vv.<<>^v.<<<^.v>v>^^>>>v<v>><>v.>>>>>>v>vvv<^>.>>>>^>^<^v<<>v^vv^<#\r\n#<<><>vv<v.<v>^<^v.^^.<<<^<^<^^^><^^^>><<.>><><v>>^>.><v>^^<>><<<v<>v<<vv<.v^v<^>>vvvv^v<>>v^><<<.>^><v>v.<vv><vv<>v<>^v^v<<^>^<v.<.v>>^.v<<<.>^<^^<>^.#\r\n#.v><<<^v^>^<^v^<v><<.>^v.<<><v^<>v<<<>v>vvv>^<.^v>v<^<<v^>v<^v>>.v<><v<^^>>^^><^.>v<<^^<<vv<^><<^>>.v^v^<v>>>^<v><>^v^vv^^.vv<vv^v^<>^^vv^>>^v^><^>^v>#\r\n#.v^^^^<v^>>v>v.<<v^vvv<.^<.<^<>..><v^><<^<>>^v^^>>>v.>^.<vvv^vvv.v^>^<v^>^<<^^>^^>^><<<^>v>>.vv^v<>^>.^v.v^.v<.><^<>v><.v.>^>><>^<^><v>^^>>^<>v^<><>><#\r\n#>>^<.>vvv^>v<<v^>^v<><^>>v>^<<<^>vv>^v><>^<v>.>.>^.v<vv>v^<><<<^^.>vv<>^>><>^<>^>vvv<.^^><^>v.<>^^<^<<^vv.^>.vv^^<><><^v><<>^><<.^>>^>^vv>>^^.v<.^<<^>#\r\n#>v^^v>^>^>v>.v^vvv>>.v<>^^v>>.<.>>>>>v<^<>.<.^>>^<vv^<<v^^v<<vv^^<><.v><<v<>>^v<<<>>>^v.^>v>^.>>^<^v>v..v^<v><<<^<^<<^><>^<<v>^<>.>vvv.^<<<<.<<v^>v>>.#\r\n#><^.<<<.v>v<.^.>^^>^<vv<v<.^^>><>>v<^v.v>v>^<vvvv<vv>.>^^v^><^>^^>v>vvv>>.<vv.>..<>^^<^><<v^^v<>..<>v^<v...v<>^^^^>v^^>v<^>vv>^^v^<v>v>>^<v^^<^v.^^^><#\r\n#..v^.v.v<>^>^>><^^<>v.v><><v<^^^^v>^^^v^>^>>vv.^^v<<<>>v<<<<<<^v<>v^v^v^<v.v<^>>><^><vv<>^>.v.v<^vv^vv.^<^v>vv.<.<v<.<<v^^<^v<>>v><>>vv<v...>^<^^^v^.>#\r\n#>><v^<^^v^><v><>^.<.v^vv<>>>>><vvv>^^>^<v>^>^.v^>>><v<.vv.<^<<>^^<^>v<^v^^<vv<.v^vv^v>.^v^<>v<.>^vv>>v^^v^.^<v<<^v<<^>..v<^v..>v^><v^><><^.<<>>.^v>^>.#\r\n#>.v<^^^<v.>^v<.v<><v^.<vv<^v.^^v^><^vv.<>v^^^^^^<<>><v>><><<>>>v<v^v^<v>.^><^<.>>^^<>v><<^vv^v^<v><<<>v><.v.^>>^v^^<<^.<>>.<<>^^^<v>vv.>^<.>v>v>v>^>>.#\r\n#<v^^<^^^>>^<^.<^<<v>vv>^v^><<<vv.v^^<<v>>>v^<^v<<<.<^v>>^^><vv>^<^^>v^^<<>^^<^^><.v..>>^^v<^><^<>v>.<v>^<^v^^v>><.vv<<v>vv>><>>v>>>.^.<>v^<^^>^v>.v^>.#\r\n######################################################################################################################################################.#";
    }
}
