namespace AdventOfCode2022.Days;

public class Day5P1 : Day
{
    public override void Run(List<string> input)
    {
        var stacks = GetStacks(input);
        foreach (var stack in stacks)
        {
            foreach (var crate in stack)
            {
                Console.WriteLine(crate);
            }
            Console.WriteLine("-------------");
        }
        
        var procedure = GetProcedure(input);
    }

    private List<List<char>> GetStacks(List<string> input)
    {
        List<List<char>> stacks = new();

        int crateCount = -1;
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
                crateCount = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                for (int i = 0; i < crateCount; i++)
                {
                    stacks.Add(new());
                }
            }
            else // crates
            {
                for (int i = 0; i < crateCount; i++)
                {
                    // 1, 5, 9, 13
                    int index = ((i * 5) - i) + 1;
                    char c = line[index];
                    stacks[i].Add(c);
                }
            }
        }
        input.Reverse();
        return stacks;
    }

    private List<(int crate, int from, int to)> GetProcedure(List<string> input)
    {
        List<(int crate, int from, int to)> procedure = new();
        
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