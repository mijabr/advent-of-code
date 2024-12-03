using AdventOfCode.Util;

namespace AdventOfCode.Year2024
{
    public class ComputerMultiplier
    {
        public static long AddValidMultipliers(string input, bool useEnableFunctions = false)
        {
            int index = 0;
            long result = 0;
            bool enabled = true;
            while (index < input.Length)
            {
                var doIndex = useEnableFunctions ? input.IndexOf("do()", index) : -1;
                var dontIndex = useEnableFunctions ? input.IndexOf("don't()", index) : -1;
                var mulIndex = input.IndexOf("mul(", index);

                if (doIndex != -1 && (mulIndex == -1 || mulIndex > doIndex) && (dontIndex == -1 || dontIndex > doIndex))
                {
                    enabled = true;
                    index = doIndex + 1;
                }

                if (dontIndex != -1 && (mulIndex == -1 || mulIndex > dontIndex) && (doIndex == -1 || doIndex > dontIndex))
                {
                    enabled = false;
                    index = dontIndex + 1;
                }

                if (mulIndex != -1 && (doIndex == -1 || doIndex > mulIndex) && (dontIndex == -1 || dontIndex > mulIndex))
                {
                    var endIndex = input.IndexOf(')', mulIndex);
                    if (endIndex != -1)
                    {
                        var mulInput = input.Substring(mulIndex + 4, endIndex - mulIndex - 4);
                        string[] numberStrings = mulInput.Split(',');
                        if (numberStrings.Length == 2 && numberStrings[0].All(char.IsDigit) && numberStrings[1].All(char.IsDigit))
                        {
                            var numbers = numberStrings.Select(n => n.Parse<int>()).ToList();
                            if (numbers[0] <= 999 && numbers[1] <= 999)
                            {
                                if (enabled)
                                {
                                    result += numbers[0] * numbers[1];
                                }
                            }
                        }
                    }

                    index = mulIndex + 1;
                }

                if (mulIndex == -1 && doIndex == -1 && dontIndex == -1)
                {
                    break;
                }
            }

            return result;
        }
    }
}
