namespace AdventOfCode2022;

public abstract class Day
{
    public abstract void Run(List<string> input);

    public void RunWithInput(int day)
    {
        var input = File.ReadAllLines(@$"E:\Projects\Visual Studio\AdventOfCode2022\Input\{day}.txt").ToList();
        Run(input);
    }
}