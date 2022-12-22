using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class GrovePositioningSystem
    {
        public List<GroveCoord> GroveCoords { get; }
        private readonly GroveCoord[] _groveCoordsOrder;

        public GrovePositioningSystem(string input, bool useKey = false)
        {
            GroveCoords = input.Split("\r\n").Select(i => new GroveCoord { Number = useKey ? i.Parse<long>() * _decryptionKey : i.Parse<long>() }).ToList();
            _groveCoordsOrder = GroveCoords.ToArray();
        }

        private const int _decryptionKey = 811589153;

        public void Mix(int times = 1)
        {
            for (int m = 0; m < times; m++)
            {
                foreach (var groveCoord in _groveCoordsOrder)
                {
                    var index = GroveCoords.IndexOf(groveCoord);
                    GroveCoords.Remove(groveCoord);
                    GroveCoords.Insert(AddToIndex(index, groveCoord.Number), groveCoord);
                }
            }
        }

        public int AddToIndex(int index, long add)
        {
            var nextIndex = index + add;
            if (nextIndex >= GroveCoords.Count)
            {
                nextIndex %= GroveCoords.Count;
            }
            if (nextIndex <= 0)
            {
                nextIndex %= GroveCoords.Count;
                nextIndex = GroveCoords.Count + nextIndex;
            }

            return (int)nextIndex;
        }

        public long FindGrove()
        {
            var zero = GroveCoords.Single(g => g.Number == 0);
            var indexOfZero = GroveCoords.IndexOf(zero);
            var at1000 = GroveCoords[AddToIndex(indexOfZero, 1000)];
            var at2000 = GroveCoords[AddToIndex(indexOfZero, 2000)];
            var at3000 = GroveCoords[AddToIndex(indexOfZero, 3000)];
            return at1000.Number + at2000.Number + at3000.Number;
        }
    }

    public class GroveCoord
    {
        public long Number { get; set; }
    }
}
