using AdventOfCode.Util;
using System.Text;

namespace AdventOfCodeTests.Year2022
{
    public class CommSignal
    {
        private readonly List<int> _cycleXValue = new();

        public CommSignal(string input)
        {
            var x = 1;
            var ops = input.Split("\r\n");

            foreach (var op in ops)
            {
                if (op == "noop")
                {
                    _cycleXValue.Add(x);
                }
                else
                {
                    var value = op.Parse<int>(5);
                    _cycleXValue.Add(x);
                    _cycleXValue.Add(x);
                    x += value;
                }
            }

        }

        public int GetStrengthSum()
        {
            return
                CycleStrength(20) +
                CycleStrength(60) +
                CycleStrength(100) +
                CycleStrength(140) +
                CycleStrength(180) +
                CycleStrength(220);
        }

        private int CycleStrength(int cycle) => _cycleXValue[cycle - 1] * cycle;

        public string GetImage()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _cycleXValue.Count; i++)
            {
                var x = i % 40;
                if (x >= _cycleXValue[i] - 1 && x <= _cycleXValue[i] + 1)
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('.');
                }

                if (x == 39)
                {
                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }
    }
}
