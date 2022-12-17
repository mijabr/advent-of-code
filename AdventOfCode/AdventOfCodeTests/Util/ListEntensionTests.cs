using AdventOfCode.Util;

namespace AdventOfCodeTests.Util
{
    public class ListEntensionTests
    {
        [Test]
        public void OrderedCombinations_ShouldReturnAllPossibleOrderedCombinations_GivenTwoItems()
        {
            var items = new List<string> { "A", "B" };

            var combos = items.OrderedCombinations();

            combos.Should().BeEquivalentTo(new List<List<string>>
            {
                new List<string> { "A", "B" },
                new List<string> { "B", "A" }
            });
        }

        [Test]
        public void OrderedCombinations_ShouldReturnAllPossibleOrderedCombinations_GivenThreeItems()
        {
            var items = new List<string> { "A", "B", "C" };

            var combos = items.OrderedCombinations();

            combos.Should().BeEquivalentTo(new List<List<string>>
            {
                new List<string> { "A", "B", "C" },
                new List<string> { "A", "C", "B" },
                new List<string> { "B", "A", "C" },
                new List<string> { "B", "C", "A" },
                new List<string> { "C", "A", "B" },
                new List<string> { "C", "B", "A" }
            });
        }
    }
}
