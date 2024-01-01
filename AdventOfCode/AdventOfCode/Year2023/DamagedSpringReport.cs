using AdventOfCode.Util;
using System.Text;

namespace AdventOfCode.Year2023
{
    public class DamagedSpringReport
    {
        public DamagedSpringReport(string input)
        {
            Rows = input.Split("\r\n").Select(r => new DamagedRow(r)).ToList();
        }

        public List<DamagedRow> Rows { get; }

        public int SumDamagedRowPossibilties()
        {
            var sum = Rows.Sum(r => r.Possibilties);

            return sum;
        }
    }

    public class DamagedRow
    {
        public DamagedRow(string input)
        {
            var parts = input.Split(' ');
            Arrangement = parts[0];
            DamagedList = parts[1].ParseNumbers<int>().ToList();
            FindPossibilities();
        }

        public string Arrangement { get; set; }
        public List<int> DamagedList { get; set; }
        public int Possibilties { get; private set; }
        public List<List<int>> StartingPositions { get; } = new();

        private void FindPossibilities()
        {
            var allArrangements = new List<StringBuilder>();
            if (Arrangement[0] == '?')
            {
                allArrangements.Add(new StringBuilder("#"));
                allArrangements.Add(new StringBuilder("."));
            }
            else
            {
                allArrangements.Add(new StringBuilder(Arrangement[..1]));
            }

            for (int n = 1; n < Arrangement.Length; n++)
            {
                if (Arrangement[n] == '?')
                {
                    var more = new List<StringBuilder>();
                    foreach (var arrangement in allArrangements)
                    {
                        more.Add(new StringBuilder(arrangement.ToString() + '.'));
                        arrangement.Append('#');
                    }

                    allArrangements.AddRange(more);
                }
                else
                {
                    foreach (var arrangement in allArrangements)
                    {
                        arrangement.Append(Arrangement[n]);
                    }
                }
            }

            CheckPossibilities(allArrangements);
        }

        private void CheckPossibilities(List<StringBuilder> allArrangements)
        {
            for (int n = 0; n < DamagedList.Count; n++)
            {
                StartingPositions.Add(new List<int>());
            }

            foreach (var arrangement in allArrangements.Select(sb => sb.ToString()))
            {
                var good = true;
                int d = 0;
                int a = 0;
                while (a < arrangement.Length)
                {
                    if (arrangement[a] == '#')
                    {
                        if (d >= DamagedList.Count)
                        {
                            good = false;
                            break;
                        }

                        int index = arrangement.IndexOf('.', a);
                        if (index == -1)
                        {
                            index = arrangement.Length;
                        }
                        int available = index - a;

                        if (available == DamagedList[d])
                        {
                            a += DamagedList[d] + 1;
                            d++;
                        }
                        else
                        {
                            good = false;
                            break;
                        }
                    }
                    else
                    {
                        a++;
                    }
                }

                if (good && d == DamagedList.Count)
                {
                    Possibilties++;
                }
            }
        }
    }
}
