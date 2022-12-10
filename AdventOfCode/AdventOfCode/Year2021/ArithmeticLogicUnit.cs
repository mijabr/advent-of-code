using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2021
{
    public class ArithmeticLogicUnit
    {
        public long W { get; private set; }
        public long X { get; private set; }
        public long Y { get; private set; }
        public long Z { get; private set; }

        public string FindHighestModelNumber_WIP(string puzzleInput)
        {
            char[] modelNumber;
            var pos = 13;
            var digit = '9';
            do
            {
                modelNumber = "89999999999999".ToArray();
                modelNumber[pos] = digit;
                RunInstructions(puzzleInput, new string(modelNumber));
                if (Z == 0) return new string(modelNumber);
                Console.WriteLine($"{new string(modelNumber)} failed Z == {Z}");
                digit--;
                if (digit == '0') { digit = '9'; pos--; }
            } while (false);

            return new string(modelNumber);
        }

        public string FindHighestModelNumber_TakesTooLong(string puzzleInput)
        {
            var modelNumber = 99999999999999;
            do
            {
                RunInstructions(puzzleInput, modelNumber.ToString());
                if (Z == 0) return modelNumber.ToString();
                Console.WriteLine($"{modelNumber} invalid as Z = {Z}");
                do
                {
                    modelNumber--;
                } while (modelNumber.ToString().Contains('0'));
            } while (Z != 0);

            return modelNumber.ToString();
        }

        public void RunInstructions(string instructions, string input)
        {
            W = 0;
            X = 0;
            Y = 0;
            Z = 0;
            var inputQueue = new Queue<int>(input.Select(i => int.Parse(i.ToString())));
            instructions.Split("\r\n").ToList().ForEach(i => RunInstruction(i, inputQueue));
        }

        private void RunInstruction(string instruction, Queue<int> input)
        {
            var ins = instruction.Split(" ");
            switch (ins[0])
            {
                case "inp": Input(ins[1], input); break;
                case "add": Add(ins[1], ins[2]); break;
                case "mul": Multiply(ins[1], ins[2]); break;
                case "div": Divide(ins[1], ins[2]); break;
                case "mod": Modulo(ins[1], ins[2]); break;
                case "eql": Compare(ins[1], ins[2]); break;
            }
        }

        private void Input(string variable, Queue<int> input)
        {
            SetVariable(variable, input.Dequeue());
            Console.WriteLine($"W = {W} X = {X} Y = {Y} Z = {Z}");
        }

        private void Add(string variable, string b)
        {
            SetVariable(variable, GetValue(variable) + GetValue(b));
        }

        private void Multiply(string variable, string b)
        {
            SetVariable(variable, GetValue(variable) * GetValue(b));
        }

        private void Divide(string variable, string b)
        {
            SetVariable(variable, GetValue(variable) / GetValue(b));
        }

        private void Modulo(string variable, string b)
        {
            SetVariable(variable, GetValue(variable) % GetValue(b));
        }

        private void Compare(string variable, string b)
        {
            SetVariable(variable, GetValue(variable) == GetValue(b) ? 1 : 0);
        }

        private void SetVariable(string variable, long value)
        {
            switch (variable)
            {
                case "w": W = value; break;
                case "x": X = value; break;
                case "y": Y = value; break;
                case "z": Z = value; break;
            };
        }

        private long GetValue(string variable) =>
            variable switch
            {
                "w" => W,
                "x" => X,
                "y" => Y,
                "z" => Z,
                _ => int.Parse(variable)
            };
    }
}
