using AdventOfCode.Year2023;

namespace AdventOfCodeTests.Year2023
{
    public class Day06Tests
    {
        [Test]
        public void CanReadInput_ForPart1()
        {
            var boatRaceTimer = new BoatRaceTimer(inputPart1);

            boatRaceTimer.BoatRaceTimes.Should().BeEquivalentTo(new List<BoatRaceTime>
            {
                new BoatRaceTime(57, 291),
                new BoatRaceTime(72, 1172),
                new BoatRaceTime(69, 1176),
                new BoatRaceTime(92, 2026)
            });
        }

        [Test]
        public void BoatRaceTimer_CanSolveExamplePuzzle()
        {
            var boatRaceTimer = new BoatRaceTimer("Time: 7 15 30 \r\nDistance:9 40 200");

            boatRaceTimer.GetWinningComboProduct().Should().Be(288);
        }

        [Test]
        public void BoatRaceTimer_CanSolvePart1()
        {
            var boatRaceTimer = new BoatRaceTimer(inputPart1);

            boatRaceTimer.GetWinningComboProduct().Should().Be(160816);
        }

        [Test]
        public void CanReadInput_ForPart2()
        {
            var boatRaceTimer = new BoatRaceTimer("Time: 7 15 30 \r\nDistance:9 40 200", part2: true);

            boatRaceTimer.BoatRaceTimes.Should().BeEquivalentTo(new List<BoatRaceTime>
            {
                new BoatRaceTime(71530, 940200),
            });
        }

        [Test]
        public void BoatRaceTimer_CanSolveExamplePuzzlePart2()
        {
            var boatRaceTimer = new BoatRaceTimer("Time: 7 15 30 \r\nDistance:9 40 200", part2: true);

            boatRaceTimer.GetWinningComboProduct().Should().Be(71503);
        }


        [Test]
        public void BoatRaceTimer_CanSolvePart2()
        {
            var boatRaceTimer = new BoatRaceTimer(inputPart1, part2: true);

            boatRaceTimer.GetWinningComboProduct().Should().Be(46561107);
        }

        const string inputPart1 = "Time:        57     72     69     92\r\nDistance:   291   1172   1176   2026";
    }
}
