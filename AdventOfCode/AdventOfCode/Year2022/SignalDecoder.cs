using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class SignalDecoder
    {
        public List<PacketPair> Pairs { get; } = new();

        public SignalDecoder(string input)
        {
            var pairs = input.Split("\r\n\r\n");
            foreach (var pair in pairs)
            {
                Pairs.Add(new PacketPair(pair));
            }
        }

        public int SumOfCorrectlyOrderedPairs()
        {
            int sum = 0;
            for (int index = 0; index < Pairs.Count; index++)
            {
                if (Pairs[index].AreInOrder())
                {
                    sum += index + 1;
                }
            }

            return sum;
        }

        public int GetDecoderKey()
        {
            var packets = Pairs.SelectMany(p => new List<Packet> { p.First, p.Second }).ToList();
            var divider1 = new Packet("[[2]]");
            var divider2 = new Packet("[[6]]");
            packets.Add(divider1);
            packets.Add(divider2);

            var packetComparer = new PacketComparer();
            packets.Sort(packetComparer);

            var index1 = packets.IndexOf(divider1) + 1;
            var index2 = packets.IndexOf(divider2) + 1;
            return index1 * index2;
        }
    }

    public class Packet
    {
        public Packet(string input)
        {
            (_, Content) = Parse(input);
        }

        public List<object> Content { get; }


        private (int, List<object>) Parse(string input, int pos = 0)
        {
            if (input[pos] != '[') throw new Exception("Should be a list!");
            var l = new List<object>();
            pos++;

            while (input[pos] != ']')
            {
                if (input[pos] == '[')
                {
                    (pos, var l2) = Parse(input, pos);
                    l.Add(l2);
                }
                else if (input[pos] == ',')
                {
                    pos++;
                }
                else
                {
                    l.Add(input.Parse<int>(pos));
                    pos = input.IndexOfNoneOf("0123456789".ToArray(), pos);
                }

            }

            return (++pos, l);
        }
    }

    public class PacketPair
    {
        public Packet First { get; }
        public Packet Second { get; }

        public PacketPair(string input)
        {
            var pairs = input.Split("\r\n");
            First = new Packet(pairs[0]);
            Second = new Packet(pairs[1]);
        }

        public bool AreInOrder()
        {
            return PacketComparer.CompareIntOrList(First.Content, Second.Content) < 0;
        }
    }

    public class PacketComparer : IComparer<Packet>
    {
        public int Compare(Packet? x, Packet? y)
        {
            return CompareIntOrList(x?.Content ?? new List<object>(), y?.Content ?? new List<object>());
        }

        public static int CompareIntOrList(object first, object second)
        {
            if (first is int firstInt && second is int secondInt)
            {
                return firstInt - secondInt;
            }

            if (first is int && second is List<dynamic>)
            {
                first = new List<dynamic>() { first };
            }

            if (second is int && first is List<dynamic>)
            {
                second = new List<object>() { second };
            }

            if (first is List<object> firstList && second is List<object> secondList)
            {
                int i = 0;
                while (i < Math.Max(firstList.Count, secondList.Count))
                {
                    if (i >= firstList.Count) return -1;
                    if (i >= secondList.Count) return 1;

                    var result = CompareIntOrList(firstList[i], secondList[i]);
                    if (result != 0)
                    {
                        return result;
                    }

                    i++;
                }
            }

            return 0;
        }
    }
}
