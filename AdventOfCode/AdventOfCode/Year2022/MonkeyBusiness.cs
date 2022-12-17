using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class MonkeyBusiness
    {
        public readonly List<Monkey> Monkeys = new();

        public MonkeyBusiness(string input, bool divByThree = true)
        {
            foreach (var monkeyInput in input.Split("\r\n\r\n"))
            {
                var m = new Monkey(monkeyInput, divByThree);
                Monkeys.Add(m);
            }
        }

        public void RunRounds(int rounds)
        {
            while (rounds-- > 0)
            {
                foreach (var monkey in Monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        (long item, var monkeyNumber) = monkey.ThrowItem();
                        Monkeys[monkeyNumber].Items.Enqueue(item);
                    }
                }
            }
        }

        public long TotalMonkeyBusiness => Monkeys.OrderByDescending(m => m.InspectedCount).Take(2).Aggregate(1, (int total, Monkey m) => total * m.InspectedCount);
    }

    public class Monkey
    {
        private readonly bool _divByThree;

        public Monkey(string input, bool divByThree)
        {
            var lines = input.Split("\r\n");
            Number = lines[0].Parse<int>(7);
            foreach (var item in lines[1][18..].Split(", ").Select(i => i.Parse<int>()))
            {
                Items.Enqueue(item);
            }
            Operation = new(lines[2][19..]);
            Test = lines[3].Parse<int>(21);
            TrueMonkey = lines[4].Parse<int>(29);
            FalseMonkey = lines[5].Parse<int>(30);
            _divByThree = divByThree;
        }

        public int Number { get; set; }
        public Queue<long> Items { get; } = new();
        public MonkeyOperation Operation { get; }
        public int Test { get; }
        public int TrueMonkey { get; }
        public int FalseMonkey { get; }
        public int InspectedCount { get; private set; }

        public (long item, int monkeyNumber) ThrowItem()
        {
            InspectedCount++;
            long item = Items.Dequeue();
            item = Operation.Operate(item);
            if (_divByThree)
            {
                item /= 3;
            }
            return (item, item % Test == 0 ? TrueMonkey : FalseMonkey);
        }
    }

    public class MonkeyOperation
    {
        public MonkeyOperation(string input)
        {
            var parts = input.Split(' ');
            Operand1 = parts[0];
            Operation = parts[1];
            Operand2 = parts[2];
        }

        public string Operand1 { get; set; }
        public string Operation { get; set; }
        public string Operand2 { get; set; }

        public long Operate(long old) => ApplyOperation(GetValue(Operand1, old), GetValue(Operand2, old));

        private long ApplyOperation(long o1, long o2) =>
            Operation switch
            {
                "*" => o1 * o2,
                "+" => o1 + o2,
                _ => throw new Exception($"Unknown operation {Operation}")
            };

        private static long GetValue(string operand, long old) =>
            operand switch
            {
                "old" => old,
                _ => operand.Parse<long>()
            };

        public override string ToString() => $"new = {Operand1} {Operation} {Operand2}";
    }
}
