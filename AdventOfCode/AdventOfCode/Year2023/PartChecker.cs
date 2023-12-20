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

        public long CountAllAcceptedPartTypes()
        {
            var workingInstructionTree = new List<InstructionBranch>
            {
                new InstructionBranch(new InstructionBranchInstruction(new PartCheckerWorkflowInstruction("in"), "pre-in-->"))
            };

            var acceptedInstructionTree = new List<InstructionBranch>();
            while (workingInstructionTree.Count > 0)
            {
                var destination = workingInstructionTree[0].Instructions[^1].Instruction.Destination;
                if (destination == "A")
                {
                    acceptedInstructionTree.Add(workingInstructionTree[0]);
                    workingInstructionTree.RemoveAt(0);
                }
                else if (destination == "R" || workingInstructionTree[0].Instructions.Any(i => i.Workflow == destination))
                {
                    workingInstructionTree.RemoveAt(0);
                }
                else
                {
                    var workflow = Workflows[destination];
                    var inverseInstructions = new List<InstructionBranchInstruction>();
                    var clone = new InstructionBranch(workingInstructionTree[0].Instructions);
                    for (int n = 0;n < workflow.Instructions.Count; n++)
                    {
                        var instruction = new InstructionBranchInstruction(workflow.Instructions[n], destination);
                        var inverseInstruction = new InstructionBranchInstruction(workflow.Instructions[n].Inverse(), destination);
                        if (n == 0)
                        {
                            workingInstructionTree[0].Instructions.Add(instruction);
                        }
                        else
                        {
                            var nextClone = new InstructionBranch(clone.Instructions);
                            clone.Instructions.AddRange(inverseInstructions);
                            clone.Instructions.Add(instruction);
                            workingInstructionTree.Add(clone);
                            clone = nextClone;
                        }

                        inverseInstructions.Add(inverseInstruction);
                    }
                }
            }

            var partCounts = acceptedInstructionTree.Select(t =>
            {
                long[] min = { 1, 1, 1, 1 };
                long[] max = { 4000, 4000, 4000, 4000 };
                foreach (var instruction in t.Instructions)
                {
                    int instructionVariable = instruction.Instruction.VariableName switch
                    {
                        'x' => 0,
                        'm' => 1,
                        'a' => 2,
                        's' => 3,
                        _ => 4
                    };

                    switch (instruction.Instruction.Operation)
                    {
                        case '<':
                            max[instructionVariable] = Math.Min(instruction.Instruction.Value - 1 ?? 4000, max[instructionVariable]);
                            break;
                        case '>':
                            min[instructionVariable] = Math.Max(instruction.Instruction.Value + 1 ?? 0, min[instructionVariable]);
                            break;
                    };
                }

                return (max[0] - min[0] + 1) * (max[1] - min[1] + 1) * (max[2] - min[2] + 1) * (max[3] - min[3] + 1);
            });

            return partCounts.Sum();
        }
    }

    public class InstructionBranch
    {
        public InstructionBranch(InstructionBranchInstruction instruction)
        {
            Instructions.Add(instruction);
        }

        public InstructionBranch(List<InstructionBranchInstruction> instructions)
        {
            Instructions.AddRange(instructions);
        }

        public List<InstructionBranchInstruction> Instructions { get; private set; } = new();

        public InstructionBranch CloneAndAdd(InstructionBranchInstruction instruction)
        {
            var instructionBranch = new InstructionBranch(Instructions);
            instructionBranch.Instructions.Add(instruction);
            return instructionBranch;
        }
    }

    public record InstructionBranchInstruction(PartCheckerWorkflowInstruction Instruction, string Workflow);

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
                if (instruction.IsDefaultOperation)
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

        private PartCheckerWorkflowInstruction()
        {
            Destination = string.Empty;
        }

        public char? VariableName { get; private set; }
        public char? Operation { get; private set; }
        public long? Value { get; private set; }
        public string Destination { get; private set; }
        public bool IsDefaultOperation => VariableName == null;

        public PartCheckerWorkflowInstruction Inverse()
        {
            return new PartCheckerWorkflowInstruction
            {
                VariableName = VariableName,
                Operation = Operation == '<' ? '>' : '<',
                Value = Operation == '<' ? Value - 1 : Value + 1,
                Destination = Destination 
            };
        }
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
