﻿using AdventOfCode.Util;

namespace AdventOfCodeTests.Util
{
    public class StringExtensionTests
    {
        [Test]
        public void IndexOfWithSkip_ShouldReturntheNthFoundItem()
        {
            var searchString = "cat-dog-cat-bird-cat-budgie";

            searchString.IndexOfNth("cat", 3).Should().Be(17);
        }

        [Test]
        public void IndexOfNoneOf_ShouldFindTheIndexOfTheFirstNonMatchingCharacter()
        {
            var searchString = "123 456 789";

            searchString.IndexOfNoneOf("1234567890".ToCharArray()).Should().Be(3);
            searchString.IndexOfNoneOf("1234567890".ToCharArray(), 4).Should().Be(7);
            searchString.IndexOfNoneOf("1234567890".ToCharArray(), 8).Should().Be(-1);
        }

        [Test]
        public void Parse_ShouldParseNumbersForInsideStrings()
        {
            var searchString = "123 456 789";

            searchString.Parse<int>().Should().Be(123);
            searchString.Parse<int>(4).Should().Be(456);
            searchString.Parse<int>(8).Should().Be(789);
        }
    }
}
