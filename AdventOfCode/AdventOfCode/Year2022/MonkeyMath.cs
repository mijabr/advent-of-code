using AdventOfCode.Util;
using System.Data.SqlTypes;

namespace AdventOfCodeTests.Year2022
{
    public class MonkeyMath
    {
        public Dictionary<string, ShoutingMonkey> Monkeys { get; set; }

        public MonkeyMath(string input)
        {
            Monkeys = input.Split("\r\n").Select(i => new ShoutingMonkey(i)).ToDictionary(m => m.Name, m => m);
        }

        public void DoShouting()
        {
            while (Monkeys["root"].Number == null)
            {
                foreach(var monkey in Monkeys.Values)
                {
                    if (monkey.Number != null)
                    {
                        continue;
                    }

                    if (Monkeys[monkey.MonkeyLeft].Number != null && Monkeys[monkey.MonkeyRight].Number != null)
                    {
                        monkey.Shout(Monkeys[monkey.MonkeyLeft].Number, Monkeys[monkey.MonkeyRight].Number);
                    }
                }
            }
        }

        public double WhatShouldHumnShout()
        {
            bool shouting = true;
            while (shouting)
            {
                shouting = false;
                foreach (var monkey in Monkeys.Values)
                {
                    if (monkey.Name == "humn")
                    {
                        continue;
                    }

                    if (monkey.Number != null)
                    {
                        continue;
                    }


                    if (Monkeys[monkey.MonkeyLeft].Number != null && Monkeys[monkey.MonkeyRight].Number != null)
                    {
                        monkey.Shout(Monkeys[monkey.MonkeyLeft].Number, Monkeys[monkey.MonkeyRight].Number);
                        shouting = true;
                    }
                }
            }

            Console.WriteLine($"monkey root says: {Monkeys[Monkeys["root"].MonkeyLeft].Sum(Monkeys)} == {Monkeys[Monkeys["root"].MonkeyRight].Sum(Monkeys)}");
            var monkeyLeft = Monkeys[Monkeys["root"].MonkeyLeft];
            var monkeyRight = Monkeys[Monkeys["root"].MonkeyRight];
            var monkeyValue = monkeyLeft.Number != null ? monkeyLeft : monkeyRight;
            var monkeyNext = monkeyLeft.Number != null ? monkeyRight : monkeyLeft;

            double value = monkeyValue.Number.HasValue ? monkeyValue.Number.Value : 0;
            var ops = new List<Op>();
            monkeyNext.FindOps(Monkeys, ops);

            foreach (var op in ops)
            {
                var before = value;
                value = ReverseOp(value, op);
                Console.WriteLine($"{before} {op.OperationUndo} {op.Number} = {value}");
            }

            return value;
        }

        private double ReverseOp(double value, Op op)
        {
            if (op.OperationUndo == '/')
            {
                var remainder = value % op.Number;
                if (remainder != 0)
                {
                    //throw new Exception("dang");
                }
            }

            return op.OperationUndo switch
            {
                '+' => value + op.Number,
                '-' => value - op.Number,
                '/' => value / op.Number,
                '*' => value * op.Number,
                _ => throw new Exception("Bad operation")
            };
        }
    }

    public class ShoutingMonkey
    {
        public ShoutingMonkey(string input)
        {
            Name = input[..4];
            if ("0123456789".Contains(input[6]))
            {
                Number = input.Parse<long>(6);
                MonkeyLeft = string.Empty;
                MonkeyRight = string.Empty;
            }
            else
            {
                MonkeyLeft = input[6..10];
                Operation = input[11];
                MonkeyRight = input[13..17];
            }
        }

        public string Name { get; set; }
        public double? Number { get; set; }
        public string MonkeyLeft { get; set; }
        public char Operation { get; set; }
        public string MonkeyRight { get; set; }

        public void Shout(double? number1, double? number2)
        {
            Number = Operation switch
            {
                '-' => number1 - number2,
                '+' => number1 + number2,
                '*' => number1 * number2,
                '/' => number1 / number2,
                _ => throw new Exception("Bad operation")
            };
        }

        public void FindOps(Dictionary<string, ShoutingMonkey> monkeys, List<Op> ops)
        {
            if (Number != null || Name == "humn")
            {
                return;
            }

            var monkeyLeft = monkeys[MonkeyLeft];
            var monkeyRight = monkeys[MonkeyRight];
            var monkeyValue = monkeyLeft.Number != null ? monkeyLeft : monkeyRight;
            var monkeyNext = monkeyLeft.Number != null ? monkeyRight : monkeyLeft;

            ops.Add(new Op { Operation = Operation, Number = monkeyValue.Number.HasValue ? monkeyValue.Number.Value : 0});

            monkeyNext.FindOps(monkeys, ops);
        }

        public string Sum(Dictionary<string, ShoutingMonkey> monkeys)
        {
            if (Name == "humn") return Name;
            if (Number != null)
            {
                return Number.Value.ToString();
            }

            return $"({monkeys[MonkeyLeft].Sum(monkeys)} {Operation} {monkeys[MonkeyRight].Sum(monkeys)})";
        }
    }

    public class Op
    {
        public char Operation { get; set; }
        public char OperationUndo => Operation switch
        {
            '-' => '+',
            '+' => '-',
            '/' => '*',
            '*' => '/',
            _ => throw new NotSupportedException()
        };

        public double Number { get; set; }
    }
}
