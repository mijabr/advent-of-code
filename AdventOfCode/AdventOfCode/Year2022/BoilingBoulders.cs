using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class BoilingBoulders : Map3D
    {
        public BoilingBoulders(string input) : base(input.Split("\r\n").Select(i => new Spot3D(i)))
        {
        }

        public void AddWater()
        {
            var didAddWater = true;
            while (didAddWater)
            {
                didAddWater = false;
                foreach (var spot in Spots)
                {
                    if (this[spot] == '.' && 
                        (IsLeftEdge(spot) || this[spot.Left] == 'o' ||
                        IsRightEdge(spot) || this[spot.Right] == 'o' ||
                        IsTopEdge(spot) || this[spot.Up] == 'o' ||
                        IsBottomEdge(spot) || this[spot.Down] == 'o' ||
                        IsCloseEdge(spot) || this[spot.Out] == 'o' ||
                        IsFarEdge(spot) || this[spot.In] == 'o'))
                    {
                        this[spot] = 'o';
                        didAddWater = true;
                    }
                }
            }
        }

        public int SurfaceArea(char outside = '.')
        {
            var area = 0;
            foreach (var spot in Spots)
            {
                if (this[spot] != '#') continue;

                if (IsLeftEdge(spot) || this[spot.Left] == outside)
                {
                    area++;
                }

                if (IsRightEdge(spot) || this[spot.Right] == outside)
                {
                    area++;
                }

                if (IsTopEdge(spot) || this[spot.Up] == outside)
                {
                    area++;
                }

                if (IsBottomEdge(spot) || this[spot.Down] == outside)
                {
                    area++;
                }

                if (IsCloseEdge(spot) || this[spot.Out] == outside)
                {
                    area++;
                }

                if (IsFarEdge(spot) || this[spot.In] == outside)
                {
                    area++;
                }
            }

            return area;
        }
    }
}
