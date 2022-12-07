namespace AdventOfCode2022.Days;

public class Day5P1 : Day
{
    public override void Run(List<string> input)
    {
        GetProcedure(input);
    }

    private List<List<string>> GetStacks(List<string> input)
    {

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

            Console.WriteLine(line);
        }

        return procedure;
    }
}