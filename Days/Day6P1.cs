namespace AdventOfCode2022.Days;

public class Day6P1 : Day
{
    public override void Run(List<string> input)
    {
        // Received serially
        // Find start of packet marker
        // Indicated by 4 unique characters
        string buffer = input[0];
        for (int i = 0; i < buffer.Length - 3; i++)
        {
            string marker = buffer.Substring(i, 4);
            //Console.WriteLine(marker);
            List<char> uniqueChars = new();
            bool markerValid = true;
            foreach (var c in marker)
            {
                if (!uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
                else
                {
                    // marker has non-unique characters
                    markerValid = false;
                    break;
                }
            }
            if (markerValid)
            {
                Console.WriteLine(i + 4);
                break;
            }
        }
    }
}