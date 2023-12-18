using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class CubeCounter
    {
        public CubeCounter(string input)
        {
            CubeGames = input.Split("\r\n").Select(row => new CubeGame(row)).ToList();
        }

        public List<CubeGame> CubeGames { get; private set; }

        public int GetSumOfPossibleGames(int maxRed, int maxGreen, int maxBlue)
        {
            return CubeGames.Where(g => g.CubeGameSelections.All(s => s.Reds <= maxRed && s.Greens <= maxGreen && s.Blues <= maxBlue)).Sum(g => g.GameNumber);
        }

        public int GetSumOfPower()
        {
            return CubeGames.Sum(g =>
            {
                int maxRed = g.CubeGameSelections.Max(s => s.Reds);
                int maxGreen = g.CubeGameSelections.Max(s => s.Greens);
                int maxBlue = g.CubeGameSelections.Max(s => s.Blues);
                return maxRed * maxGreen * maxBlue;
            });
        }

        public class CubeGame
        {
            public CubeGame(string row)
            {
                GameNumber = row.ParseAfter<int>("Game ");
                CubeGameSelections = row.Split(':')[1].Split(';').Select(s => new CubeGameSelections(s)).ToList();
            }

            public int GameNumber { get; private set; }
            public List<CubeGameSelections> CubeGameSelections { get; private set; }
        }

        public class CubeGameSelections
        {
            public CubeGameSelections(string input)
            {
                Reds = FindNumberOf(input, "red");
                Greens = FindNumberOf(input, "green");
                Blues = FindNumberOf(input, "blue");
            }

            private static int FindNumberOf(string input, string colour)
            {
                var colourIndex = input.IndexOf(colour);
                if (colourIndex == -1)
                {
                    return 0;
                }

                var numberIndex = colourIndex - 2;
                while (Char.IsAsciiDigit(input[numberIndex - 1])) numberIndex--;
                return input.Parse<int>(numberIndex);
            }

            public int Reds { get; set; }
            public int Greens { get; set; }
            public int Blues { get; set; }
        }
    }
}
