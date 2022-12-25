namespace AdventOfCodeTests.Year2022
{
    public class Day11Tests
    {
        [Test]
        public void MonkeyBusiness_CanInitialiseMonkeys()
        {
            var monkeyBusiness = new MonkeyBusiness(_exampleInput);

            monkeyBusiness.Monkeys.Count.Should().Be(4);
            monkeyBusiness.Monkeys[0].Number.Should().Be(0);
            monkeyBusiness.Monkeys[0].Items.Should().BeEquivalentTo(new Queue<int>(new List<int> { 79, 98 }));
            monkeyBusiness.Monkeys[0].Operation.ToString().Should().Be("new = old * 19");
            monkeyBusiness.Monkeys[0].Test.Should().Be(23);
            monkeyBusiness.Monkeys[0].TrueMonkey.Should().Be(2);
            monkeyBusiness.Monkeys[0].FalseMonkey.Should().Be(3);

            monkeyBusiness.Monkeys[1].Number.Should().Be(1);
        }

        [Test]
        public void TotalMonkeyBusiness_ShouldReturnSumOfMadness_GivenExampleInput()
        {
            var monkeyBusiness = new MonkeyBusiness(_exampleInput);

            monkeyBusiness.RunRounds(20);

            monkeyBusiness.TotalMonkeyBusiness.Should().Be(10605);
        }


        [Test]
        public void TotalMonkeyBusiness_ShouldReturnSumOfMadness_GivenPuzzleInput()
        {
            var monkeyBusiness = new MonkeyBusiness(_puzzleInput);

            monkeyBusiness.RunRounds(20);

            monkeyBusiness.TotalMonkeyBusiness.Should().Be(56595);
        }

        //[Test]
        public void TotalMonkeyBusiness_ShouldReturnSumOfMadness_GivenExampleInput_AndNoDivideBy3()
        {
            var monkeyBusiness = new MonkeyBusiness(_exampleInput, divByThree: false);

            monkeyBusiness.RunRounds(10000);

            monkeyBusiness.TotalMonkeyBusiness.Should().Be(2713310158); // overflow dang it... 
        }

        //[Test]
        public void TotalMonkeyBusiness_ShouldReturnSumOfMadness_GivenPuzzleInput_AndNoDivideBy3()
        {
            var monkeyBusiness = new MonkeyBusiness(_puzzleInput, divByThree: false);

            monkeyBusiness.RunRounds(10000);

            monkeyBusiness.TotalMonkeyBusiness.Should().Be(0); // overflow dang it... 
        }

        private const string _exampleInput = "Monkey 0:\r\n  Starting items: 79, 98\r\n  Operation: new = old * 19\r\n  Test: divisible by 23\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 3\r\n\r\nMonkey 1:\r\n  Starting items: 54, 65, 75, 74\r\n  Operation: new = old + 6\r\n  Test: divisible by 19\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 0\r\n\r\nMonkey 2:\r\n  Starting items: 79, 60, 97\r\n  Operation: new = old * old\r\n  Test: divisible by 13\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 3\r\n\r\nMonkey 3:\r\n  Starting items: 74\r\n  Operation: new = old + 3\r\n  Test: divisible by 17\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 1";

        private const string _puzzleInput = "Monkey 0:\r\n  Starting items: 96, 60, 68, 91, 83, 57, 85\r\n  Operation: new = old * 2\r\n  Test: divisible by 17\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 5\r\n\r\nMonkey 1:\r\n  Starting items: 75, 78, 68, 81, 73, 99\r\n  Operation: new = old + 3\r\n  Test: divisible by 13\r\n    If true: throw to monkey 7\r\n    If false: throw to monkey 4\r\n\r\nMonkey 2:\r\n  Starting items: 69, 86, 67, 55, 96, 69, 94, 85\r\n  Operation: new = old + 6\r\n  Test: divisible by 19\r\n    If true: throw to monkey 6\r\n    If false: throw to monkey 5\r\n\r\nMonkey 3:\r\n  Starting items: 88, 75, 74, 98, 80\r\n  Operation: new = old + 5\r\n  Test: divisible by 7\r\n    If true: throw to monkey 7\r\n    If false: throw to monkey 1\r\n\r\nMonkey 4:\r\n  Starting items: 82\r\n  Operation: new = old + 8\r\n  Test: divisible by 11\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 2\r\n\r\nMonkey 5:\r\n  Starting items: 72, 92, 92\r\n  Operation: new = old * 5\r\n  Test: divisible by 3\r\n    If true: throw to monkey 6\r\n    If false: throw to monkey 3\r\n\r\nMonkey 6:\r\n  Starting items: 74, 61\r\n  Operation: new = old * old\r\n  Test: divisible by 2\r\n    If true: throw to monkey 3\r\n    If false: throw to monkey 1\r\n\r\nMonkey 7:\r\n  Starting items: 76, 86, 83, 55\r\n  Operation: new = old + 4\r\n  Test: divisible by 5\r\n    If true: throw to monkey 4\r\n    If false: throw to monkey 0";
    }
}
