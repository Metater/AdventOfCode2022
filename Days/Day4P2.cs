namespace AdventOfCode2022.Days;

public class Day4P2 : Day
{
    public override void Run(List<string> input)
    {
        int count = 0;
        foreach (var line in input)
        {
            //Console.WriteLine(line);
            string[] pair = line.Split(',');
            string[] a = pair[0].Split('-');
            string[] b = pair[1].Split('-');
            int startA = int.Parse(a[0]);
            int endA = int.Parse(a[1]);
            int startB = int.Parse(b[0]);
            int endB = int.Parse(b[1]);
            //Console.WriteLine($"sA: {startA}");
            //Console.WriteLine($"eA: {endA}");
            //Console.WriteLine($"sB: {startB}");
            //Console.WriteLine($"eB: {endB}");
            if (startA >= startB && endA <= startB) // Is start B in the range of A whatsoever
            {
                //Console.WriteLine("A");
                count++;
            }
            if (startA >= endB && endA <= endB) // Is end B in the range of A whatsoever
            {
                //Console.WriteLine("A");
                count++;
            }
            else if (startB >= startA && endB <= startA) // Is start A in the range of B whatsoever
            {
                //Console.WriteLine("B");
                count++;
            }
            else if (startB >= endA && endB <= endA) // Is end A in the range of B whatsoever
            {
                //Console.WriteLine("B");
                count++;
            }
            //Console.WriteLine();
        }
        Console.WriteLine(count);
    }
}