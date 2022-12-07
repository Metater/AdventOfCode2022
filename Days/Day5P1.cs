namespace AdventOfCode2022.Days;

public class Day5P1 : Day
{
    public override void Run(List<string> input)
    {
        var stacks = GetStacks(input);
        var procedure = GetProcedure(input);

        foreach (var instruction in procedure)
        {
            int amount = instruction.amount;
            int from = instruction.from;
            int to = instruction.to;

            var fromStack = stacks[from - 1];
            var toStack = stacks[to - 1];
            for (int i = 0; i < amount; i++)
            {
                toStack.Add(fromStack.Last());
                fromStack.RemoveAt(fromStack.Count - 1);
            }
        }

        StringBuilder answer = new();
        foreach (var stack in stacks)
        {
            answer.Append(stack.Last());
        }
        Console.WriteLine(answer);
    }

    private List<List<char>> GetStacks(List<string> input)
    {
        List<List<char>> stacks = new();

        int stackCount = -1;
        bool hasStacksStarted = false;
        input.Reverse();
        foreach (var line in input)
        {
            if (!hasStacksStarted)
            {
                if (string.IsNullOrEmpty(line))
                {
                    hasStacksStarted = true;
                }

                continue;
            }

            if (line.Trim()[0] == '1') // crate numbers
            {
                stackCount = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                for (int i = 0; i < stackCount; i++)
                {
                    stacks.Add(new());
                }
            }
            else // crates
            {
                for (int i = 0; i < stackCount; i++)
                {
                    // 1, 5, 9, 13
                    int index = ((i * 5) - i) + 1;
                    char c = line[index];
                    if (c != ' ')
                    {
                        stacks[i].Add(c);
                    }
                }
            }
        }
        input.Reverse();
        return stacks;
    }

    private List<(int amount, int from, int to)> GetProcedure(List<string> input)
    {
        List<(int amount, int from, int to)> procedure = new();
        
        bool hasProcedureStarted = false;
        foreach (var line in input)
        {
            if (!hasProcedureStarted)
            {
                if (string.IsNullOrEmpty(line))
                {
                    hasProcedureStarted = true;
                }

                continue;
            }

            string[] instruction = line.Split(' ');
            procedure.Add((int.Parse(instruction[1]), int.Parse(instruction[3]), int.Parse(instruction[5])));
        }

        return procedure;
    }
}