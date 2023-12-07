namespace AdventOfCode.Year2023
{
    public class TrebuchetCalibration
    {
        private string[] _rows;

        public TrebuchetCalibration(string input)
        {
            _rows = input.Split("\r\n");
        }

        public long GetSum()
        {
            int total = 0;
            for (int i = 0; i < _rows.Length; i++)
            {
                var digit1 = _rows[i][_rows[i].IndexOfAny("0123456789".ToArray())];
                var digit2 = _rows[i][_rows[i].LastIndexOfAny("0123456789".ToArray())];
                total += int.Parse(new char[] { digit1, digit2 });
            }

            return total;
        }

        public long GetSumIncludingStringNumbers()
        {
            int total = 0;
            for (int i = 0; i < _rows.Length; i++)
            {
                var digit1 = _calibrationDigits
                    .Select(c => new IndexValueTuple(_rows[i].IndexOf(c.Key), c.Value))
                    .Where(c => c.Index > -1)
                    .OrderBy(c => c.Index)
                    .First()
                    .Value;
                var digit2 = _calibrationDigits
                    .Select(c => new IndexValueTuple(_rows[i].LastIndexOf(c.Key), c.Value))
                    .Where(c => c.Index > -1)
                    .OrderBy(c => c.Index)
                    .Last()
                    .Value;
                total += digit1 * 10 + digit2;
            }

            return total;
        }

        private sealed record IndexValueTuple(int Index, int Value);

        private static Dictionary<string, int> _calibrationDigits = new Dictionary<string, int>()
        {
            ["0"] = 0,
            ["1"] = 1,
            ["2"] = 2,
            ["3"] = 3,
            ["4"] = 4,
            ["5"] = 5,
            ["6"] = 6,
            ["7"] = 7,
            ["8"] = 8,
            ["9"] = 9,
            ["zero"] = 0,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9
        };
    }
}
