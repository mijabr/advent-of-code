namespace AdventOfCode.Year2023
{
    public class WastelandNavigator
    {
        public WastelandNavigator(string input)
        {
            var lines = input.Split("\r\n");

            Directions = lines[0];
            Nodes = new Dictionary<string, WastelandNavigatorNode>();
            foreach (var line in lines.Skip(2))
            {
                var p1 = line.Split('=');
                var p2 = p1[1].Replace("(", "").Replace(")", "").Split(',');
                Nodes[p1[0].Trim()] = new WastelandNavigatorNode(p2[0].Trim(), p2[1].Trim());
            }
        }

        public string Directions { get; private set; }
        public Dictionary<string, WastelandNavigatorNode> Nodes { get; private set; }

        public int CountSteps(string startNode, string endNode)
        {
            var directionIndex = 0;
            var steps = 0;
            var currentNode = startNode;
            while (currentNode != endNode)
            {
                if (directionIndex >= Directions.Length) directionIndex = 0;
                currentNode = Directions[directionIndex] == 'L' ? Nodes[currentNode].Left : Nodes[currentNode].Right;
                steps++;
                directionIndex++;
            }

            return steps;
        }

        public long CountStepsEndingWith(string startingNodesSuffix, string endingNodesSuffix)
        {
            var directionIndex = 0;
            var steps = 0;
            var ghosts = FindNodesEndingWith(startingNodesSuffix).Select(n => new Ghost(n)).ToList();

            while (!AllGhostsHaveRepeatingSteps(ghosts, endingNodesSuffix, steps))
            {
                if (directionIndex >= Directions.Length) directionIndex = 0;

                foreach (var ghost in ghosts)
                {
                    ghost.CurrentNode = Directions[directionIndex] == 'L' ? Nodes[ghost.CurrentNode].Left : Nodes[ghost.CurrentNode].Right;
                }

                steps++;
                directionIndex++;
            }

            long stepsProduct = ghosts[0].StepsForRepeat;
            for (var i = 1; i < ghosts.Count; i++)
            {
                stepsProduct = LowestCommonMultiple(stepsProduct, ghosts[i].StepsForRepeat);
            }

            return stepsProduct;
        }

        private long LowestCommonMultiple(long a, long b) => a * b / GreatestCommonDivisor(a, b);

        private long GreatestCommonDivisor(long a, long b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);

        private class Ghost
        {
            public Ghost(string node)
            {
                CurrentNode = node;
            }

            public string CurrentNode { get; set; }
            public int StepsForRepeat { get; set; }
        }

        private static bool AllGhostsHaveRepeatingSteps(List<Ghost> currentNodes, string endingNodesSuffix, int steps)
        {
            foreach (var node in currentNodes)
            {
                if (node.CurrentNode.EndsWith(endingNodesSuffix))
                {
                    node.StepsForRepeat = steps;
                }
            }

            return currentNodes.All(n => n.StepsForRepeat > 0);
        }

        private List<string> FindNodesEndingWith(string suffix) =>
            Nodes.Keys.Where(n => n.EndsWith(suffix)).ToList();
    }

    public record WastelandNavigatorNode(string Left, string Right);
}
