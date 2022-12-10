namespace AdventOfCodeTests.Year2022
{
    public class ElfCleanUpAssignment
    {
        public int FindAnyOverLapAssignments(string input)
        {
            return input.Split("\r\n").Count(IsPartyContained);
        }

        public int FindWholeyContainedAssignments(string input)
        {
            return input.Split("\r\n").Count(IsWholeyContained);
        }

        private bool IsWholeyContained(string inputLine)
        {
            var (assignment1, assignment2) = GetAssignments(inputLine);
            var common = assignment1.Intersect(assignment2).Count();
            return assignment1.Length == common || assignment2.Length == common;
        }

        private bool IsPartyContained(string inputLine)
        {
            var (assignment1, assignment2) = GetAssignments(inputLine);
            return assignment1.Intersect(assignment2).Any();
        }

        private (int[] assignment1, int[] assignment2) GetAssignments(string inputLine)
        {
            var assignments = inputLine.Split(",");
            return (GetAssignment(assignments[0]), GetAssignment(assignments[1]));
        }

        private static int[] GetAssignment(string assignmentInput) =>
            Enumerable
                .Range(
                    int.Parse(assignmentInput[..assignmentInput.IndexOf('-')]),
                    int.Parse(assignmentInput[(assignmentInput.IndexOf('-') + 1)..]) - int.Parse(assignmentInput[..assignmentInput.IndexOf('-')]) + 1)
                .ToArray();
    }
}
