namespace AdventOfCodeTests.Year2021
{
    public class Day23Tests
    {
        //[Test]
        public void Test()
        {
            var organiser = new AmphipodOrganiser();

            var result = organiser.Organise("x");

            result.Should().Be(1);
        }

        //[Test]
        public void Test_ShouldGivenThePuzzleAnswer()
        {
            var organiser = new AmphipodOrganiser();

            var moves = organiser.Organise(_puzzleInput);

            moves.Should().Be(0);
        }

        private const string _puzzleInput = "#############\r\n#...........#\r\n###B#C#C#B###\r\n  #D#D#A#A#\r\n  #########";
    }
}
