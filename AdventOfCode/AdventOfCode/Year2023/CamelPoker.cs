namespace AdventOfCode.Year2023
{
    public class CamelPoker
    {
        public CamelPoker(string input, bool jokers = false)
        {
            Hands = input.Split("\r\n").Select(r =>
            {
                var items = r.Split(' ');
                return new CamelPokerHand(items[0], long.Parse(items[1]), jokers);
            }).ToList();
            Hands.Sort();
        }

        public List<CamelPokerHand> Hands { get; private set; }

        public long GetWinnings()
        {
            long total = 0;
            for (int i = 0; i < Hands.Count; i++)
            {
                total += Hands[i].Bid * (i + 1);
            }

            return total;
        }
    }

    public class CamelPokerHand : IComparable<CamelPokerHand>
    {
        public CamelPokerHand(string camelPokerCards, long bid, bool jokers = false)
        {
            CamelPokerCards = camelPokerCards;
            Bid = bid;
            HandType = CalculateType(jokers);
            var cardOrder = jokers ? _cardOrderWithJokers : _cardOrder;
            CardRankings = camelPokerCards.Select(c => cardOrder.IndexOf(c)).ToArray();
        }

        private CamelPokerHandType CalculateType(bool jokers)
        {
            var dictionary = new Dictionary<char, int>();
            for (int n = 0; n < CamelPokerCards.Length; n++)
            {
                if (dictionary.ContainsKey(CamelPokerCards[n]))
                {
                    dictionary[CamelPokerCards[n]] = dictionary[CamelPokerCards[n]] + 1;
                }
                else
                {
                    dictionary[CamelPokerCards[n]] = 1;
                }
            }

            var jokerCount = 0;
            if (jokers && dictionary.TryGetValue('J', out var jc))
            {
                jokerCount = jc;
                dictionary.Remove('J');
            }

            if (dictionary.Values.Any(v => v == 5 - jokerCount) || jokerCount == 5)
            {
                return CamelPokerHandType.FiveOfAKind;
            }

            if (dictionary.Values.Any(v => v == 4 - jokerCount))
            {
                return CamelPokerHandType.FourOfAKind;
            }

            if (dictionary.Values.Count(v => v == 2) == 2 && jokerCount == 1)
            {
                return CamelPokerHandType.FullHouse;
            }

            if (dictionary.Values.Any(v => v == 3))
            {
                if (dictionary.Values.Any(v => v == 2))
                {
                    return CamelPokerHandType.FullHouse;
                }

                return CamelPokerHandType.ThreeOfAKind;
            }

            if (dictionary.Values.Any(v => v == 3 - jokerCount))
            {
                return CamelPokerHandType.ThreeOfAKind;
            }

            if (dictionary.Values.Count(v => v == 2) == 2)
            {
                return CamelPokerHandType.TwoPair;
            }

            if (dictionary.Values.Count(v => v == 2) == 1 || jokerCount > 0)
            {
                return CamelPokerHandType.OnePair;
            }

            return CamelPokerHandType.Nothing;
        }

        public int CompareTo(CamelPokerHand? other)
        {
            if (HandType > other?.HandType)
            {
                return 1;
            }
            else if (HandType == other?.HandType)
            {
                for (int n = 0; n < CardRankings.Length; n++)
                {
                    if (CardRankings[n] > other.CardRankings[n])
                    {
                        return 1;
                    }
                    else if (CardRankings[n] < other.CardRankings[n])
                    {
                        return -1;
                    }
                }

                return 0;
            }

            return -1;
        }

        public string CamelPokerCards { get; private set; }
        public long Bid { get; private set; }
        public int[] CardRankings { get; private set; }

        public CamelPokerHandType HandType { get; private set; }

        public static string _cardOrder = "23456789TJQKA";
        public static string _cardOrderWithJokers = "J23456789TQKA";
    }

    public enum CamelPokerHandType
    {
        Nothing,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
}
