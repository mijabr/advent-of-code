using System.Text;

namespace AdventOfCodeTests.Year2022
{
    public class FullOfHotAir
    {
        public FullOfHotAir()
        {
        }

        public long ToInteger(string snafu)
        {
            long number = 0;
            long value = 1; 
            for (int pos = snafu.Length - 1; pos >= 0; pos--, value *= 5)
            {
                number += GetSnafuDigitValue(snafu[pos]) * value;
            }

            return number;
        }

        public int GetSnafuDigitValue(char snafuDigit) =>
            snafuDigit switch
            {
                '2' => 2,
                '1' => 1,
                '0' => 0,
                '-' => -1,
                '=' => -2,
                _ => throw new Exception("Bad snafu digit")
            };

        public string ToSnafu(long number)
        {
            long value = 1;
            while (value < number)
            {
                value *= 5;
            }

            var snafu = new StringBuilder();

            while (value >= 1)
            {
                var digitValue = (number + (value / 2) * Math.Sign(number)) / value;
                var snafuDigit = SnafuDigit(digitValue);
                if (snafu.Length > 0 || snafuDigit != '0')
                {
                    snafu.Append(snafuDigit);
                }
                number -= GetSnafuDigitValue(snafuDigit) * value;
                value /= 5;
            }

            return snafu.ToString();
        }

        private char SnafuDigit(long digit) =>
            digit switch
            {
                -1 => '-',
                -2 => '=',
                0 => '0',
                1 => '1',
                2 => '2',
                _ => throw new Exception($"Bad integer digit {digit}")
            };

        public string AddUpSnafus(string snafuList)
        {
            var snafus = snafuList.Split("\r\n");
            long total = 0;
            foreach (var snafu in snafus)
            {
                total += ToInteger(snafu);
            }

            return ToSnafu(total);
        }
    }
}
