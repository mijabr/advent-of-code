using AdventOfCode.Util;
using System.Text;

namespace AdventOfCodeTests.Year2022
{
    public class CrateCrane
    {
        public string GetTopCrates(string input, bool p2)
        {
            var parts = input.Split("\r\n\r\n");

            Dictionary<int, Stack<char>> stacks = GetStacks(parts[0]);

            var moves = parts[1].Split("\r\n");
            foreach (var move in moves.Where(m => m.StartsWith("move")))
            {
                var count = move.Parse<int>(5);
                var from = move[move.IndexOf("from") + 5];
                var to = move[move.IndexOf("to") + 3];

                if (p2)
                {
                    var crane = new Stack<char>();
                    for (int i = 0; i < count; i++)
                    {
                        crane.Push(stacks[from].Pop());
                    }

                    for (int i = 0; i < count; i++)
                    {
                        stacks[to].Push(crane.Pop());
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        stacks[to].Push(stacks[from].Pop());
                    }
                }
            }

            var sb = new StringBuilder();
            foreach (var stack in stacks.Values)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString();
        }

        public Dictionary<int, Stack<char>> GetStacks(string stacksinput)
        {
            var stacksMap = new Map(stacksinput);
            var stacks = new Dictionary<int, Stack<char>>();
            for (int x = 1; x < stacksMap.GetDimenstionLength(0); x += 4)
            {
                var stackNumber = stacksMap[x, stacksMap.GetDimenstionLength(1) - 1];
                stacks[stackNumber] = GetStack(stacksMap, x);
            }

            return stacks;
        }

        public Stack<char> GetStack(Map stacksMap, int x)
        {
            var stack = new Stack<char>();
            for (int y = stacksMap.GetDimenstionLength(1) - 1; y >= 0 && stacksMap[x, y] != ' '; y--)
            {
                stack.Push(stacksMap[x, y]);
            }

            return stack;
        }
    }
}
