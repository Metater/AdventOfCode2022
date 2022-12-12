namespace AdventOfCode2022.Days;

public class Day8P2 : Day
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

        int GetScenicScore4(int x, int y)
        {
            int u = GetScenicScore(x, y, 0, -1);
            Console.WriteLine(u);
            int d = GetScenicScore(x, y, 0, 1);
            Console.WriteLine(d);
            int l = GetScenicScore(x, y, -1, 0);
            Console.WriteLine(l);
            int r = GetScenicScore(x, y, 1, 0);
            Console.WriteLine(r);
            int score = u * d * l * r;
            /*
            if (score == 12)
            {
                Console.WriteLine($"({x}, {y})");
            }
            */
            return score;
        }

        GetScenicScore4(2, 1);
        
        /*
        List<int> scores = new();
        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                scores.Add(GetScenicScore4(x, y));
            }
        }
        scores.Sort();
        */
        /*
        foreach (var score in scores)
        {
            Console.WriteLine(score);
        }
        */
        //Console.WriteLine(scores[scores.Count - 1]);

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
        // Returns iterations until view is blocked
        int GetScenicScore(int x, int y, int iX, int iY)
        {
            int i = 0;
            int lastTree = -1;
            while (true)
            {
                x += iX;
                y += iY;
                
                if (TryGetTree(x, y, out int tree))
                {
                    if (lastTree == -1) // first cycle
                    {
                        i++;
                        lastTree = tree;
                    }
                    else // not first cycle
                    {
                        if (tree < lastTree) // visible from outside of grid
                        {
                            return i;
                        }
                        else
                        {
                            i++;
                            lastTree = tree;
                        }
                        if (tree == 9)
                        {
                            return i;
                        }
                    }
                }
                else
                {
                    return i;
                }
            }
        }
    }
}