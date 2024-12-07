using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class RopeBridgeCalibrator
    {
        public static long FindSumOfTrueEquations(string input, bool includeConcatOperator = false)
        {
            var equations = input.Split("\r\n").Select(r => new RopeBridgeEquation(r)).ToList();
            var grandTotal = 0L;
            foreach (var equation in equations)
            {
                if (equation.CanBeTrue(includeConcatOperator))
                {
                    grandTotal += equation.Total;
                }
            }

            return grandTotal;
        }
    }

    public class RopeBridgeEquation(string input)
    {
        public List<long> Values { get; set; } = input.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => n.Parse<long>()).ToList();
        public long Total { get; set; } = input.Split(':')[0].Parse<long>();

        public bool CanBeTrue(bool includeConcatOperator)
        {
            var operationStack = new Stack<(long Total, Operation Op)>();

            while (true)
            {
                var total = operationStack.Count > 0 ? operationStack.Peek().Total : Values[0];
                while (operationStack.Count < Values.Count - 1)
                {
                    total = PerformOperation(total, Values[operationStack.Count + 1], Operation.Plus);
                    operationStack.Push((total, Operation.Plus));
                }

                if (total == Total) return true;

                var item = operationStack.Pop();
                while ((item.Op == Operation.Multiply && !includeConcatOperator) || item.Op == Operation.Concat)
                {
                    if (operationStack.Count == 0) return false;
                    item = operationStack.Pop();
                }

                var lastTotal = operationStack.Count > 0 ? operationStack.Peek().Total : Values[0];
                var op = item.Op + 1;
                total = PerformOperation(lastTotal, Values[operationStack.Count + 1], op);
                operationStack.Push((total, op));
            }
        }

        private static long PerformOperation(long v1, long v2, Operation operation) =>
            operation switch
            {
                Operation.Plus => v1 + v2,
                Operation.Multiply => v1 * v2,
                Operation.Concat => v1 * (long)Math.Pow(10, (Math.Floor(Math.Log10(v2)) + 1)) + v2,
                //Operation.Concat => v1 * (long)Math.Pow(10, ($"{v2}".Length)) + v2,
                //Operation.Concat => $"{v1}{v2}".Parse<long>(),
                _ => throw new NotImplementedException()
            };

        private enum Operation
        {
            Plus,
            Multiply,
            Concat,
            Invalid
        }
    }
}
