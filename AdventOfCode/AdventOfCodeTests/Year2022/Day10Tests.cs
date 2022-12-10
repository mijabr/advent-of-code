namespace AdventOfCodeTests.Year2022
{
    public class Day10Tests
    {
        [Test]
        public void Test_ShouldFindThePuzzleAnswerForExample1()
        {
            var signal = new CommSignal("addx 15\r\naddx -11\r\naddx 6\r\naddx -3\r\naddx 5\r\naddx -1\r\naddx -8\r\naddx 13\r\naddx 4\r\nnoop\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx -35\r\naddx 1\r\naddx 24\r\naddx -19\r\naddx 1\r\naddx 16\r\naddx -11\r\nnoop\r\nnoop\r\naddx 21\r\naddx -15\r\nnoop\r\nnoop\r\naddx -3\r\naddx 9\r\naddx 1\r\naddx -3\r\naddx 8\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx -36\r\nnoop\r\naddx 1\r\naddx 7\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\naddx 6\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx 7\r\naddx 1\r\nnoop\r\naddx -13\r\naddx 13\r\naddx 7\r\nnoop\r\naddx 1\r\naddx -33\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx 8\r\nnoop\r\naddx -1\r\naddx 2\r\naddx 1\r\nnoop\r\naddx 17\r\naddx -9\r\naddx 1\r\naddx 1\r\naddx -3\r\naddx 11\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx -13\r\naddx -19\r\naddx 1\r\naddx 3\r\naddx 26\r\naddx -30\r\naddx 12\r\naddx -1\r\naddx 3\r\naddx 1\r\nnoop\r\nnoop\r\nnoop\r\naddx -9\r\naddx 18\r\naddx 1\r\naddx 2\r\nnoop\r\nnoop\r\naddx 9\r\nnoop\r\nnoop\r\nnoop\r\naddx -1\r\naddx 2\r\naddx -37\r\naddx 1\r\naddx 3\r\nnoop\r\naddx 15\r\naddx -21\r\naddx 22\r\naddx -6\r\naddx 1\r\nnoop\r\naddx 2\r\naddx 1\r\nnoop\r\naddx -10\r\nnoop\r\nnoop\r\naddx 20\r\naddx 1\r\naddx 2\r\naddx 2\r\naddx -6\r\naddx -11\r\nnoop\r\nnoop\r\nnoop");

            var result = signal.GetStrengthSum();

            result.Should().Be(13140);
            
        }

        [Test]
        public void Test_ShouldFindThePuzzleAnswerForPart1()
        {
            var signal = new CommSignal(_puzzleInput);

            var result = signal.GetStrengthSum();

            result.Should().Be(16060);
        }

        [Test]
        public void Test_ShouldFindThePuzzleAnswerForPart2()
        {
            var signal = new CommSignal(_puzzleInput);

            var result = signal.GetImage();

            Console.WriteLine(result);
            result.Should().Be(
"###...##...##..####.#..#.#....#..#.####.\r\n" +
"#..#.#..#.#..#.#....#.#..#....#..#.#....\r\n" +
"###..#..#.#....###..##...#....####.###..\r\n" +
"#..#.####.#....#....#.#..#....#..#.#....\r\n" +
"#..#.#..#.#..#.#....#.#..#....#..#.#....\r\n" +
"###..#..#..##..####.#..#.####.#..#.#....\r\n");
        }

        private const string _puzzleInput = "noop\r\naddx 10\r\naddx -4\r\naddx -1\r\nnoop\r\nnoop\r\naddx 5\r\naddx -12\r\naddx 17\r\nnoop\r\naddx 1\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 2\r\nnoop\r\nnoop\r\naddx 7\r\naddx 3\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\naddx 1\r\naddx -38\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx -4\r\naddx 26\r\naddx -19\r\naddx 2\r\naddx 5\r\naddx -2\r\naddx 7\r\naddx -2\r\naddx 5\r\naddx 2\r\naddx 4\r\naddx -17\r\naddx -23\r\naddx 1\r\naddx 5\r\naddx 3\r\nnoop\r\naddx 2\r\naddx 24\r\naddx 4\r\naddx -23\r\nnoop\r\naddx 5\r\naddx -1\r\naddx 6\r\nnoop\r\naddx -2\r\nnoop\r\nnoop\r\nnoop\r\naddx 7\r\naddx 1\r\naddx 4\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx -37\r\naddx 5\r\naddx 2\r\naddx 1\r\nnoop\r\naddx 4\r\naddx -2\r\naddx -4\r\naddx 9\r\naddx 7\r\nnoop\r\nnoop\r\naddx 2\r\naddx 3\r\naddx -2\r\nnoop\r\naddx -12\r\naddx 17\r\nnoop\r\naddx 3\r\naddx 2\r\naddx -3\r\naddx -30\r\naddx 3\r\nnoop\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 11\r\naddx -6\r\nnoop\r\naddx 2\r\naddx -19\r\naddx 20\r\naddx -7\r\naddx 14\r\naddx 8\r\naddx -7\r\naddx 2\r\naddx -26\r\naddx -7\r\nnoop\r\nnoop\r\naddx 5\r\naddx -2\r\naddx 5\r\naddx 15\r\naddx -13\r\naddx 5\r\nnoop\r\nnoop\r\naddx 1\r\naddx 4\r\naddx 3\r\naddx -2\r\naddx 4\r\naddx 1\r\nnoop\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop";
    }
}
