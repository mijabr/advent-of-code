using AdventOfCode.Year2024;

namespace AdventOfCodeTests.Year2024
{
    public class Day11Tests
    {
        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveTestInput()
        {
            BlinkingStones.CountStonesAfterBlinking(_puzzleTestInput, 25).Should().Be(55312);
        }

        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveInput()
        {
            BlinkingStones.CountStonesAfterBlinking(_puzzleInput, 25).Should().Be(172484);
        }

        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveInputPart2()
        {
            BlinkingStones.CountStonesAfterBlinking(_puzzleInput, 75).Should().Be(205913561055242);
        }

        private const string _puzzleTestInput = "125 17";

        private const string _puzzleInput =
"20 82084 1650 3 346355 363 7975858 0";
    }
}
