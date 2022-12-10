using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class Forest : Map
    {
        public Forest(string map, char defaultContent = '.') : base(map, defaultContent)
        {
        }

        public int VisibleTrees => Spots.Count(IsVisible);

        private bool IsVisible(Spot s)
        {
            return IsVisibleFromWest(s) || IsVisibleFromEast(s) || IsVisibleFromNorth(s) || IsVisibleFromSouth( s);
        }

        private bool IsVisibleFromWest(Spot s)
        {
            for (int x = s.X - 1; x >= 0; x--)
            {
                if (this[s] <= this[x, s.Y])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsVisibleFromEast(Spot s)
        {
            for (int x = s.X + 1; x < GetDimenstionLength(0); x++)
            {
                if (this[s] <= this[x, s.Y])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsVisibleFromNorth(Spot s)
        {
            for (int y = s.Y - 1; y >= 0; y--)
            {
                if (this[s] <= this[s.X, y])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsVisibleFromSouth(Spot s)
        {
            for (int y = s.Y + 1; y < GetDimenstionLength(1); y++)
            {
                if (this[s] <= this[s.X, y])
                {
                    return false;
                }
            }

            return true;
        }

        public int FindScenicScore(Spot spot)
        {
            var w = FindWestScenicScore(spot);
            var e = FindEastScenicScore(spot);
            var s = FindSouthScenicScore(spot);
            var n = FindNorthScenicScore(spot);
            return w * e * s * n;
        }

        public int FindBestScenicScore()
        {
            return Spots.Max(FindScenicScore);
        }

        public int FindWestScenicScore(Spot s)
        {
            int score = 0;
            for (int x = s.X - 1; x >= 0; x--)
            {
                score++;
                if (this[s] <= this[x, s.Y]) break;
            }

            return score;
        }

        public int FindEastScenicScore(Spot s)
        {
            int score = 0;
            for (int x = s.X + 1; x < GetDimenstionLength(0); x++)
            {
                score++;
                if (this[s] <= this[x, s.Y]) break;
            }

            return score;
        }

        public int FindNorthScenicScore(Spot s)
        {
            int score = 0;
            for (int y = s.Y - 1; y >= 0; y--)
            {
                score++;
                if (this[s] <= this[s.X, y]) break;
            }

            return score;
        }

        public int FindSouthScenicScore(Spot s)
        {
            int score = 0;
            for (int y = s.Y + 1; y < GetDimenstionLength(1); y++)
            {
                score++;
                if (this[s] <= this[s.X, y]) break;
            }

            return score;
        }
    }
}
