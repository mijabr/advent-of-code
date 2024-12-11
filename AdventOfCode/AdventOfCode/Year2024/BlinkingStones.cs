using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class BlinkingStones
    {
        public static long CountStonesAfterBlinking(string input, int blinks)
        {
            var stones = new Dictionary<long, long>();

            foreach (var stone in input.ParseNumbers<long>())
            {
                if (stones.TryGetValue(stone, out var stoneCount))
                {
                    stones[stone] = stoneCount + 1;
                }
                else
                {
                    stones[stone] = 1;
                }
            }

            while (blinks > 0)
            {
                var stones2 = new Dictionary<long, long>();

                void AddStone(long stone, long count)
                {
                    if (stones2.TryGetValue(stone, out var stoneCount))
                    {
                        stones2[stone] = stoneCount + count;
                    }
                    else
                    {
                        stones2[stone] = count;
                    }
                }

                foreach (var stone in stones)
                {
                    if (stone.Key == 0)
                    {
                        AddStone(1, stone.Value);
                    }
                    else if ($"{stone.Key}".Length % 2 == 0)
                    {
                        var s = $"{stone.Key}";
                        AddStone(s.Substring(0, s.Length / 2).Parse<long>(), stone.Value);
                        AddStone(s.Substring(s.Length / 2, s.Length / 2).Parse<long>(), stone.Value);
                    }
                    else
                    {
                        AddStone(stone.Key * 2024, stone.Value);
                    }
                }

                stones = stones2;

                blinks--;
            }

            return stones.Values.Sum();
        }
    }
}
