﻿namespace AdventOfCodeTests.Year2022
{
    public class Day09Tests
    {
        [Test]
        public void Move_ShouldFindThePuzzleAnswerForExample1()
        {
            var thing = new RopeSimulator();

            var result = thing.Move("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 2);

            result.Should().Be(13);
        }

        [Test]
        public void Test_ShouldFindThePuzzleAnswerForPart1()
        {
            var thing = new RopeSimulator();

            var result = thing.Move(_puzzleInput, 2);

            result.Should().Be(6256);
        }

        [Test]
        public void Test_ShouldFindThePuzzleAnswerForPart2()
        {
            var thing = new RopeSimulator();

            var result = thing.Move(_puzzleInput, 10);

            result.Should().Be(2665);
        }

        private const string _puzzleInput = "L 2\r\nU 2\r\nR 2\r\nL 1\r\nR 1\r\nU 1\r\nD 1\r\nL 1\r\nR 1\r\nD 2\r\nR 1\r\nU 2\r\nD 2\r\nL 2\r\nR 2\r\nU 1\r\nL 1\r\nD 2\r\nU 2\r\nL 1\r\nU 2\r\nL 2\r\nU 2\r\nL 2\r\nD 1\r\nU 2\r\nD 1\r\nR 1\r\nU 2\r\nR 2\r\nD 1\r\nR 1\r\nU 1\r\nR 2\r\nL 1\r\nR 1\r\nL 1\r\nD 1\r\nL 1\r\nD 2\r\nU 1\r\nL 2\r\nR 2\r\nU 1\r\nR 1\r\nL 1\r\nU 2\r\nD 1\r\nL 2\r\nD 2\r\nR 1\r\nL 2\r\nU 1\r\nR 1\r\nL 1\r\nR 2\r\nD 2\r\nR 2\r\nL 1\r\nR 1\r\nU 1\r\nL 2\r\nD 2\r\nL 2\r\nR 2\r\nU 2\r\nD 2\r\nL 1\r\nU 2\r\nD 2\r\nL 2\r\nD 1\r\nU 2\r\nD 2\r\nU 2\r\nR 2\r\nU 2\r\nD 2\r\nL 1\r\nR 2\r\nL 1\r\nU 1\r\nD 1\r\nR 1\r\nL 1\r\nU 1\r\nR 2\r\nL 1\r\nD 2\r\nR 1\r\nD 1\r\nR 2\r\nD 2\r\nL 2\r\nU 1\r\nR 1\r\nD 2\r\nL 1\r\nU 1\r\nD 1\r\nL 1\r\nD 2\r\nR 1\r\nD 1\r\nR 2\r\nD 2\r\nR 1\r\nL 1\r\nR 1\r\nD 1\r\nR 1\r\nU 1\r\nL 3\r\nD 3\r\nR 2\r\nU 3\r\nR 1\r\nD 3\r\nU 1\r\nR 3\r\nL 2\r\nU 3\r\nL 3\r\nD 2\r\nR 2\r\nL 3\r\nD 3\r\nU 1\r\nL 3\r\nD 1\r\nU 3\r\nL 3\r\nD 1\r\nR 2\r\nD 1\r\nR 1\r\nU 2\r\nR 2\r\nU 2\r\nR 1\r\nL 2\r\nR 2\r\nL 2\r\nD 1\r\nU 1\r\nR 3\r\nL 3\r\nD 1\r\nU 3\r\nL 1\r\nU 2\r\nR 1\r\nL 1\r\nR 2\r\nU 1\r\nR 3\r\nD 1\r\nL 3\r\nD 3\r\nL 3\r\nR 3\r\nD 1\r\nR 1\r\nL 2\r\nD 2\r\nR 3\r\nL 1\r\nD 1\r\nU 1\r\nD 1\r\nU 2\r\nR 3\r\nU 2\r\nD 3\r\nR 3\r\nD 2\r\nL 1\r\nR 1\r\nD 2\r\nR 1\r\nL 2\r\nD 2\r\nU 2\r\nL 1\r\nR 2\r\nU 1\r\nD 2\r\nR 2\r\nD 2\r\nL 2\r\nR 3\r\nD 1\r\nU 2\r\nL 2\r\nR 3\r\nD 3\r\nL 3\r\nU 3\r\nL 2\r\nD 1\r\nR 1\r\nL 3\r\nD 2\r\nR 2\r\nD 2\r\nL 1\r\nU 1\r\nR 2\r\nU 3\r\nD 1\r\nL 1\r\nR 1\r\nL 2\r\nU 2\r\nL 3\r\nU 2\r\nD 2\r\nU 1\r\nL 1\r\nR 1\r\nU 3\r\nD 3\r\nR 4\r\nL 4\r\nU 1\r\nD 2\r\nL 1\r\nD 4\r\nL 3\r\nD 1\r\nR 4\r\nU 2\r\nD 2\r\nL 1\r\nD 3\r\nL 3\r\nR 2\r\nL 2\r\nR 1\r\nL 3\r\nR 1\r\nL 2\r\nU 1\r\nL 2\r\nU 4\r\nD 4\r\nU 4\r\nL 4\r\nR 4\r\nD 3\r\nL 1\r\nR 3\r\nD 4\r\nR 1\r\nL 4\r\nR 4\r\nU 1\r\nR 3\r\nU 2\r\nD 4\r\nL 1\r\nU 3\r\nL 2\r\nR 2\r\nD 1\r\nL 1\r\nU 3\r\nL 2\r\nU 1\r\nD 1\r\nL 4\r\nD 4\r\nU 2\r\nD 4\r\nR 3\r\nU 1\r\nR 1\r\nD 3\r\nL 1\r\nD 2\r\nR 2\r\nD 3\r\nL 3\r\nU 4\r\nL 4\r\nR 1\r\nD 2\r\nL 3\r\nU 3\r\nD 1\r\nR 4\r\nL 4\r\nU 4\r\nR 3\r\nL 3\r\nD 3\r\nL 1\r\nD 1\r\nU 1\r\nL 3\r\nR 4\r\nL 3\r\nR 4\r\nL 1\r\nD 1\r\nR 4\r\nU 3\r\nD 4\r\nU 1\r\nD 3\r\nR 4\r\nU 2\r\nD 1\r\nL 3\r\nD 3\r\nL 1\r\nR 3\r\nU 2\r\nL 4\r\nD 4\r\nL 2\r\nD 4\r\nU 1\r\nL 3\r\nR 2\r\nD 2\r\nU 2\r\nD 2\r\nR 1\r\nU 3\r\nR 3\r\nU 4\r\nL 3\r\nR 2\r\nD 4\r\nU 3\r\nD 4\r\nR 5\r\nL 1\r\nD 3\r\nL 5\r\nR 3\r\nD 5\r\nU 3\r\nR 1\r\nU 3\r\nD 4\r\nR 1\r\nD 5\r\nR 3\r\nL 4\r\nD 2\r\nR 2\r\nU 2\r\nL 4\r\nU 3\r\nD 1\r\nL 2\r\nD 3\r\nU 2\r\nD 2\r\nR 4\r\nL 5\r\nU 1\r\nD 5\r\nR 2\r\nD 5\r\nR 3\r\nL 3\r\nR 4\r\nD 1\r\nL 5\r\nD 2\r\nU 2\r\nD 4\r\nU 4\r\nR 4\r\nL 2\r\nD 3\r\nL 3\r\nR 3\r\nL 4\r\nD 2\r\nU 1\r\nR 3\r\nL 3\r\nR 2\r\nL 5\r\nR 4\r\nD 2\r\nL 3\r\nR 2\r\nU 2\r\nR 4\r\nL 4\r\nR 1\r\nU 5\r\nD 5\r\nU 1\r\nR 4\r\nL 5\r\nR 5\r\nL 3\r\nR 1\r\nU 2\r\nL 4\r\nU 4\r\nL 5\r\nD 1\r\nU 5\r\nD 5\r\nU 2\r\nR 4\r\nU 3\r\nD 5\r\nR 1\r\nD 1\r\nL 5\r\nR 4\r\nL 4\r\nR 3\r\nD 3\r\nU 2\r\nR 5\r\nL 5\r\nU 5\r\nL 3\r\nD 2\r\nR 3\r\nL 4\r\nR 1\r\nL 3\r\nU 5\r\nL 2\r\nD 5\r\nR 5\r\nL 3\r\nD 3\r\nU 3\r\nL 5\r\nU 3\r\nR 1\r\nU 3\r\nL 5\r\nD 1\r\nU 4\r\nR 6\r\nU 1\r\nD 3\r\nU 1\r\nL 5\r\nR 1\r\nU 3\r\nD 3\r\nR 3\r\nU 5\r\nL 1\r\nR 2\r\nL 3\r\nU 5\r\nL 2\r\nR 6\r\nD 3\r\nU 3\r\nR 2\r\nU 5\r\nL 2\r\nU 5\r\nD 5\r\nR 1\r\nD 1\r\nU 6\r\nL 2\r\nD 2\r\nL 4\r\nR 5\r\nU 1\r\nD 3\r\nR 4\r\nD 1\r\nU 6\r\nR 4\r\nD 4\r\nU 6\r\nR 5\r\nL 5\r\nD 6\r\nR 6\r\nU 2\r\nL 2\r\nD 3\r\nR 6\r\nU 5\r\nL 5\r\nR 6\r\nL 3\r\nD 5\r\nU 2\r\nL 3\r\nU 4\r\nD 2\r\nU 5\r\nR 6\r\nD 3\r\nU 4\r\nL 2\r\nU 5\r\nL 6\r\nR 6\r\nD 5\r\nR 4\r\nD 3\r\nL 1\r\nD 4\r\nR 6\r\nL 4\r\nR 3\r\nU 5\r\nR 6\r\nU 1\r\nD 3\r\nL 4\r\nD 2\r\nU 6\r\nL 4\r\nD 6\r\nL 4\r\nD 5\r\nL 6\r\nD 1\r\nU 5\r\nR 5\r\nL 5\r\nR 4\r\nD 2\r\nR 2\r\nU 3\r\nD 2\r\nR 2\r\nD 2\r\nR 6\r\nU 6\r\nL 4\r\nU 6\r\nR 5\r\nD 5\r\nU 2\r\nR 4\r\nL 4\r\nD 2\r\nR 1\r\nD 4\r\nU 5\r\nR 4\r\nD 1\r\nU 2\r\nL 1\r\nR 1\r\nU 4\r\nR 3\r\nL 6\r\nD 5\r\nL 6\r\nR 1\r\nD 3\r\nU 4\r\nD 3\r\nL 2\r\nD 7\r\nU 2\r\nD 7\r\nU 4\r\nL 3\r\nR 6\r\nD 1\r\nL 6\r\nR 3\r\nL 6\r\nU 7\r\nR 2\r\nD 3\r\nL 3\r\nU 1\r\nL 4\r\nU 1\r\nL 1\r\nD 3\r\nR 1\r\nD 5\r\nL 3\r\nR 1\r\nD 4\r\nU 1\r\nR 4\r\nD 7\r\nU 7\r\nD 1\r\nR 7\r\nD 3\r\nR 2\r\nD 1\r\nU 6\r\nR 4\r\nU 7\r\nD 1\r\nU 2\r\nL 5\r\nR 2\r\nU 5\r\nL 1\r\nU 5\r\nD 6\r\nR 5\r\nD 4\r\nR 6\r\nU 3\r\nL 2\r\nD 6\r\nR 1\r\nD 1\r\nU 3\r\nL 2\r\nU 2\r\nL 5\r\nD 5\r\nL 7\r\nD 6\r\nR 3\r\nD 6\r\nU 6\r\nL 7\r\nU 4\r\nL 7\r\nD 7\r\nL 7\r\nU 5\r\nR 3\r\nL 5\r\nD 4\r\nR 3\r\nD 4\r\nU 7\r\nL 7\r\nD 6\r\nU 1\r\nR 5\r\nL 4\r\nR 5\r\nD 7\r\nR 4\r\nL 5\r\nU 5\r\nR 3\r\nU 6\r\nD 4\r\nU 7\r\nR 7\r\nD 1\r\nR 6\r\nU 6\r\nD 3\r\nL 1\r\nR 1\r\nU 5\r\nR 2\r\nL 6\r\nU 2\r\nR 8\r\nU 3\r\nR 3\r\nL 8\r\nR 4\r\nU 4\r\nL 4\r\nR 2\r\nL 2\r\nU 1\r\nD 2\r\nU 6\r\nL 1\r\nR 6\r\nU 2\r\nR 1\r\nD 2\r\nR 8\r\nD 6\r\nR 3\r\nL 1\r\nD 6\r\nR 3\r\nU 3\r\nL 3\r\nR 1\r\nD 4\r\nR 3\r\nD 8\r\nU 4\r\nL 1\r\nD 7\r\nL 2\r\nR 6\r\nU 2\r\nL 6\r\nU 7\r\nD 4\r\nR 2\r\nL 5\r\nR 3\r\nL 1\r\nU 2\r\nL 8\r\nR 8\r\nU 2\r\nR 8\r\nL 1\r\nU 8\r\nL 1\r\nD 4\r\nR 5\r\nU 1\r\nR 5\r\nL 8\r\nD 8\r\nR 4\r\nL 7\r\nU 3\r\nD 8\r\nL 7\r\nR 7\r\nL 8\r\nD 2\r\nU 2\r\nD 8\r\nL 1\r\nR 3\r\nL 7\r\nD 4\r\nR 5\r\nL 4\r\nR 7\r\nU 5\r\nL 7\r\nU 4\r\nR 4\r\nU 5\r\nR 3\r\nD 7\r\nU 7\r\nR 8\r\nL 7\r\nU 4\r\nD 2\r\nR 1\r\nD 8\r\nU 4\r\nD 7\r\nR 1\r\nD 4\r\nL 6\r\nU 1\r\nL 8\r\nD 1\r\nR 7\r\nL 2\r\nU 7\r\nR 7\r\nL 4\r\nU 6\r\nL 5\r\nD 3\r\nR 3\r\nL 1\r\nR 2\r\nU 3\r\nD 3\r\nR 5\r\nU 6\r\nD 8\r\nL 7\r\nR 2\r\nL 6\r\nR 4\r\nL 4\r\nR 5\r\nL 8\r\nR 8\r\nU 7\r\nL 6\r\nR 9\r\nD 2\r\nL 2\r\nD 9\r\nU 3\r\nD 3\r\nL 1\r\nU 9\r\nD 7\r\nU 3\r\nD 8\r\nR 3\r\nU 3\r\nL 7\r\nD 9\r\nL 8\r\nU 8\r\nL 6\r\nR 7\r\nD 1\r\nU 1\r\nR 5\r\nL 3\r\nR 7\r\nU 8\r\nR 8\r\nD 5\r\nL 4\r\nR 5\r\nD 6\r\nL 7\r\nU 7\r\nR 9\r\nU 4\r\nR 5\r\nL 9\r\nR 7\r\nD 7\r\nU 3\r\nD 7\r\nL 3\r\nU 5\r\nD 2\r\nU 8\r\nD 1\r\nU 7\r\nR 7\r\nD 2\r\nU 8\r\nD 4\r\nR 7\r\nL 3\r\nU 3\r\nD 2\r\nR 9\r\nU 4\r\nD 4\r\nU 1\r\nL 4\r\nU 2\r\nD 7\r\nU 1\r\nL 4\r\nR 5\r\nL 3\r\nU 8\r\nR 4\r\nL 6\r\nU 6\r\nR 5\r\nU 3\r\nL 6\r\nD 7\r\nU 5\r\nR 2\r\nD 3\r\nL 6\r\nU 5\r\nL 7\r\nU 4\r\nR 6\r\nD 2\r\nL 1\r\nR 7\r\nL 1\r\nD 9\r\nL 6\r\nD 1\r\nR 1\r\nU 7\r\nR 4\r\nL 9\r\nD 9\r\nU 4\r\nD 8\r\nU 1\r\nL 8\r\nD 2\r\nU 9\r\nL 7\r\nR 10\r\nU 10\r\nL 10\r\nD 5\r\nR 9\r\nD 8\r\nL 1\r\nR 3\r\nL 7\r\nU 2\r\nL 1\r\nD 4\r\nR 5\r\nU 5\r\nD 1\r\nR 3\r\nD 3\r\nR 7\r\nU 2\r\nD 6\r\nU 6\r\nL 1\r\nD 7\r\nR 5\r\nL 9\r\nR 1\r\nU 7\r\nD 10\r\nU 3\r\nD 5\r\nU 8\r\nL 5\r\nR 8\r\nL 2\r\nR 9\r\nL 10\r\nR 9\r\nD 6\r\nU 1\r\nD 2\r\nL 7\r\nR 5\r\nL 6\r\nR 2\r\nD 9\r\nU 4\r\nL 8\r\nD 6\r\nL 10\r\nD 3\r\nU 8\r\nD 9\r\nU 5\r\nL 1\r\nU 9\r\nR 2\r\nD 5\r\nL 7\r\nU 4\r\nD 10\r\nU 6\r\nD 7\r\nU 6\r\nL 3\r\nD 2\r\nR 6\r\nL 10\r\nR 7\r\nU 4\r\nL 6\r\nD 1\r\nR 3\r\nD 8\r\nU 5\r\nL 7\r\nU 4\r\nL 6\r\nU 5\r\nL 3\r\nD 4\r\nU 4\r\nL 4\r\nD 6\r\nU 7\r\nL 10\r\nD 5\r\nL 7\r\nD 3\r\nU 3\r\nL 1\r\nD 3\r\nU 8\r\nD 2\r\nR 5\r\nU 7\r\nD 3\r\nL 5\r\nD 2\r\nL 2\r\nR 7\r\nL 10\r\nD 2\r\nU 2\r\nR 2\r\nD 9\r\nR 4\r\nL 4\r\nR 9\r\nD 8\r\nL 1\r\nU 8\r\nL 8\r\nR 4\r\nL 9\r\nU 11\r\nL 3\r\nR 4\r\nU 6\r\nL 11\r\nU 8\r\nR 4\r\nD 9\r\nR 5\r\nD 9\r\nU 11\r\nD 4\r\nR 1\r\nU 6\r\nL 8\r\nR 10\r\nD 11\r\nU 6\r\nD 4\r\nU 2\r\nD 7\r\nL 3\r\nR 5\r\nL 7\r\nR 5\r\nL 7\r\nD 2\r\nL 7\r\nU 9\r\nD 3\r\nL 6\r\nR 2\r\nU 6\r\nL 8\r\nR 10\r\nU 3\r\nR 7\r\nL 8\r\nU 1\r\nD 4\r\nL 1\r\nU 1\r\nD 6\r\nL 5\r\nU 4\r\nR 3\r\nU 7\r\nR 5\r\nU 11\r\nL 11\r\nR 11\r\nL 2\r\nR 3\r\nU 2\r\nR 10\r\nL 4\r\nU 8\r\nL 6\r\nR 8\r\nL 11\r\nU 6\r\nD 2\r\nL 7\r\nD 10\r\nR 3\r\nL 6\r\nR 8\r\nD 4\r\nU 7\r\nD 4\r\nR 1\r\nD 6\r\nR 11\r\nD 11\r\nR 9\r\nU 10\r\nR 7\r\nD 8\r\nU 4\r\nL 3\r\nR 9\r\nU 2\r\nD 3\r\nL 7\r\nR 10\r\nL 9\r\nD 11\r\nU 5\r\nL 10\r\nD 2\r\nR 10\r\nD 7\r\nU 4\r\nR 8\r\nD 9\r\nL 3\r\nR 4\r\nL 11\r\nD 4\r\nU 5\r\nR 7\r\nU 3\r\nR 9\r\nD 11\r\nR 1\r\nD 10\r\nR 2\r\nU 8\r\nL 7\r\nR 9\r\nU 9\r\nD 11\r\nR 6\r\nL 2\r\nD 4\r\nR 4\r\nD 6\r\nL 12\r\nD 11\r\nR 5\r\nU 1\r\nR 9\r\nL 9\r\nD 7\r\nL 1\r\nR 6\r\nL 4\r\nU 4\r\nR 10\r\nD 12\r\nR 1\r\nU 8\r\nD 8\r\nL 1\r\nU 12\r\nD 2\r\nR 7\r\nU 12\r\nL 10\r\nD 12\r\nR 6\r\nU 10\r\nD 8\r\nL 8\r\nU 1\r\nR 4\r\nL 7\r\nD 1\r\nL 7\r\nR 7\r\nU 4\r\nL 12\r\nU 6\r\nD 1\r\nU 8\r\nR 12\r\nL 11\r\nD 12\r\nR 3\r\nD 11\r\nU 2\r\nR 9\r\nD 11\r\nL 9\r\nR 1\r\nU 7\r\nD 9\r\nU 8\r\nL 8\r\nD 11\r\nR 9\r\nU 5\r\nD 6\r\nU 8\r\nD 6\r\nU 8\r\nD 11\r\nL 3\r\nD 4\r\nR 1\r\nU 6\r\nL 10\r\nU 11\r\nD 11\r\nU 5\r\nD 1\r\nR 3\r\nD 2\r\nL 4\r\nR 4\r\nD 10\r\nL 3\r\nD 12\r\nU 5\r\nR 1\r\nU 9\r\nD 1\r\nU 2\r\nR 7\r\nL 7\r\nU 8\r\nL 9\r\nD 4\r\nU 6\r\nR 9\r\nU 4\r\nL 11\r\nU 5\r\nL 6\r\nD 4\r\nU 8\r\nL 11\r\nU 2\r\nL 4\r\nU 1\r\nD 9\r\nR 2\r\nL 5\r\nD 8\r\nR 11\r\nU 7\r\nL 9\r\nD 2\r\nU 12\r\nR 13\r\nD 1\r\nL 10\r\nD 5\r\nR 9\r\nU 2\r\nL 10\r\nU 12\r\nR 4\r\nU 11\r\nD 4\r\nL 3\r\nU 12\r\nD 9\r\nR 9\r\nL 2\r\nD 5\r\nL 2\r\nU 6\r\nD 6\r\nL 1\r\nU 8\r\nR 9\r\nD 1\r\nL 11\r\nR 4\r\nD 4\r\nU 7\r\nR 9\r\nU 1\r\nL 5\r\nD 6\r\nU 2\r\nD 8\r\nU 6\r\nL 2\r\nD 11\r\nL 2\r\nD 11\r\nU 12\r\nD 6\r\nU 12\r\nR 13\r\nD 13\r\nL 6\r\nU 7\r\nL 1\r\nD 12\r\nU 9\r\nL 2\r\nU 13\r\nR 3\r\nU 8\r\nL 9\r\nD 13\r\nR 4\r\nU 4\r\nD 2\r\nL 7\r\nR 1\r\nD 1\r\nL 4\r\nR 12\r\nU 2\r\nD 12\r\nL 11\r\nU 10\r\nL 5\r\nU 9\r\nD 11\r\nR 7\r\nL 4\r\nD 10\r\nL 10\r\nU 5\r\nR 8\r\nL 5\r\nR 12\r\nL 9\r\nD 3\r\nU 11\r\nL 4\r\nR 8\r\nU 8\r\nR 9\r\nD 11\r\nU 10\r\nL 11\r\nU 4\r\nD 6\r\nR 3\r\nU 3\r\nR 13\r\nL 5\r\nD 9\r\nU 5\r\nR 1\r\nL 4\r\nD 9\r\nU 10\r\nR 8\r\nD 3\r\nL 7\r\nR 5\r\nU 2\r\nR 11\r\nU 12\r\nD 12\r\nR 3\r\nL 5\r\nD 13\r\nU 6\r\nR 5\r\nU 11\r\nD 12\r\nL 8\r\nU 14\r\nL 2\r\nR 4\r\nU 7\r\nR 9\r\nL 10\r\nU 4\r\nL 4\r\nR 12\r\nD 13\r\nR 6\r\nL 12\r\nD 6\r\nR 6\r\nD 9\r\nL 1\r\nU 8\r\nL 11\r\nD 2\r\nL 14\r\nR 10\r\nD 1\r\nU 8\r\nD 13\r\nL 3\r\nR 10\r\nU 4\r\nD 12\r\nR 12\r\nU 4\r\nD 2\r\nL 4\r\nU 6\r\nD 1\r\nU 7\r\nR 11\r\nU 7\r\nD 10\r\nR 6\r\nU 4\r\nD 2\r\nU 1\r\nL 2\r\nR 9\r\nD 3\r\nR 8\r\nD 12\r\nL 11\r\nU 2\r\nL 3\r\nU 5\r\nD 6\r\nL 14\r\nR 9\r\nL 14\r\nR 12\r\nU 12\r\nR 8\r\nL 13\r\nU 6\r\nL 10\r\nD 5\r\nU 14\r\nD 11\r\nL 11\r\nR 8\r\nL 6\r\nD 13\r\nR 5\r\nD 6\r\nL 7\r\nR 6\r\nD 8\r\nL 7\r\nD 9\r\nL 9\r\nU 8\r\nD 11\r\nL 7\r\nU 2\r\nD 9\r\nL 14\r\nR 3\r\nL 1\r\nD 9\r\nL 9\r\nR 1\r\nL 9\r\nU 6\r\nL 13\r\nD 7\r\nL 8\r\nD 2\r\nL 11\r\nU 8\r\nL 9\r\nU 7\r\nD 14\r\nL 11\r\nR 10\r\nD 1\r\nR 3\r\nD 9\r\nU 13\r\nD 3\r\nU 4\r\nR 2\r\nL 6\r\nU 11\r\nR 3\r\nL 9\r\nD 15\r\nR 12\r\nD 4\r\nL 14\r\nU 11\r\nL 2\r\nR 1\r\nL 10\r\nU 5\r\nR 11\r\nU 13\r\nR 13\r\nU 14\r\nD 2\r\nU 5\r\nD 14\r\nR 9\r\nD 8\r\nR 13\r\nL 1\r\nU 2\r\nR 7\r\nU 5\r\nL 8\r\nU 9\r\nR 3\r\nU 8\r\nR 9\r\nL 7\r\nR 15\r\nL 3\r\nD 12\r\nU 14\r\nR 12\r\nL 1\r\nR 9\r\nU 5\r\nR 4\r\nU 1\r\nD 4\r\nR 12\r\nL 2\r\nD 7\r\nU 2\r\nD 14\r\nU 2\r\nR 5\r\nD 12\r\nU 2\r\nD 5\r\nR 11\r\nL 5\r\nR 8\r\nD 10\r\nR 11\r\nL 12\r\nD 11\r\nL 6\r\nR 14\r\nD 2\r\nL 8\r\nR 6\r\nL 12\r\nR 13\r\nL 7\r\nR 4\r\nU 4\r\nD 15\r\nR 14\r\nD 5\r\nL 12\r\nU 7\r\nL 5\r\nD 5\r\nL 11\r\nU 10\r\nD 10\r\nL 13\r\nD 8\r\nR 10\r\nU 1\r\nL 6\r\nU 3\r\nL 12\r\nD 15\r\nU 12\r\nL 13\r\nU 7\r\nR 1\r\nL 13\r\nD 13\r\nU 2\r\nD 15\r\nU 2\r\nD 4\r\nL 7\r\nU 11\r\nR 9\r\nD 11\r\nL 9\r\nD 10\r\nU 9\r\nD 14\r\nR 8\r\nD 13\r\nU 16\r\nD 14\r\nR 13\r\nD 3\r\nL 9\r\nR 5\r\nD 2\r\nR 4\r\nD 14\r\nU 7\r\nD 5\r\nR 8\r\nL 14\r\nR 7\r\nU 4\r\nL 4\r\nR 15\r\nL 1\r\nU 12\r\nR 8\r\nL 4\r\nR 14\r\nL 13\r\nD 11\r\nU 3\r\nR 11\r\nD 11\r\nR 2\r\nD 10\r\nR 4\r\nD 8\r\nL 10\r\nR 3\r\nL 4\r\nR 16\r\nU 8\r\nD 9\r\nR 8\r\nD 15\r\nU 16\r\nR 15\r\nD 7\r\nR 10\r\nL 7\r\nR 2\r\nU 3\r\nR 16\r\nD 13\r\nL 10\r\nU 13\r\nD 8\r\nU 15\r\nD 3\r\nU 3\r\nL 16\r\nU 3\r\nR 11\r\nD 6\r\nR 12\r\nU 11\r\nR 2\r\nD 1\r\nU 3\r\nL 7\r\nU 9\r\nD 12\r\nR 13\r\nL 13\r\nU 5\r\nD 16\r\nL 14\r\nD 13\r\nU 15\r\nD 3\r\nU 15\r\nR 11\r\nD 16\r\nR 7\r\nD 2\r\nL 14\r\nR 8\r\nL 10\r\nR 3\r\nL 2\r\nU 2\r\nL 9\r\nD 5\r\nL 2\r\nD 12\r\nR 3\r\nU 7\r\nR 4\r\nU 2\r\nL 9\r\nR 13\r\nL 7\r\nU 16\r\nR 4\r\nD 1\r\nU 7\r\nR 3\r\nU 9\r\nL 6\r\nU 6\r\nD 7\r\nU 8\r\nD 16\r\nL 14\r\nU 16\r\nD 8\r\nU 6\r\nL 8\r\nD 2\r\nR 6\r\nU 14\r\nL 16\r\nR 7\r\nL 15\r\nU 15\r\nD 12\r\nR 2\r\nU 15\r\nR 8\r\nD 9\r\nR 6\r\nU 9\r\nD 1\r\nR 14\r\nU 7\r\nD 12\r\nR 7\r\nU 14\r\nR 16\r\nD 5\r\nR 11\r\nL 8\r\nU 4\r\nL 7\r\nD 8\r\nR 10\r\nD 9\r\nU 4\r\nL 5\r\nU 6\r\nD 17\r\nL 1\r\nU 16\r\nL 16\r\nR 14\r\nD 14\r\nU 3\r\nL 10\r\nD 3\r\nR 10\r\nU 2\r\nD 17\r\nR 12\r\nL 14\r\nD 10\r\nL 16\r\nU 14\r\nR 3\r\nL 17\r\nD 5\r\nU 14\r\nR 15\r\nD 5\r\nL 2\r\nR 6\r\nU 2\r\nL 5\r\nR 2\r\nL 10\r\nR 14\r\nL 16\r\nU 7\r\nL 5\r\nR 12\r\nL 13\r\nU 5\r\nL 13\r\nR 10\r\nL 12\r\nU 5\r\nR 15\r\nD 1\r\nU 12\r\nR 8\r\nD 12\r\nR 14\r\nU 7\r\nR 3\r\nL 15\r\nU 9\r\nD 10\r\nU 3\r\nR 17\r\nL 11\r\nD 4\r\nL 17\r\nR 5\r\nL 10\r\nR 3\r\nU 4\r\nL 3\r\nD 5\r\nR 1\r\nD 11\r\nL 9\r\nR 1\r\nL 9\r\nD 11\r\nL 1\r\nD 2\r\nU 6\r\nL 15\r\nU 1\r\nL 9\r\nD 11\r\nU 18\r\nD 16\r\nL 1\r\nR 1\r\nL 12\r\nU 3\r\nL 7\r\nR 14\r\nD 11\r\nR 9\r\nD 10\r\nL 7\r\nD 2\r\nL 10\r\nD 18\r\nR 13\r\nD 10\r\nR 16\r\nD 6\r\nU 8\r\nD 12\r\nR 6\r\nL 7\r\nD 16\r\nL 16\r\nU 11\r\nR 13\r\nD 12\r\nR 3\r\nD 2\r\nU 8\r\nL 9\r\nR 12\r\nL 11\r\nD 2\r\nL 17\r\nD 10\r\nU 12\r\nR 7\r\nD 15\r\nU 5\r\nL 10\r\nR 1\r\nU 13\r\nL 12\r\nR 7\r\nD 17\r\nU 5\r\nD 13\r\nU 13\r\nR 4\r\nU 14\r\nL 16\r\nR 18\r\nU 17\r\nL 16\r\nU 13\r\nR 5\r\nL 6\r\nU 6\r\nD 10\r\nR 6\r\nU 10\r\nL 8\r\nD 8\r\nL 3\r\nR 4\r\nU 17\r\nR 11\r\nD 14\r\nU 5\r\nL 17\r\nR 3\r\nU 6\r\nD 3\r\nR 11\r\nU 15\r\nD 4\r\nR 2\r\nD 9\r\nU 13\r\nL 12\r\nR 14\r\nL 17\r\nD 4\r\nU 14\r\nL 4\r\nU 11\r\nR 11\r\nL 6\r\nR 15\r\nL 18\r\nD 8\r\nU 2\r\nR 17\r\nD 10\r\nU 15\r\nD 18\r\nL 1\r\nD 6\r\nR 5\r\nD 14\r\nL 10\r\nD 16\r\nL 7\r\nD 15\r\nL 15\r\nD 15\r\nL 6\r\nU 4\r\nD 15\r\nU 17\r\nL 13\r\nR 10\r\nU 15\r\nD 16\r\nU 9\r\nR 9\r\nD 16\r\nR 12\r\nU 16\r\nD 11\r\nL 9\r\nR 5\r\nL 14\r\nR 1\r\nL 3\r\nD 4\r\nR 4\r\nD 5\r\nU 13\r\nD 14\r\nL 9\r\nU 4\r\nR 19\r\nD 3\r\nR 13\r\nU 17\r\nR 2\r\nD 13\r\nR 14\r\nL 18\r\nD 12\r\nL 5\r\nD 11\r\nU 19\r\nD 14\r\nU 2\r\nR 1\r\nU 18\r\nD 1\r\nL 9\r\nR 17\r\nU 10\r\nL 9\r\nD 15\r\nL 15\r\nU 15\r\nR 19\r\nD 17\r\nR 19\r\nD 9\r\nL 11\r\nU 16\r\nD 10\r\nU 6\r\nD 17\r\nR 3\r\nD 19\r\nR 13\r\nL 16\r\nR 2\r\nD 9\r\nR 3\r\nL 7\r\nR 18\r\nL 6\r\nU 5\r\nD 15\r\nL 5\r\nD 19\r\nR 6\r\nD 14\r\nU 16\r\nD 9\r\nL 18\r\nU 19\r\nL 10\r\nD 13\r\nR 18\r\nU 8\r\nL 5\r\nR 13\r\nU 15\r\nR 6\r\nD 12\r\nR 10\r\nD 5\r\nU 17\r\nR 9\r\nU 2\r\nD 14\r\nR 18\r\nD 3\r\nL 7\r\nD 5\r\nR 15\r\nU 2\r\nL 6\r\nR 5\r\nD 17\r\nL 19\r\nR 14\r\nU 13\r\nD 16\r\nU 1\r\nD 18\r\nL 14\r\nU 4\r\nR 8\r\nL 16\r\nD 15\r\nU 8";
    }
}