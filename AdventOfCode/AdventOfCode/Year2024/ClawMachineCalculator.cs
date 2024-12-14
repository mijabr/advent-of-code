
using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class ClawMachineCalculator(string input, bool bigPrize = false)
    {
        public List<ClawMachine> Machines { get; } = input.Split("\r\n\r\n").Select(i => new ClawMachine(i, bigPrize)).ToList();

        public long FindMinimumTokenCost()
        {
            return Machines.Sum(m => bigPrize ? m.CostToWin() : m.CostToWinSlow());
        }
    }

    public class ClawMachine
    {
        public ClawMachine(string input, bool bigPrize)
        {
            var parts = input.Split("\r\n");
            ButtonAMovementX = parts[0].ParseAfter<long>("Button A: X+");
            ButtonAMovementY = parts[0].ParseAfter<long>("Y+");
            ButtonBMovementX = parts[1].ParseAfter<long>("Button B: X+");
            ButtonBMovementY = parts[1].ParseAfter<long>("Y+");
            PrizeX = parts[2].ParseAfter<long>("Prize: X=") + (bigPrize ? 10000000000000L : 0);
            PrizeY = parts[2].ParseAfter<long>("Y=") + (bigPrize ? 10000000000000L : 0);
        }

        public long ButtonAMovementX { get; }
        public long ButtonAMovementY { get; }
        public long ButtonBMovementX { get; }
        public long ButtonBMovementY { get; }
        public long PrizeX { get; }
        public long PrizeY { get; }

        public long CostToWin()
        {
            var bPress = (ButtonAMovementX * ButtonBMovementY - ButtonAMovementY * ButtonBMovementX) / (ButtonAMovementX * PrizeY - ButtonAMovementY * PrizeX);
            var aPress = (PrizeX - (ButtonBMovementX * bPress)) / ButtonAMovementX;
            Console.WriteLine($"A {aPress} B {bPress}");
            return aPress * 3 + bPress;
        }
        //94a + 22b = 10000000008400 and 34a + 67b = 10000000005400


        public long CostToWinSlow()
        {
            var aPress = 0;
            while (aPress * ButtonAMovementX < PrizeX)
            {
                var bPress = (PrizeX - (aPress * ButtonAMovementX)) / ButtonBMovementX;
                if (aPress * ButtonAMovementX + bPress * ButtonBMovementX == PrizeX)
                {
                    if (aPress * ButtonAMovementY + bPress * ButtonBMovementY == PrizeY)
                    {
                        return aPress * 3 + bPress;
                    }
                }

                aPress++;
            }

            return 0;
        }
    }
}
