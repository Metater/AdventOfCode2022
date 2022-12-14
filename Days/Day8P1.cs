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

        /*
        var test = GetVisible(0, 0, 0, 1);
        foreach ((int x, int y) in test)
        {
            Console.WriteLine($"({x}, {y})");
        }
        */

        List<(int x, int y)> visibleTrees = new();
        bool IsAlreadyVisible(int x, int y)
        {
            foreach ((int eX, int eY) in visibleTrees)
            {
                if (eX == x && eY == y)
                {
                    return true;
                }
            }
            return false;
        }

        // Check left -> right
        for (int y = 1; y < yLength - 1; y++)
        {
            var sweep = GetVisible(0, y, 1, 0);
            foreach ((int xx, int yy) in sweep)
            {
                if (!IsAlreadyVisible(xx, yy))
                {
                    visibleTrees.Add((xx, yy));
                }
            }
        }

        // Check right -> left
        for (int y = 1; y < yLength - 1; y++)
        {
            var sweep = GetVisible(xLength - 1, y, -1, 0);
            foreach ((int xx, int yy) in sweep)
            {
                if (!IsAlreadyVisible(xx, yy))
                {
                    visibleTrees.Add((xx, yy));
                }
            }
        }

        // Check top -> bottom
        for (int x = 1; x < xLength - 1; x++)
        {
            var sweep = GetVisible(x, 0, 0, 1);
            foreach ((int xx, int yy) in sweep)
            {
                if (!IsAlreadyVisible(xx, yy))
                {
                    visibleTrees.Add((xx, yy));
                }
            }
        }

        // Check bottom -> top
        for (int x = 1; x < xLength - 1; x++)
        {
            var sweep = GetVisible(x, yLength - 1, 0, -1);
            foreach ((int xx, int yy) in sweep)
            {
                if (!IsAlreadyVisible(xx, yy))
                {
                    visibleTrees.Add((xx, yy));
                }
            }
        }

        void AddIfNotAlreadyVisable(int x, int y)
        {
            if (!IsAlreadyVisible(x, y))
            {
                visibleTrees.Add((x, y));
            }
        }

        /*
        Console.WriteLine(visibleTrees.Count);
        foreach ((int x, int y) in visibleTrees)
        {
            Console.WriteLine($"({x}, {y})");
        }
        */

        // Plus perimeter
        for (int x = 0; x < xLength; x++)
        {
            AddIfNotAlreadyVisable(x, 0);
            AddIfNotAlreadyVisable(x, yLength - 1);
        }
        for (int y = 0; y < yLength; y++)
        {
            AddIfNotAlreadyVisable(0, y);
            AddIfNotAlreadyVisable(xLength - 1, y);
        }

        Console.WriteLine(visibleTrees.Count);

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
                            visibleTrees.Add((x, y));
                            lastTree = tree;
                        }
                        if (tree == 9)
                        {
                            return visibleTrees;
                        }
                    }

                    x += iX;
                    y += iY;
                }
                else
                {
                    return visibleTrees;
                }
            }
        }
    }
}