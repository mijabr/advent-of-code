namespace AdventOfCodeTests.Year2022
{
    public class RockPaperScissors
    {
        private const char HimRock = 'A';
        private const char HimPaper = 'B';
        private const char HimScissors = 'C';
        private const char MeRock = 'X';
        private const char MePaper = 'Y';
        private const char MeScissors = 'Z';
        private const char ResultLose = 'X';
        private const char ResultDraw = 'Y';
        private const char ResultWin = 'Z';
        private const int LoseScore = 0;
        private const int DrawScore = 3;
        private const int WinScore = 6;

        public int CalculateScore(string input)
        {
            var games = input.Split("\r\n");
            var score = 0;
            foreach (var game in games)
            {
                var him = game[0];
                var me = game[2];
                score += GetTypeScore(me);
                score += GetResultScore(him, me);
            }

            return score;
        }

        public int CalculateScorePart2(string input)
        {
            var games = input.Split("\r\n");
            var score = 0;
            foreach (var game in games)
            {
                var him = game[0];
                var result = game[2];
                var me = GetMeFromResult(him, result);
                score += GetTypeScore(me);
                score += GetResultScore(him, me);
            }

            return score;
        }

        private static int GetResultScore(char him, char me) =>
            (him, me) switch
            {
                (HimRock, MeRock) => DrawScore,
                (HimRock, MePaper) => WinScore,
                (HimRock, MeScissors) => LoseScore,
                (HimPaper, MeRock) => LoseScore,
                (HimPaper, MePaper) => DrawScore,
                (HimPaper, MeScissors) => WinScore,
                (HimScissors, MeRock) => WinScore,
                (HimScissors, MePaper) => LoseScore,
                (HimScissors, MeScissors) => DrawScore,
                _ => throw new Exception("Bad Result")
            };

        private static char GetMeFromResult(char him, char result) =>
            (him, result) switch
            {
                (HimRock, ResultLose) => MeScissors,
                (HimRock, ResultDraw) => MeRock,
                (HimRock, ResultWin) => MePaper,
                (HimPaper, ResultLose) => MeRock,
                (HimPaper, ResultDraw) => MePaper,
                (HimPaper, ResultWin) => MeScissors,
                (HimScissors, ResultLose) => MePaper,
                (HimScissors, ResultDraw) => MeScissors,
                (HimScissors, ResultWin) => MeRock,
                _ => throw new Exception("Bad Me"),
            };

        private static int GetTypeScore(char me) =>
            me switch
            {
                MeRock => 1,
                MePaper => 2,
                MeScissors => 3,
                _ => throw new Exception($"Bad me")
            };
    }
}
