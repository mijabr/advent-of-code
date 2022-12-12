using AdventOfCode.Util;
using System.Text;

namespace AdventOfCodeTests.Year2022
{
    public class HillClimb : Map
    {
        private readonly static char _empty = '.';

        public HillClimb(string input) : base(input)
        {
            Start = Spots.First(s => this[s] == 'S');
            End = Spots.First(s => this[s] == 'E');
            this[Start] = 'a';
            this[End] = 'z';
        }

        public int FindShortestPathToTopFromStart() => FindShortestPathToTop(Start);

        public int FindShortestPathToTopFromAnyLowest()
        {
            var lowestSpots = Spots.Where(s => this[s] == 'a').ToList();
            var moves = lowestSpots.Select(FindShortestPathToTop);
            return moves.Where(m => m > 0).Min();
        }

        private int FindShortestPathToTop(Spot start)
        {
            Start = start;
            var progresses = new List<Progress> { new Progress(Width, Height, Start) };
            var completes = new List<Progress>();
            var lowestMovesMap = new int[Width, Height];
            long interation = 1;
            long totalProgresses = 1;
            PrintProgress(interation, progresses.Count, totalProgresses, completes.Count);

            while (progresses.Count > 0)
            {
                var next = new List<Progress>();
                foreach (var progress in progresses)
                {
                    if (progress.Current.X < progress.Width - 1 &&
                        progress[progress.Current.X + 1, progress.Current.Y] == _empty &&
                        (Math.Abs(this[progress.Current.X, progress.Current.Y] - this[progress.Current.X + 1, progress.Current.Y]) <= 1 || this[progress.Current.X, progress.Current.Y] > this[progress.Current.X + 1, progress.Current.Y]))
                    {
                        var nextProgress = progress.Clone();
                        nextProgress.MoveRight();
                        if (lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] == 0 || nextProgress.Moves.Length < lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y])
                        {
                            lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] = nextProgress.Moves.Length;
                            if (nextProgress.Current == End)
                            {
                                completes.Add(nextProgress);
                            }
                            else
                            {
                                next.Add(nextProgress);
                            }
                        }
                    }

                    if (progress.Current.X > 0 &&
                        progress[progress.Current.X - 1, progress.Current.Y] == _empty &&
                        (Math.Abs(this[progress.Current.X, progress.Current.Y] - this[progress.Current.X - 1, progress.Current.Y]) <= 1 || this[progress.Current.X, progress.Current.Y] > this[progress.Current.X - 1, progress.Current.Y]))
                    {
                        var nextProgress = progress.Clone();
                        nextProgress.MoveLeft();
                        if (lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] == 0 || nextProgress.Moves.Length < lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y])
                        {
                            lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] = nextProgress.Moves.Length;
                            if (nextProgress.Current == End)
                            {
                                completes.Add(nextProgress);
                            }
                            else
                            {
                                next.Add(nextProgress);
                            }
                        }
                    }

                    if (progress.Current.Y < progress.Height - 1 &&
                        progress[progress.Current.X, progress.Current.Y + 1] == _empty &&
                        (Math.Abs(this[progress.Current.X, progress.Current.Y] - this[progress.Current.X, progress.Current.Y + 1]) <= 1 || this[progress.Current.X, progress.Current.Y] > this[progress.Current.X, progress.Current.Y + 1]))
                    {
                        var nextProgress = progress.Clone();
                        nextProgress.MoveDown();
                        if (lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] == 0 || nextProgress.Moves.Length < lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y])
                        {
                            lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] = nextProgress.Moves.Length;
                            if (nextProgress.Current == End)
                            {
                                completes.Add(nextProgress);
                            }
                            else
                            {
                                next.Add(nextProgress);
                            }
                        }
                    }

                    if (progress.Current.Y > 0 &&
                        progress[progress.Current.X, progress.Current.Y - 1] == _empty &&
                        (Math.Abs(this[progress.Current.X, progress.Current.Y] - this[progress.Current.X, progress.Current.Y - 1]) <= 1 || this[progress.Current.X, progress.Current.Y] > this[progress.Current.X, progress.Current.Y - 1]))
                    {
                        var nextProgress = progress.Clone();
                        nextProgress.MoveUp();
                        if (lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] == 0 || nextProgress.Moves.Length < lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y])
                        {
                            lowestMovesMap[nextProgress.Current.X, nextProgress.Current.Y] = nextProgress.Moves.Length;
                            if (nextProgress.Current == End)
                            {
                                completes.Add(nextProgress);
                            }
                            else
                            {
                                next.Add(nextProgress);
                            }
                        }
                    }
                }

                interation++;
                totalProgresses += next.Count;
                progresses = next;
                PrintProgress(interation, progresses.Count, totalProgresses, completes.Count);
            }

            return completes.Any() ? completes.Min(p => p.Moves.Length) : 0;
        }

        private void PrintProgress(long interation, int progressesCount, long totalProgresses, int completes)
        {
            //Console.WriteLine($"interation {interation} progress count {progressesCount} of {totalProgresses}. Solutions {completes}");
        }

        public Spot Start { get; private set; }
        public Spot End { get; private set; }

        private class Progress : Map
        {
            public Progress(int width, int height, Spot current) : base(width, height, _empty)
            {
                Current = current;
                this[Current] = 'X';
            }

            public Progress(Progress other) : base(other)
            {
                Current = other.Current;
                Moves.Append(other.Moves);
            }

            public Spot Current { get; set; }
            public StringBuilder Moves { get; } = new();

            public new Progress Clone() => new Progress(this);

            public void MoveRight()
            {
                Current = new Spot(Current.X + 1, Current.Y);
                this[Current] = 'X';
                Moves.Append('>');
            }

            public void MoveLeft()
            {
                Current = new Spot(Current.X - 1, Current.Y);
                this[Current] = 'X';
                Moves.Append('<');
            }

            public void MoveDown()
            {
                Current = new Spot(Current.X, Current.Y + 1);
                this[Current] = 'X';
                Moves.Append('v');
            }

            public void MoveUp()
            {
                Current = new Spot(Current.X, Current.Y - 1);
                this[Current] = 'X';
                Moves.Append('^');
            }
        }
    }
}
