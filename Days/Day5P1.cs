namespace AdventOfCode2022.Days;

public class Day5P1 : Day
{
    public override void Run(List<string> input)
    {
        var procedure = GetProcedure(input);
        foreach (var instruction in procedure)
        {
            Console.WriteLine(instruction.crate);
            Console.WriteLine(instruction.from);
            Console.WriteLine(instruction.to);
            Console.WriteLine();
        }
    }

    private List<List<string>> GetStacks(List<string> input)
    {
        return null;
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