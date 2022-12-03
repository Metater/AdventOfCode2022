namespace AdventOfCode2022.Days;

public class Day3P1 : Day
{
    public override void Run(List<string> input)
    {
        Console.WriteLine(GetPriority('A'));

        int sum = 0;
        foreach (var line in input)
        {
            int size = line.Length / 2;
            string a = line[..size];
            string b = line.Substring(size, size);
            sum += GetPriority(GetCommon(a, b));
        }
        Console.WriteLine(sum);
    }

    public char GetCommon(string a, string b)
    {
        foreach (char c in a)
        {
            if (b.Contains(c))
            {
                return c;
            }
        }
        return ' ';
    }

    public int GetPriority(char c)
    {
        int ascii = (int)c;
        if (ascii >= 97) // lowercase
        {
            ascii -= 96;
            return ascii;
        }
        else // uppercase 65
        {
            ascii -= 64 - 26;
            return ascii;
        }
    }
}