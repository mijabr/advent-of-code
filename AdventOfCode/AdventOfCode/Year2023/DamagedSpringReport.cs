using AdventOfCode.Util;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Year2023
{
    public class DamagedSpringReport
    {
        public DamagedSpringReport(string input)
        {
            Rows = input.Split("\r\n").Select((r, i) => new DamagedRow(r, i)).ToList();
        }

        public List<DamagedRow> Rows { get; }

        public int SumDamagedRowPossibilties()
        {
            var sum = Rows.Sum(r => r.FindPossibilities());

            return sum;
        }

        public void Unfold()
        {
            Rows.ForEach(r => r.Unfold());
        }
    }

    public class DamagedRow
    {
        public DamagedRow(string input, int id)
        {
            Row = id + 1;
            var parts = input.Split(' ');
            Arrangement = parts[0];
            DamagedLength = parts[1].ParseNumbers<int>().ToList();
        }

        public int Row { get; }
        public string Arrangement { get; set; }
        public string FoldedArrangement { get; set; }
        public List<int> FoldedDamagedLength { get; set; }
        public List<int> DamagedLength { get; set; }
        public List<int> DamagedStartMin { get; set; }
        public List<int> DamagedStartMax { get; set; }
        public bool Unfolded { get; set; }
        public bool Power5 { get; set; }

        public void Unfold()
        {
            FoldedArrangement = Arrangement;
            FoldedDamagedLength = DamagedLength.ToArray().ToList();
            Arrangement = string.Join('?', Enumerable.Range(1, 5).Select(n => Arrangement));
            DamagedLength.AddRange(Enumerable.Range(1, 4).SelectMany(n => DamagedLength).ToList());
            Unfolded = true;
        }

        public int FindPossibilities()
        {
            OptimiseArragement();

            var timer = Stopwatch.StartNew();
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

            for (int a = 1; a < Arrangement.Length; a++)
            {
                if (Arrangement[a] == '?')
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
                        arrangement.Append(Arrangement[a]);
                    }
                }

                var originalCount = allArrangements.Count;
                allArrangements = CullInvalid(allArrangements);
                if (timer.Elapsed.TotalSeconds > 15)
                {
                    Console.WriteLine($"Row:{Row} {a}/{Arrangement.Length} culled {originalCount - allArrangements.Count} - {allArrangements.Count} remain - time: {timer.Elapsed}");
                }
            }

            var a2 = allArrangements.Count;
            //allArrangements = CheckPossibilities(allArrangements);
            //Console.WriteLine($"Row:{Row} {Arrangement.Length}/{Arrangement.Length} culled {a2 - allArrangements.Count} - {allArrangements.Count} remain - time: {timer.Elapsed}");

            var possibilities = allArrangements.Count;
            
            if (Power5)
            {
                possibilities = possibilities * possibilities * possibilities * possibilities * possibilities;
            }

            return possibilities;
        }

        public void OptimiseArragement()
        {
            var originala = Arrangement;
            FindDamagedStartsMinimums();
            FindDamagedStartsMaximums();
            int a = 0;
            var optimised = new StringBuilder();
            while (a < Arrangement.Length)
            {
                if (Arrangement[a] == '?')
                {
                    int dd = -1;
                    for (int d = 0; d < DamagedLength.Count; d++)
                    {
                        if (a >= DamagedStartMin[d] && a < DamagedStartMax[d] + DamagedLength[d])
                        {
                            dd = d;
                        }
                    }

                    if (dd == -1)
                    {
                        optimised.Append('.');
                    }
                    else if (a >= DamagedStartMax[dd] && a < DamagedStartMin[dd] + DamagedLength[dd])
                    {
                        optimised.Append('#');
                    }
                    else
                    {
                        optimised.Append('?');
                    }
                }
                else
                {
                    optimised.Append(Arrangement[a]);
                }

                a++;
            }

            Arrangement = optimised.ToString();

            if (Unfolded)
            {
                var fifth = (Arrangement.Length / 5) + 1;
                var p1 = Arrangement.Substring(0, fifth);
                var p2 = Arrangement.Substring(fifth, fifth);
                var p3 = Arrangement.Substring(fifth * 2, fifth);
                var p4 = Arrangement.Substring(fifth * 3, fifth);
                var p5 = Arrangement.Substring(fifth * 4, fifth - 1) + '.';
                if (p1 == p2 && p1 == p3 && p1 == p4 && p1 == p5)
                {
                    Power5 = true;
                    Arrangement = FoldedArrangement;
                    DamagedLength = FoldedDamagedLength;
                }
            }

            Console.WriteLine($"Optimsed {originala} {string.Join(',', DamagedLength)} to {Arrangement} Power5:{Power5}");
        }

        public void FindDamagedStartsMinimums()
        {
            DamagedStartMin = new();
            int d = 0;
            int a = 0;
            while (a < Arrangement.Length && d < DamagedLength.Count)
            {
                if (Arrangement[a] == '#' || Arrangement[a] == '?')
                {
                    int sectionEnd = Arrangement.IndexOf('.', a);
                    if (sectionEnd == -1)
                    {
                        sectionEnd = Arrangement.Length;
                    }

                    int available = sectionEnd - a;
                    int available2 = available;
                    int a2 = a;
                    while (d < DamagedLength.Count && available2 >= DamagedLength[d])
                    {
                        if (a2 + DamagedLength[d] < Arrangement.Length &&
                            Arrangement[a2 + DamagedLength[d]] == '#' &&
                            Arrangement[a2] == '?')
                        {
                            a2++;
                            available2--;
                            continue;
                        }

                        DamagedStartMin.Add(a2);
                        available2 -= DamagedLength[d] + 1;
                        a2 += DamagedLength[d] + 1;
                        d++;
                    }

                    a += available;
                }
                else
                {
                    a++;
                }
            }
        }

        public void FindDamagedStartsMaximums()
        {
            DamagedStartMax = new();
            int d = DamagedLength.Count - 1;
            int a =  0;
            var arrangement = new string(Arrangement.Reverse().ToArray());
            while (a < arrangement.Length && d >= 0)
            {
                if (arrangement[a] == '#' || arrangement[a] == '?')
                {
                    int sectionEnd = arrangement.IndexOf('.', a);
                    if (sectionEnd == -1)
                    {
                        sectionEnd = arrangement.Length;
                    }

                    int available = sectionEnd - a;
                    int available2 = available;
                    int a2 = a;
                    while (d >= 0 && available2 >= DamagedLength[d])
                    {
                        if (a2 + DamagedLength[d] < Arrangement.Length &&
                            arrangement[a2 + DamagedLength[d]] == '#' &&
                            arrangement[a2] == '?')
                        {
                            a2++;
                            available2--;
                            continue;
                        }

                        DamagedStartMax.Add(arrangement.Length - a2 - DamagedLength[d]);
                        available2 -= DamagedLength[d] + 1;
                        a2 += DamagedLength[d] + 1;
                        d--;
                    }

                    a += available;
                }
                else
                {
                    a++;
                }
            }

            DamagedStartMax.Reverse();
        }

        private List<StringBuilder> CullInvalid(List<StringBuilder> allArrangements)
        {
            var keepers = new List<StringBuilder>();
            for (int n = 0; n < allArrangements.Count; n++)
            {
                var arrangement = allArrangements[n].ToString();
                var good = true;
                int d = 0;
                int a = 0;
                while (a < arrangement.Length)
                {
                    if (arrangement[a] == '#')
                    {
                        if (d >= DamagedLength.Count)
                        {
                            good = false;
                            break;
                        }

                        int index = arrangement.IndexOf('.', a);
                        if (index == -1)
                        {
                            break;
                        }
                        int available = index - a;

                        if (available == DamagedLength[d])
                        {
                            a += DamagedLength[d] + 1;
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

                if (good)
                {
                    keepers.Add(allArrangements[n]);
                }
            }

            return keepers;
        }

        private List<StringBuilder> CheckPossibilities(List<StringBuilder> allArrangements)
        {
            var possibilties = new List<StringBuilder>();

            for (int n = 0; n < allArrangements.Count; n++)
            {
                var arrangement = allArrangements[n].ToString();
                var good = true;
                int d = 0;
                int a = 0;
                while (a < arrangement.Length)
                {
                    if (arrangement[a] == '#')
                    {
                        if (d >= DamagedLength.Count)
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

                        if (available == DamagedLength[d])
                        {
                            a += DamagedLength[d] + 1;
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

                if (good && d == DamagedLength.Count)
                {
                    possibilties.Add(allArrangements[n]);
                }
            }

            return possibilties;
        }
    }
}
