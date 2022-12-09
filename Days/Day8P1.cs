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

        var trees = GetVisible(0, 0, 0, 1);
        foreach ((int x, int y) in trees)
        {
            Console.WriteLine($"({x}, {y})");
        }

        bool TryGetTree(int x, int y, out int tree)
        {
            if (x >= 0 && x < xLength && y >= 0 && y < yLength)
            {
                tree = trees[x, y];
                return true;
            }
            tree = default;
            return false;
        }

        // Start at a position and iterate by iX and iY, looking for trees taller than the last
        // Returns position of that tree
        List<(int x, int y)> GetVisible(int x, int y, int iX, int iY)
        {
            List<(int x, int y)> visibleTrees = new();
            int lastTree = -1;
            while (true)
            {
                if (TryGetTree(x, y, out int tree))
                {
                    if (lastTree == -1) // first cycle
                    {
                        lastTree = tree;
                    }
                    else // not first cycle
                    {
                        if (tree > lastTree) // visible from outside of grid
                        {
                            lastTree = tree;
                            visibleTrees.Add(tree);
                        }
                        if (tree == 9)
                        {
                            return visibleTrees;
                        }
                    }
                }
                else
                {
                    return visibleTrees;
                }
            }
        }
    }
}