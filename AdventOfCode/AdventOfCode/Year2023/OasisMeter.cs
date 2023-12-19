using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class OasisMeter
    {
        public OasisMeter(string input)
        {
            var rows = input.Split("\r\n");
            Sequences = rows.Select(r => r.ParseNumbers<long>()).ToList();
        }

        public List<List<long>> Sequences { get; private set; }

        public long SumOfNextInSequences() => Sequences.Sum(NextInSequence);

        public long SumOfPreviousInSequences() => Sequences.Sum(PreviousInSequence);

        public static long NextInSequence(List<long> sequence)
        {
            var stack = BuildStack(sequence);
            long nextAnswer = 0;
            while (stack.Count > 0)
            {
                var seq = stack.Pop();
                nextAnswer = seq.Last() + nextAnswer;
            }

            return nextAnswer;
        }

        public static long PreviousInSequence(List<long> sequence)
        {
            var stack = BuildStack(sequence);
            long previousAnswer = 0;
            while (stack.Count > 0)
            {
                var seq = stack.Pop();
                previousAnswer = seq.First() - previousAnswer;
            }

            return previousAnswer;
        }

        private static Stack<List<long>> BuildStack(List<long> sequence)
        {
            var stack = new Stack<List<long>>();
            stack.Push(sequence);

            while (stack.Peek().Any(n => n != 0))
            {
                stack.Push(stack.Peek().GetDiffs().ToList());
            }

            return stack;
        }
    }

    public static class LongExtensions
    {
        public static IEnumerable<long> GetDiffs(this List<long> list)
        {
            int pos = 0;
            while (pos < list.Count - 1)
            {
                yield return list[pos + 1] - list[pos];
                pos++;
            }
        }
    }
}
