using AdventOfCode.Util;
using System.Text;

namespace AdventOfCode.Year2023
{
    public class GondolaPartCalculator
    {
        public GondolaPartCalculator(string input)
        {
            Map = new Map(input.Split("\r\n"));
        }

        public Map Map { get; private set; }

        public int SumPartNumbers()
        {
            var map = Map.Clone();
            var partNumbers = new List<int>();
            foreach (var spot in map.Spots)
            {
                if (char.IsDigit(map[spot]) && ExtractPartNumber(map, spot, out int partNumber))
                {
                    partNumbers.Add(partNumber);
                }
            }

            return partNumbers.Sum();
        }

        private bool ExtractPartNumber(Map map, Spot spot, out int partNumber)
        {
            var partNumberString = new StringBuilder();
            bool isNearSymbol = false;
            while (spot.X < map.Width && char.IsDigit(map[spot]))
            {
                partNumberString.Append(map[spot]);
                map[spot] = '.';
                if (!Map.IsTopEdge(spot))
                {
                    if (!Map.IsLeftEdge(spot) && IsSymbol(map[spot.NorthWest]))
                    {
                        isNearSymbol = true;
                    }
                    if (IsSymbol(map[spot.North]))
                    {
                        isNearSymbol = true;
                    }
                    if (!Map.IsRightEdge(spot) && IsSymbol(map[spot.NorthEast]))
                    {
                        isNearSymbol = true;
                    }
                }

                if (!Map.IsLeftEdge(spot) && IsSymbol(map[spot.West]))
                {
                    isNearSymbol = true;
                }
                if (!Map.IsRightEdge(spot) && IsSymbol(map[spot.East]))
                {
                    isNearSymbol = true;
                }

                if (!Map.IsBottomEdge(spot))
                {
                    if (!Map.IsLeftEdge(spot) && IsSymbol(map[spot.SouthWest]))
                    {
                        isNearSymbol = true;
                    }
                    if (IsSymbol(map[spot.South]))
                    {
                        isNearSymbol = true;
                    }
                    if (!Map.IsRightEdge(spot) && IsSymbol(map[spot.SouthEast]))
                    {
                        isNearSymbol = true;
                    }
                }

                spot = spot.East;
            }

            partNumber = partNumberString.ToString().Parse<int>();
            return isNearSymbol;
        }

        private static bool IsSymbol(char c) => c != '.' && !char.IsDigit(c);

        public int SumGearRatios()
        {
            var map = Map.Clone();
            var gearRatios = new List<int>();
            foreach (var spot in map.Spots)
            {
                if (map[spot] == '*')
                {
                    if (GetGearRatio(map, spot, out int gearRatio))
                    {
                        gearRatios.Add(gearRatio);
                    }
                }
            }

            return gearRatios.Sum();
        }

        private bool GetGearRatio(Map map, Spot spot, out int gearRatio)
        {
            var startingSpots = new HashSet<Spot>();
            if (!Map.IsTopEdge(spot))
            {
                if (!Map.IsLeftEdge(spot) && char.IsDigit(map[spot.NorthWest]))
                {
                    startingSpots.Add(FindPartStart(map, spot.NorthWest));
                }
                if (char.IsDigit(map[spot.North]))
                {
                    startingSpots.Add(FindPartStart(map, spot.North));
                }
                if (!Map.IsRightEdge(spot) && char.IsDigit(map[spot.NorthEast]))
                {
                    startingSpots.Add(FindPartStart(map, spot.NorthEast));
                }
            }

            if (!Map.IsLeftEdge(spot) && char.IsDigit(map[spot.West]))
            {
                startingSpots.Add(FindPartStart(map, spot.West));
            }
            if (!Map.IsRightEdge(spot) && char.IsDigit(map[spot.East]))
            {
                startingSpots.Add(spot.East);
            }

            if (!Map.IsBottomEdge(spot))
            {
                if (!Map.IsLeftEdge(spot) && char.IsDigit(map[spot.SouthWest]))
                {
                    startingSpots.Add(FindPartStart(map, spot.SouthWest));
                }
                if (char.IsDigit(map[spot.South]))
                {
                    startingSpots.Add(FindPartStart(map, spot.South));
                }
                if (!Map.IsRightEdge(spot) && char.IsDigit(map[spot.SouthEast]))
                {
                    startingSpots.Add(FindPartStart(map, spot.SouthEast));
                }
            }

            if (startingSpots.Count == 2)
            {
                gearRatio = FindGearRatio(startingSpots, map);
                return true;
            }

            gearRatio = 0;
            return false;
        }

        private int FindGearRatio(HashSet<Spot> startingSpots, Map map)
        {
            var gearPartNumbers = startingSpots.Select(spot =>
            {
                var gearPartNumberString = new StringBuilder();
                gearPartNumberString.Append(map[spot]);

                while (!Map.IsRightEdge(spot) && char.IsDigit(map[spot.East]))
                {
                    spot = spot.East;
                    gearPartNumberString.Append(map[spot]);
                }

                return gearPartNumberString.ToString().Parse<int>();
            }).ToList();

            return gearPartNumbers[0] * gearPartNumbers[1];
        }

        private static Spot FindPartStart(Map map, Spot spot)
        {
            while (!Map.IsLeftEdge(spot) && char.IsDigit(map[spot.West]))
            {
                spot = spot.West;
            }

            return spot;
        }
    }
}
