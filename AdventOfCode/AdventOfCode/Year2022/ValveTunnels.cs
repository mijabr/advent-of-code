using AdventOfCode.Util;
using System.Text;

namespace AdventOfCodeTests.Year2022
{
    public class ValveTunnels
    {
        public Dictionary<string, Valve> Valves { get; }

        public ValveTunnels(string input)
        {
            Valves = input.Split("\r\n").Select(i => new Valve(i)).ToDictionary(v => v.Name);
        }

        public int FindMaximumPressureReleased()
        {
            var significantValves = Valves.Values.Where(v => v.FlowRate > 0).Select(v => v.Name).ToList();
            var orders = significantValves.OrderedCombinations();

            var progresses = new List<PressureRace> { new PressureRace() };

            return 0;
        }
    }

    public class Valve
    {
        public Valve(string input)
        {
            Name = input[6..8];
            FlowRate = input.Parse<int>(23);
            TunnelsTo = input[(input.IndexOf("valves ") + 7)..].Split(", ").ToList();
        }

        public string Name { get; set; }
        public int FlowRate { get; set; }
        public List<string> TunnelsTo { get; set; }
    }

    public class PressureRace
    {
        public int MinutesLeft { get; set; } = 30;
        public int PressureReleased { get; set; }
        public string CurrentLocation { get; set; } = "AA";
        public List<string> OpenValves { get;} = new();
    }
}
