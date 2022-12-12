namespace AdventOfCode2022.Days;

public class Day9P1 : Day
{
    (int x, int y) head = (0, 0);
    (int x, int y) tail = (0, 0);

    // Relative offset to move tail to head
    (int x, int y) Diff => (head.x - tail.x, head.y - tail.y);

    HashSet<(int x, int y)> occupied = new();

    public override void Run(List<string> input)
    {
        occupied.Add(tail);
        foreach (var line in input)
        {
            string[] instructions = line.Split(' ');
            string direction = instructions[0];
            int magnitude = int.Parse(instructions[1]);
            switch (direction)
            {
                case "U":
                    for (int i = 0; i < magnitude; i++)
                    {
                        Step(0, 1);
                    }
                    break;
                case "D":
                    for (int i = 0; i < magnitude; i++)
                    {
                        Step(0, -1);
                    }
                    break;
                case "L":
                    for (int i = 0; i < magnitude; i++)
                    {
                        Step(-1, 0);
                    }
                    break;
                case "R":
                    for (int i = 0; i < magnitude; i++)
                    {
                        Step(1, 0);
                    }
                    break;
            }
        }
        Console.WriteLine(occupied.Count);
    }

    private void Step(int x, int y)
    {
        head = (head.x + x, head.y + y);
        (int x, int y) diff = Diff;
        if (Math.Abs(diff.x) > 1)
        {
            int sign = diff.x / diff.x;
            tail = (tail.x + sign, tail.y);
        }
        if (Math.Abs(diff.y) > 1)
        {
            int sign = diff.y / diff.y;
            tail = (tail.x, tail.y + sign);
        }
        occupied.Add(tail);
    }
}