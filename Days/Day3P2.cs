using System.Linq;

namespace AdventOfCode2022.Days;

public class Day3P2 : Day
{
    public override void Run(List<string> input)
    {
        int sum = 0;
        for (int i = 0; i < input.Count; i += 3)
        {
            char? item = null;
            string line = input[i];
            foreach (char c in line)
            {
                if (input[i + 1].Contains(c) && input[i + 2].Contains(c))
                {
                    item = c;
                }
            }
            if (item is not null)
            {
                sum += GetPriority(item.Value);
            }
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