using AdventOfCode.Util;
using System.Text;

namespace AdventOfCodeTests
{
    public class OceanFullOfCucumbers : Map
    {
        public OceanFullOfCucumbers(string map) : base(map)
        {
        }

        public int IterateTillStuck()
        {
            int moves = 0;
            bool didMove;
            do
            {
                didMove = Iterate();
                moves++;//= didMove ? 1 : 0; // hrrm, it counts the move where they don't move...

            }
            while (didMove && moves < 1000);

            return moves;
        }

        public bool Iterate()
        {
            var didMove = Move('>', 1, 0);
            didMove |= Move('v', 0, 1);
            return didMove;
        }

        private bool Move(char cucumber, int dx, int dy)
        {
            var didMove = false;
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    if (_map[x, y] == cucumber)
                    {
                        var destination = GetDestinationWithWrapping(x, y, dx, dy);
                        if (_map[destination.X, destination.Y] == '.')
                        {
                            _map[destination.X, destination.Y] = 'O';
                        }
                    }
                }
            }

            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    if (_map[x, y] == cucumber)
                    {
                        var destination = GetDestinationWithWrapping(x, y, dx, dy);
                        if (_map[destination.X, destination.Y] == 'O')
                        {
                            _map[x, y] = '.';
                            _map[destination.X, destination.Y] = cucumber;
                            didMove = true;
                        }
                    }
                }
            }

            return didMove;
        }
    }
}
