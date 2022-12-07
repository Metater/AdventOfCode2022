namespace AdventOfCode2022.Days;

public class Day5P1 : Day
{
    public override void Run(List<string> input)
    {
        var stacks = GetStacks(input);
        
        var procedure = GetProcedure(input);
    }

    private List<List<string>> GetStacks(List<string> input)
    {
        List<List<string>> stacks = new();

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
                int crateCount = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine(crateCount);
            }
            else // crates
            {

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