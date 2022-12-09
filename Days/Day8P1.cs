namespace AdventOfCode2022.Days;

public class Day8P1 : Day
{
    public override void Run(List<string> input)
    {
        // Trees in grid
        // Heights of trees is input
        int xLength = input[0].Length;
        int yLength = input.Count;
        int[,] trees = new int[xLength, yLength];
        for (int y = 0; y < yLength - 1; y++)
        {
            for (int x = 0; x < xLength - 1; x++)
            {
                Console.Write("0");
            }
            Console.WriteLine();
        }
    }
}