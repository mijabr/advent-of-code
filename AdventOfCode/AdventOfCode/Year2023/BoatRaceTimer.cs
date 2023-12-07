using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public sealed record BoatRaceTime(long Time, long Distance)
    {
        public int GetWinningComboCount()
        {
            int winningComboCount = 0;
            for (long t = 1; t < Time; t++) {
                var distance = t * (Time - t);
                if (distance > Distance) winningComboCount++;
            }

            return winningComboCount;
        }
    }

    public class BoatRaceTimer
    {
        public List<BoatRaceTime> BoatRaceTimes { get; private set; }

        public BoatRaceTimer(string input, bool part2 = false)
        {
            var inputs = input.Split("\r\n");
            var times = ParseInputRow(inputs[0], part2);
            var distances = ParseInputRow(inputs[1], part2);
            BoatRaceTimes = times.Select((long time, int index) => new BoatRaceTime(time, distances[index])).ToList();
        }

        private static List<long> ParseInputRow(string input, bool part2) => (part2 ? input.Replace(" ", "") : input).ParseNumbers<long>();

        public int GetWinningComboProduct()
        {
            int[] winningCombos = BoatRaceTimes.Select(r => r.GetWinningComboCount()).ToArray();
            return winningCombos.Aggregate((int source, int accum) => source * accum);
        }
    }
}
