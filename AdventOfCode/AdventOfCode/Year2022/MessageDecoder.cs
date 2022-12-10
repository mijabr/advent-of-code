namespace AdventOfCodeTests.Year2022
{
    public class MessageDecoder
    {
        public int FindUniqueOffset(string input, int uniqueCount)
        {
            int index = uniqueCount - 1;
            while (Enumerable.Range(0, uniqueCount).Select(n => input[index - n]).Distinct().Count() != uniqueCount)
            {
                index++;
            }

            return index + 1;
        }
    }
}
