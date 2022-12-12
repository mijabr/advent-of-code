using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class MonkeyBusiness
    {
        public readonly List<Monkey> Monkeys = new();

        public MonkeyBusiness(string input)
        {
            foreach (var monkeyInput in input.Split("\r\n\r\n"))
            {
                var m = new Monkey(monkeyInput);
                Monkeys.Add(m);
            }
        }

        public void RunRounds(int rounds)
        {
        }
    }

    public class Monkey
    {
        public Monkey(string input)
        {
            var lines = input.Split("\r\n");
            Number = lines[0].Parse<int>(7);
            foreach (var item in lines[1][18..].Split(", ").Select(i => i.Parse<int>()))
            {
                Items.Enqueue(item);
            }
            Operation = new(lines[2][19..]);
        }

        public int Number { get; set; }
        public Queue<int> Items { get; } = new();
        public MonkeyOperation Operation { get; }
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

        public override string ToString() => $"new = {Operand1} {Operation} {Operand2}";
    }
}
