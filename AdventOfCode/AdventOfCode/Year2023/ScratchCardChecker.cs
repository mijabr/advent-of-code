using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class ScratchCardChecker
    {
        public ScratchCardChecker(string input)
        {
            ScratchCards = input.Split("\r\n").Select(i => new ScratchCard(i)).ToList();
        }

        public List<ScratchCard> ScratchCards { get; private set; }
        public int TotalPoints => ScratchCards.Sum(c => c.Points);

        public int CountScratchCards()
        {
            var cardCounts = ScratchCards.Select(c => 1).ToList();
            for (int card = 0; card < ScratchCards.Count; card++)
            {
                int cardsWon = ScratchCards[card].MatchingNumbers;
                int cardAdd = card + 1;
                while (cardsWon > 0)
                {
                    cardCounts[cardAdd++] += cardCounts[card];
                    cardsWon--;
                }
            }

            return cardCounts.Sum();
        }
    }

    public class ScratchCard
    {
        public ScratchCard(string input)
        {
            var parts = input.Split(":");
            var numberSections = parts[1].Split("|");
            WinningNumbers = numberSections[0].ParseNumbers<int>();
            PlayerNumbers = numberSections[1].ParseNumbers<int>();
        }

        public List<int> WinningNumbers { get; set; }
        public List<int> PlayerNumbers { get; set; }
        public int MatchingNumbers => PlayerNumbers.Intersect(WinningNumbers).Count();
        public int Points => MatchingNumbers == 0 ? 0 : 1 << (MatchingNumbers - 1);
    }
}
