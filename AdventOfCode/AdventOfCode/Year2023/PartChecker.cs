using AdventOfCode.Util;

namespace AdventOfCode.Year2023
{
    public class PartChecker
    {
        public PartChecker(string input)
        {
            var sections = input.Split("\r\n\r\n");
            Workflows = sections[0].Split("\r\n")
                .Select(r => new PartCheckerWorkflow(r))
                .ToDictionary(f => f.Name, f => f);
            Parts = sections[1].Split("\r\n")
                .Select(r => new PartCheckerPart(r))
                .ToList();
        }

        public Dictionary<string, PartCheckerWorkflow> Workflows { get; set; }
        public List<PartCheckerPart> Parts { get; set; }

        public long SumPartRatings()
        {
            var acceptedParts = new List<PartCheckerPart>();

            foreach (var part in Parts)
            {
                var workflow = Workflows["in"];
                while (workflow != null)
                {
                    var destination = workflow.FindDestinationForPart(part);
                    if (destination == "A")
                    {
                        acceptedParts.Add(part);
                        break;
                    }
                    else if (destination == "R")
                    {
                        break;
                    }

                    workflow = Workflows[destination];
                }
            }

            return acceptedParts.Sum(p => p.Total);
        }
    }

    public class PartCheckerWorkflow
    {
        public PartCheckerWorkflow(string input)
        {
            var parts = input.Split('{');
            Name = parts[0];
            Instructions = parts[1].Replace("}", "").Split(',').Select(p => new PartCheckerWorkflowInstruction(p)).ToList();
        }

        public string Name { get; private set; }
        public List<PartCheckerWorkflowInstruction> Instructions { get; set; }

        public string FindDestinationForPart(PartCheckerPart part)
        {
            foreach (var instruction in Instructions)
            {
                if (!instruction.VariableName.HasValue)
                {
                    return instruction.Destination;
                }

                var partValue = instruction.VariableName switch
                {
                    'x' => part.X,
                    'm' => part.M,
                    'a' => part.A,
                    's' => part.S,
                    _ => throw new Exception("Unknown variable")
                };

                var success = instruction.Operation switch
                {
                    '<' => partValue < instruction.Value,
                    '>' => partValue > instruction.Value,
                    _ => throw new Exception("Unknown operation")
                };

                if (success)
                {
                    return instruction.Destination;
                }
            }

            throw new Exception("ran out of instructions");
        }
    }

    public class PartCheckerWorkflowInstruction
    {
        public PartCheckerWorkflowInstruction(string input)
        {
            var colon = input.IndexOf(':');
            if (colon != -1)
            {
                VariableName = input[0];
                Operation = input[1];
                Value = input.Substring(2).Parse<long>();
                Destination = input.Substring(colon + 1);
            }
            else
            {
                Destination = input;
            }
        }

        public char? VariableName { get; private set; }
        public char? Operation { get; private set; }
        public long? Value { get; private set; }
        public string Destination { get; private set; }
    }

    public class PartCheckerPart
    {
        public PartCheckerPart(string input)
        {
            var parts = input.Split("=");
            X = parts[1].Parse<long>();
            M = parts[2].Parse<long>();
            A = parts[3].Parse<long>();
            S = parts[4].Parse<long>();
        }

        public long X { get; private set; }
        public long M { get; private set; }
        public long A { get; private set; }
        public long S { get; private set; }
        public long Total => X + M + A + S;
    }
}
