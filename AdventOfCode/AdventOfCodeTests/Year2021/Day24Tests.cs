using AdventOfCode.Year2021;

namespace AdventOfCodeTests.Year2021
{
    public class Day24Tests
    {
        [Test]
        public void RunInstructions_CanInputValues()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w", "1");

            alu.W.Should().Be(1);
        }

        [Test]
        public void RunInstructions_CanAddVariable()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\nadd w x", "12");

            alu.W.Should().Be(3);
        }

        [Test]
        public void RunInstructions_CanAddValue()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\nadd w 2", "1");

            alu.W.Should().Be(3);
        }

        [Test]
        public void RunInstructions_CanMultiplyVariable()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\nmul w x", "23");

            alu.W.Should().Be(6);
        }

        [Test]
        public void RunInstructions_CanMultiplyValue()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\nmul w 3", "2");

            alu.W.Should().Be(6);
        }

        [Test]
        public void RunInstructions_CanDivideVariable()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\ndiv w x", "82");

            alu.W.Should().Be(4);
        }

        [Test]
        public void RunInstructions_CanModuloValue()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\nmod w 4", "9");

            alu.W.Should().Be(1);
        }

        [Test]
        public void RunInstructions_CanModuloVariable()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\nmod w x", "94");

            alu.W.Should().Be(1);
        }

        [Test]
        public void RunInstructions_CanDivideValue()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ndiv w 2", "8");

            alu.W.Should().Be(4);
        }

        [Test]
        public void RunInstructions_CanCompareVariable()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\neql w x", "44");

            alu.W.Should().Be(1);
        }

        [Test]
        public void RunInstructions_CanCompareVariable_GivenNotEqual()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\ninp x\r\neql w x", "54");

            alu.W.Should().Be(0);
        }

        [Test]
        public void RunInstructions_CanCompareValue()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\neql w 4", "4");

            alu.W.Should().Be(1);
        }

        [Test]
        public void RunInstructions_CanCompareValue_GivenNotEqual()
        {
            var alu = new ArithmeticLogicUnit();

            alu.RunInstructions("inp w\r\neql w 5", "4");

            alu.W.Should().Be(0);
        }

        //[Test]
        public void Test_ShouldGivenThePuzzleAnswer()
        {
            var alu = new ArithmeticLogicUnit();

            var result = alu.FindHighestModelNumber_WIP(_puzzleInput);

            result.Should().Be("99999999999999");
        }

        //[Test]
        public void Test_ShouldGivenThePuzzleAnswer2()
        {
            var alu = new ALU();

            var result = alu.PartOne(_puzzleInput);
            Console.WriteLine(result);
            result.Should().Be("94399898949959");
        }

        private const string _puzzleInput = "inp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 12\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 14\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 12\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 11\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -9\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 12\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -7\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 11\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 2\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -1\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 11\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -16\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 11\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 10\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -15\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 2\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 10\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 0\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 1\r\nadd x 12\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 0\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x -4\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y\r\ninp w\r\nmul x 0\r\nadd x z\r\nmod x 26\r\ndiv z 26\r\nadd x 0\r\neql x w\r\neql x 0\r\nmul y 0\r\nadd y 25\r\nmul y x\r\nadd y 1\r\nmul z y\r\nmul y 0\r\nadd y w\r\nadd y 15\r\nmul y x\r\nadd z y";
    }
}
