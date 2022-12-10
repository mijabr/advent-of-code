namespace AdventOfCodeTests.Year2022
{
    public class DayXTests
    {
        [Test]
        public void Test_ShouldFindThePuzzleAnswerForPart1()
        {
            var thing = new ThingX();

            var result = thing.CountSomething(_puzzleInput);

            result.Should().Be(0);
        }

        private const string _puzzleInput = "";
    }
}
