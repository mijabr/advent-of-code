using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class SignalDecoder
    {
        private List<PacketPair> _pairs = new();

        public SignalDecoder(string input)
        {
            var pairs = input.Split("\r\n\r\n");
            foreach (var pair in pairs)
            {
                _pairs.Add(new PacketPair(pair));
            }
        }

        public int SumOfCorrectlyOrderedPairs()
        {
            return 0;
        }
    }

    public class PacketPair
    {
        private List<dynamic> _first;
        private List<dynamic> _second;

        public PacketPair(string input)
        {
            var pairs = input.Split("\r\n");
            (_, _first) = Parse(pairs[0]);
            (_, _second) = Parse(pairs[1]);
        }

        private (int, List<dynamic>) Parse(string input, int n = 0)
        {
            if (input[0] != '[') throw new Exception("Should be a list!");
            var l = new List<dynamic>();
            n++;
            while (n < input.Length)
            {
                if ("0123456789".Contains(input[n]))
                {
                    l.Add(input.Parse<int>(n));
                    n = input.IndexOfAny(new char[] { ',', ']' }, n);
                }
                else if (input[n] == '[')
                {
                    (var len, List<dynamic> items) = Parse(input, n);
                    l.Add(items);
                    n += len;
                }
                else if (input[n] == ']')
                {
                    return (n, l);
                }
                else if (input[n] == ',')
                {
                    n++;
                }
            }

            throw new Exception("bracket miss match?");
        }
    }
}
