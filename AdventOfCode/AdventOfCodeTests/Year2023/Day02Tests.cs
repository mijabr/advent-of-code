using AdventOfCode.Year2023;

namespace AdventOfCodeTests.Year2023
{
    public class Day02Tests
    {
        [Test]
        public void CubeCounter_CanReadInput()
        {
            var cubeCounter = new CubeCounter(exampleInput);

            cubeCounter.CubeGames[0].GameNumber.Should().Be(1);
            cubeCounter.CubeGames[0].CubeGameSelections[0].Reds.Should().Be(4);
            cubeCounter.CubeGames[0].CubeGameSelections[0].Blues.Should().Be(3);
            cubeCounter.CubeGames[0].CubeGameSelections[0].Greens.Should().Be(0);
        }

        [Test]
        public void CubeCounter_CanCompleteExample1()
        {
            var cubeCounter = new CubeCounter(exampleInput);

            cubeCounter.GetSumOfPossibleGames(12, 13, 14).Should().Be(8);
        }

        [Test]
        public void CubeCounter_CanCompletePart1()
        {
            var cubeCounter = new CubeCounter(input);

            cubeCounter.GetSumOfPossibleGames(12, 13, 14).Should().Be(2265);
        }

        [Test]
        public void CubeCounter_CanCompleteExamplePart2()
        {
            var cubeCounter = new CubeCounter(exampleInput);

            cubeCounter.GetSumOfPower().Should().Be(2286);
        }

        [Test]
        public void CubeCounter_CanCompletePart2()
        {
            var cubeCounter = new CubeCounter(input);

            cubeCounter.GetSumOfPower().Should().Be(64097);
        }

        const string exampleInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        const string input = "Game 1: 1 green, 2 red, 6 blue; 4 red, 1 green, 3 blue; 7 blue, 5 green; 6 blue, 2 red, 1 green\r\nGame 2: 1 green, 17 red; 1 blue, 6 red, 7 green; 2 blue, 4 red, 7 green; 1 green, 6 red, 2 blue\r\nGame 3: 6 red, 15 blue, 15 green; 1 green, 4 red, 12 blue; 14 blue, 9 red, 1 green; 2 red, 15 blue, 12 green\r\nGame 4: 8 green, 10 blue, 6 red; 20 blue, 4 red; 17 blue, 2 green, 3 red; 4 blue, 2 green, 3 red; 10 red, 3 blue, 3 green; 5 green, 14 blue, 6 red\r\nGame 5: 3 green, 8 blue, 2 red; 11 red, 6 green, 11 blue; 8 red, 5 blue, 2 green\r\nGame 6: 2 blue, 12 red, 2 green; 3 green, 2 red; 3 green, 3 blue, 10 red; 7 red, 2 blue, 4 green; 1 red, 2 blue, 5 green\r\nGame 7: 1 red, 8 blue, 2 green; 1 red, 2 blue, 12 green; 1 blue; 3 blue, 3 green\r\nGame 8: 10 green, 4 red, 4 blue; 12 green, 1 blue; 1 red, 13 green, 2 blue; 12 green, 3 blue; 9 green, 7 red\r\nGame 9: 1 green, 1 blue, 3 red; 3 blue, 3 red, 8 green; 6 blue, 4 red, 6 green; 2 red, 7 green; 1 red, 10 green, 13 blue; 5 red, 1 blue, 1 green\r\nGame 10: 9 green, 3 red, 3 blue; 12 green, 2 blue; 18 green, 1 blue; 14 green; 2 blue, 9 green, 2 red\r\nGame 11: 14 green; 2 green, 2 red, 11 blue; 9 blue, 3 green\r\nGame 12: 9 green, 3 blue, 8 red; 1 green, 2 blue, 3 red; 4 blue, 8 red, 10 green; 3 blue, 7 red, 8 green; 3 blue, 5 red, 7 green; 2 blue, 5 green\r\nGame 13: 6 red, 1 blue, 10 green; 7 red, 1 green; 8 red, 2 green, 1 blue\r\nGame 14: 2 red, 4 blue, 2 green; 2 green, 5 red, 1 blue; 1 red, 6 blue\r\nGame 15: 7 blue, 3 red; 13 blue, 8 red, 1 green; 1 green, 5 red, 13 blue; 8 red, 5 blue; 4 red, 3 blue, 1 green; 12 blue, 8 red, 1 green\r\nGame 16: 5 blue, 1 green, 2 red; 2 blue, 20 green; 4 blue, 1 red, 17 green; 10 green, 5 blue, 2 red\r\nGame 17: 6 red, 13 blue, 8 green; 12 blue, 7 green, 9 red; 19 blue, 5 red; 2 green, 8 red, 14 blue\r\nGame 18: 5 red, 2 green, 1 blue; 8 blue, 17 red, 9 green; 2 blue, 1 green; 4 blue, 10 red; 5 blue, 4 red, 6 green\r\nGame 19: 5 red, 12 green; 8 red, 13 green, 1 blue; 1 red, 1 green, 3 blue; 5 green, 5 red\r\nGame 20: 11 red, 8 blue; 9 red, 2 green, 13 blue; 2 red, 1 green, 2 blue; 1 green, 9 blue, 13 red; 3 blue, 5 red, 1 green\r\nGame 21: 1 red, 4 green, 11 blue; 3 green, 15 blue; 6 green, 7 red, 14 blue; 15 blue, 6 green, 10 red; 6 red, 16 blue, 2 green\r\nGame 22: 2 blue, 15 green, 2 red; 3 blue, 6 green, 1 red; 2 blue, 5 green, 1 red; 6 green, 2 red, 2 blue; 4 green, 2 blue; 4 blue, 1 red, 15 green\r\nGame 23: 2 blue, 1 green, 12 red; 5 blue, 11 red, 4 green; 12 red, 4 blue; 12 red, 2 green, 5 blue\r\nGame 24: 4 blue, 7 red; 3 red, 3 blue; 1 red, 4 blue; 2 green, 6 red, 6 blue; 7 red, 1 green, 2 blue; 6 red, 1 blue, 1 green\r\nGame 25: 5 green, 9 blue; 6 green, 7 red, 2 blue; 1 red, 3 blue, 7 green; 9 blue, 3 red; 5 green, 9 blue, 2 red\r\nGame 26: 6 red, 4 blue; 2 blue, 4 green; 3 green, 5 red, 5 blue; 4 green, 6 red, 3 blue; 4 green, 7 red, 4 blue\r\nGame 27: 15 green, 1 blue, 12 red; 12 red, 1 green; 1 red, 1 blue, 5 green; 13 green, 6 red, 1 blue; 5 red, 1 blue, 1 green; 11 red, 14 green\r\nGame 28: 3 blue, 2 green, 10 red; 5 blue, 2 green; 4 green, 3 blue, 11 red\r\nGame 29: 10 blue, 2 red; 17 green, 7 blue, 2 red; 1 blue, 8 green, 1 red; 10 green, 2 red, 3 blue\r\nGame 30: 10 green, 8 red, 1 blue; 4 blue, 7 green, 14 red; 2 blue, 14 red, 11 green; 1 blue, 13 green, 12 red; 5 blue, 2 red, 4 green; 4 green, 5 red\r\nGame 31: 4 green, 11 red, 11 blue; 3 blue, 11 red; 5 blue, 7 red, 3 green; 10 blue, 5 green, 1 red\r\nGame 32: 4 red, 8 blue, 1 green; 14 red, 7 blue, 4 green; 13 red, 3 blue, 9 green; 3 red, 1 green, 8 blue; 8 green, 8 red, 5 blue\r\nGame 33: 6 red, 10 blue, 7 green; 19 blue, 1 red; 6 green, 11 red, 11 blue; 2 green, 2 blue, 12 red; 3 red, 13 blue, 7 green; 6 green, 4 red, 2 blue\r\nGame 34: 3 red, 3 green, 15 blue; 7 green, 15 blue; 3 red, 2 green, 8 blue; 19 green, 18 blue\r\nGame 35: 2 green, 1 blue; 2 green, 2 blue, 1 red; 3 blue, 1 red, 1 green; 4 blue, 1 red\r\nGame 36: 1 red, 11 green; 1 green, 1 blue; 8 blue; 2 green, 3 red; 1 red\r\nGame 37: 4 blue, 3 red; 12 blue, 13 red; 2 red, 2 green, 8 blue\r\nGame 38: 8 red, 2 blue; 1 green, 2 red; 8 red, 2 green, 1 blue; 16 red, 2 green; 7 red, 2 blue, 2 green\r\nGame 39: 6 green, 1 blue, 5 red; 14 green, 8 blue, 6 red; 8 red, 10 blue, 1 green; 14 green, 9 red; 17 blue, 5 red; 1 blue, 7 green, 1 red\r\nGame 40: 4 red, 8 blue, 3 green; 13 blue, 1 red; 3 blue, 7 red, 3 green; 3 green, 8 blue, 10 red; 3 green, 20 blue, 5 red\r\nGame 41: 1 blue, 2 green; 11 green, 2 blue; 5 blue; 15 red, 8 green, 5 blue\r\nGame 42: 1 green, 12 blue, 1 red; 6 blue, 1 green, 5 red; 1 red, 11 blue, 4 green; 3 red, 17 blue, 1 green; 1 red, 11 blue; 9 blue, 6 green, 3 red\r\nGame 43: 16 blue, 13 green, 1 red; 17 blue, 7 red, 10 green; 13 green, 5 red, 7 blue\r\nGame 44: 2 blue, 4 red; 15 green, 7 red; 2 green, 1 blue; 6 red, 13 green\r\nGame 45: 5 green, 1 blue, 8 red; 4 red, 1 blue, 5 green; 1 green, 3 red; 1 green, 2 blue, 6 red; 4 red, 3 green, 2 blue; 2 red, 2 blue, 5 green\r\nGame 46: 1 green, 1 red, 6 blue; 11 blue; 1 red, 1 green, 7 blue; 8 blue; 1 green, 7 blue, 2 red\r\nGame 47: 7 green, 9 blue, 7 red; 11 red, 13 blue, 5 green; 12 green, 12 blue, 5 red; 4 blue, 8 green, 7 red\r\nGame 48: 11 green, 7 red, 2 blue; 2 blue, 10 green, 3 red; 1 blue, 2 red, 1 green; 4 green, 2 red, 7 blue; 7 red, 4 green, 2 blue\r\nGame 49: 1 red, 2 blue, 5 green; 2 green, 4 blue; 5 blue, 2 green, 1 red; 9 blue, 1 green; 7 blue\r\nGame 50: 8 green, 9 blue, 2 red; 2 green, 5 blue; 14 green, 1 red, 8 blue\r\nGame 51: 1 green, 2 blue; 12 blue, 1 red; 2 blue\r\nGame 52: 3 red, 2 blue, 2 green; 4 red, 4 green, 7 blue; 2 blue, 4 red, 1 green; 3 green; 1 red, 9 green, 7 blue\r\nGame 53: 9 blue, 12 red, 7 green; 8 blue, 6 green; 1 green, 8 blue, 9 red; 12 red, 6 green; 9 blue, 14 red, 10 green; 7 red, 3 green, 5 blue\r\nGame 54: 8 green, 5 blue, 5 red; 4 green, 13 blue, 2 red; 2 blue, 5 red, 1 green; 3 red, 3 green, 10 blue\r\nGame 55: 17 red, 15 green, 17 blue; 6 red, 5 green, 7 blue; 17 green, 6 blue, 5 red\r\nGame 56: 7 blue, 6 red, 7 green; 10 green, 3 red; 9 red, 3 blue, 5 green\r\nGame 57: 5 blue, 11 red, 1 green; 13 red, 1 green, 2 blue; 2 blue, 4 red; 1 green, 10 red, 1 blue; 1 green, 8 red\r\nGame 58: 1 red, 2 green, 9 blue; 1 green, 1 blue, 1 red; 2 red, 6 blue, 2 green; 14 blue, 1 green, 1 red; 5 blue, 1 red, 2 green; 14 blue, 2 green\r\nGame 59: 9 green, 2 blue, 5 red; 9 red, 5 green; 10 red, 1 blue, 8 green\r\nGame 60: 8 blue, 6 red, 4 green; 3 red, 12 green, 9 blue; 4 blue, 5 red, 5 green; 4 red, 8 blue; 7 green, 12 blue, 6 red\r\nGame 61: 5 blue, 13 red, 1 green; 5 red, 5 blue; 1 red, 3 blue; 1 green, 9 red; 10 red, 3 blue, 1 green\r\nGame 62: 1 blue, 13 red; 4 blue, 5 red; 11 blue, 8 red, 1 green\r\nGame 63: 14 blue, 5 red; 9 blue, 14 green, 5 red; 3 red, 8 green, 15 blue; 4 blue, 15 green, 6 red\r\nGame 64: 13 red, 6 blue, 11 green; 12 red, 1 blue, 8 green; 1 red, 17 green; 13 red, 12 green, 7 blue\r\nGame 65: 4 red, 17 blue, 3 green; 2 green, 12 blue, 9 red; 2 green, 17 blue, 5 red; 1 red, 1 green, 4 blue; 9 red, 16 blue; 7 blue, 9 red\r\nGame 66: 10 blue, 10 green, 5 red; 10 green, 3 blue, 5 red; 1 red, 1 green, 10 blue; 2 green, 5 red, 20 blue; 8 blue, 11 green, 13 red; 2 green, 18 blue, 2 red\r\nGame 67: 6 red, 1 green; 5 red, 10 blue; 6 blue, 6 red\r\nGame 68: 4 green, 1 red, 5 blue; 5 red, 5 blue; 7 red, 6 green; 8 red, 1 blue\r\nGame 69: 2 blue, 11 red; 4 red, 6 green, 1 blue; 4 red, 1 blue, 14 green\r\nGame 70: 15 red, 8 blue, 5 green; 5 green, 2 red, 8 blue; 8 red, 3 green, 10 blue\r\nGame 71: 4 blue, 2 red; 12 green, 4 blue; 10 green\r\nGame 72: 3 blue, 4 green, 6 red; 6 red, 5 green, 8 blue; 10 red, 6 green, 5 blue; 1 green, 2 blue; 10 red, 5 blue, 4 green\r\nGame 73: 5 blue, 1 red; 1 green, 11 blue; 10 blue; 12 blue, 1 red; 1 red, 9 blue; 7 blue, 1 green, 1 red\r\nGame 74: 7 green, 6 blue, 7 red; 7 blue, 6 green, 15 red; 7 red, 5 blue, 1 green; 1 blue, 6 red, 8 green; 8 green, 14 red, 3 blue\r\nGame 75: 8 green, 3 red, 3 blue; 1 blue, 6 red, 7 green; 9 green, 3 blue; 3 blue, 9 green, 6 red; 4 blue, 1 red, 3 green; 4 green, 1 blue, 16 red\r\nGame 76: 4 blue, 3 green; 2 blue, 1 red, 6 green; 12 blue; 1 green, 14 blue\r\nGame 77: 5 green, 10 red, 11 blue; 3 red; 8 green, 6 red, 9 blue\r\nGame 78: 7 red, 7 green; 8 blue; 6 green, 7 red, 5 blue\r\nGame 79: 11 blue, 2 red, 4 green; 2 green, 3 red, 15 blue; 1 green, 15 blue, 1 red\r\nGame 80: 3 red, 17 green, 8 blue; 8 green, 10 blue; 4 green, 1 red, 14 blue\r\nGame 81: 17 green, 10 red, 10 blue; 9 green, 9 blue, 7 red; 11 red, 11 green, 4 blue; 15 blue, 5 red; 11 blue, 8 green, 15 red; 3 green, 16 red\r\nGame 82: 8 green, 9 blue, 1 red; 1 red, 8 green, 9 blue; 2 green, 12 blue\r\nGame 83: 2 green, 11 red, 20 blue; 20 blue, 1 green, 4 red; 2 green, 6 red, 20 blue; 17 blue, 10 red\r\nGame 84: 1 green, 9 red; 4 blue, 4 green; 1 green, 6 red, 14 blue\r\nGame 85: 5 red, 10 green, 9 blue; 8 blue, 3 green, 2 red; 4 blue, 14 green, 3 red; 5 red, 4 blue\r\nGame 86: 8 blue, 9 green, 5 red; 5 red, 10 green, 1 blue; 15 blue, 1 red, 2 green; 8 red, 8 blue, 10 green\r\nGame 87: 13 green, 2 red, 4 blue; 3 red, 11 green, 9 blue; 6 blue, 3 red, 12 green\r\nGame 88: 2 red, 7 blue, 3 green; 2 blue, 9 red; 9 red, 6 blue, 7 green; 6 green, 13 blue, 9 red; 6 green, 2 red, 15 blue; 1 red, 8 green, 7 blue\r\nGame 89: 11 red, 1 blue, 2 green; 6 blue, 5 green, 4 red; 15 red, 4 green, 5 blue; 11 red, 3 blue, 10 green; 6 blue, 13 green, 12 red\r\nGame 90: 2 red, 2 blue, 4 green; 2 red, 2 blue; 9 green, 1 red, 1 blue; 5 green, 1 red; 7 green, 2 red; 2 green, 1 blue\r\nGame 91: 5 blue, 3 red, 1 green; 1 red, 4 blue, 6 green; 6 blue, 6 green, 5 red\r\nGame 92: 16 green, 1 blue, 12 red; 18 green, 14 red, 1 blue; 16 red, 1 green; 4 blue, 16 red, 18 green\r\nGame 93: 9 red, 8 blue, 14 green; 1 blue, 1 green, 6 red; 4 blue, 4 red, 14 green\r\nGame 94: 11 green, 4 blue, 2 red; 1 red, 1 green, 1 blue; 4 red, 1 blue, 2 green\r\nGame 95: 5 blue, 2 red, 9 green; 5 blue, 8 green; 1 green, 15 blue; 5 red, 9 green, 5 blue; 3 green, 17 blue, 5 red\r\nGame 96: 2 green, 14 blue, 1 red; 3 green, 3 red, 14 blue; 2 red, 2 green, 13 blue\r\nGame 97: 2 green, 2 red; 2 blue, 1 green; 7 blue, 3 red\r\nGame 98: 2 red, 1 blue, 12 green; 2 blue, 10 green, 5 red; 11 green, 9 blue; 6 blue, 17 green; 7 blue, 9 green, 9 red; 1 red, 11 green, 9 blue\r\nGame 99: 2 green, 9 red, 1 blue; 3 green, 1 blue, 14 red; 5 green, 6 blue; 1 blue, 2 green, 3 red; 4 blue, 10 red, 1 green\r\nGame 100: 4 green, 4 blue, 15 red; 3 green, 1 red, 13 blue; 5 green, 5 blue, 10 red";
    }
}
