namespace AdventOfCode2022.Days;

public class Day4P1 : Day
{
    public override void Run(List<string> input)
    {
        int count = 0;
        foreach (var line in input)
        {
            Console.WriteLine(input);
            string[] pair = line.Split(',');
            string[] a = pair[0].Split('-');
            string[] b = pair[1].Split('-');
            int startA = int.Parse(a[0]);
            int endA = int.Parse(a[1]);
            int startB = int.Parse(b[0]);
            int endB = int.Parse(b[1]);
            if (startA >= startB && endA >= endB) // Does A fully contain B?
            {
                Console.WriteLine("A");
                count++;
            }
            else if (startB >= startA && endB >= endA) // Does B fully contain A?
            {
                Console.WriteLine("B");
                count++;
            }
        }
        Console.WriteLine(count);
    }
}