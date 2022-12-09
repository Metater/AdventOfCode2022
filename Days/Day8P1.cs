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
        for (int y = 0; y < yLength; y++)
        {
            string line = input[y];
            for (int x = 0; x < xLength; x++)
            {
                trees[x, y] = int.Parse(line[x].ToString());
            }
        }

        // Start at a position and iterate by iX and iY, looking for trees taller than the last
        // Returns position of that tree
        (int x, int y) GetVisible(int x, int y, int iX, int iY)
        {
            
        }
    }
}