namespace AdventOfCode2022;

public abstract class Day
{
    public abstract void Run(List<string> input);

    public void RunWithInput(int day, bool isReplit = false)
    {
        var input = isReplit ?
            File.ReadAllLines(@$"/home/runner/AdventOfCode2022/Input/{day}.txt").ToList() :
            File.ReadAllLines(@$"E:\Projects\Visual Studio\AdventOfCode2022\Input\{day}.txt").ToList();
        
        Run(input);
    }
}