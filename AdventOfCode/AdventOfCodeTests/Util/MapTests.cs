using AdventOfCode.Util;

namespace AdventOfCodeTests.Util
{
    public class MapTests
    {
        private class TestState
        {
            public Map Map { get; }

            public TestState(string? initial = null)
            {
                Map = new Map(initial ?? _defaultMap);
            }

            private const string _defaultMap =
@".v..
>...
....
vvvv";
        }

        [Test]
        public void Map_CanBeInitialised()
        {
            var map = new Map(".v\r\n>.");

            map.GetDimenstionLength(0).Should().Be(2);
            map.GetDimenstionLength(1).Should().Be(2);
            map[0, 0].Should().Be('.');
            map[1, 0].Should().Be('v');
            map[0, 1].Should().Be('>');
            map[1, 1].Should().Be('.');
        }

        [Test]
        public void Map_CanBeInitialised_WithUnevenStringLengths()
        {
            var map = new Map("123\r\n1234\r\n12345");

            map.Width.Should().Be(5);
            map.Height.Should().Be(3);
            map.ToString().Should().Be(
                "123..\r\n" +
                "1234.\r\n" +
                "12345\r\n"
            );
        }

        [Test]
        public void GetDestinationWithWrapping_ShouldReturnTheNextSpot()
        {
            var state = new TestState();

            var nextSpot = state.Map.GetDestinationWithWrapping(0, 0, 1, 1);

            nextSpot.Should().Be(new Spot(1, 1));
        }

        [Test]
        public void GetDestinationWithWrapping_ShouldReturnTheTopLeftSpot_GivenBottomRightSpot()
        {
            var state = new TestState();

            var nextSpot = state.Map.GetDestinationWithWrapping(3, 3, 1, 1);

            nextSpot.Should().Be(new Spot(0, 0));
        }

        [Test]
        public void GetDestinationWithWrapping_ShouldReturnTheBottomRightSpot_GivenTopLeftSpot_AndNegativeDirection()
        {
            var state = new TestState();

            var nextSpot = state.Map.GetDestinationWithWrapping(0, 0, -1, -1);

            nextSpot.Should().Be(new Spot(3, 3));
        }

        [Test]
        public void GetDestinationWithWrapping_ShouldReturnTheNearTopLeftSpot_GivenBottomRightSpot_AndMovingTwoSpots()
        {
            var state = new TestState();

            var nextSpot = state.Map.GetDestinationWithWrapping(3, 3, 2, 2);

            nextSpot.Should().Be(new Spot(1, 1));
        }

        [Test]
        public void GetDestinationWithWrapping_ShouldReturnTheNearBottomRightSpot_GivenTopLeftSpot_AndNegativeDirection_AndMovingTwoSpots()
        {
            var state = new TestState();

            var nextSpot = state.Map.GetDestinationWithWrapping(0, 0, -2, -2);

            nextSpot.Should().Be(new Spot(2, 2));
        }
    }
}
