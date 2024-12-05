using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class ManualPageOrder
    {
        public static long FindSumOfCorrectOrders(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var orders = parts[0].Split("\r\n").Select(o => new PageOrder(o)).ToList();
            var printRuns = parts[1].Split("\r\n").Select(p => new PrintRun(p)).ToList();
            var inOrderRuns = printRuns.Where(p => p.IsCorrectlyOrdered(orders));
            var sum = inOrderRuns.Select(p => p.Pages[p.Pages.Count / 2]).Sum();
            return sum;
        }

        public static object FindSumOfIncorrectOrders(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var orders = parts[0].Split("\r\n").Select(o => new PageOrder(o)).ToList();
            var printRuns = parts[1].Split("\r\n").Select(p => new PrintRun(p)).ToList();
            var incorrectOrderRuns = printRuns.Where(p => !p.IsCorrectlyOrdered(orders)).ToList();
            incorrectOrderRuns.ForEach(p => p.Reorder(orders));
            var sum = incorrectOrderRuns.Select(p => p.Pages[p.Pages.Count / 2]).Sum();
            return sum;
        }
    }

    public class PageOrder(string input)
    {
        public int Before { get; } = input.Split('|')[0].Parse<int>();
        public int After { get; } = input.Split('|')[1].Parse<int>();
    }

    public class PrintRun(string input)
    {
        public List<int> Pages { get; } = input.ParseNumbers<int>();

        public bool IsCorrectlyOrdered(List<PageOrder> orders)
        {
            for (int b = 0; b < Pages.Count - 1; b++)
            {
                for (int a = b + 1; a < Pages.Count; a++)
                {
                    if (orders.Any(o => o.Before == Pages[a] && o.After == Pages[b]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Reorder(List<PageOrder> orders)
        {
            bool didSwap = true;
            while (didSwap)
            {
                didSwap = false;
                for (int b = 0; b < Pages.Count - 1; b++)
                {
                    for (int a = b + 1; a < Pages.Count; a++)
                    {
                        if (orders.Any(o => o.Before == Pages[a] && o.After == Pages[b]))
                        {

                            didSwap = true;
                            var temp = Pages[a];
                            Pages[a] = Pages[b];
                            Pages[b] = temp;
                        }
                    }
                }
            }
        }
    }
}
