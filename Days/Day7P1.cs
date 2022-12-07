namespace AdventOfCode2022.Days;

public class Day7P1 : Day
{
    public override void Run(List<string> input)
    {
        // Tree of files and directories, can be nested
        // Root is /
        // $ means command
        // cd x
        // cd ..
        // cd /
        // ls
        Stack<string> pwd = new();
        pwd.Push("test");
        pwd.Push("gaming");
        pwd.Push("hello");
        string GetCurrentPath() => string.Join('/', pwd);
        Console.WriteLine(GetCurrentPath());
        Dictionary<string, int> files = new();
        foreach (var line in input)
        {
            if (line[0] == '$') // command
            {
                string[] words = line.Split(' ');
                if (words[1] == "cd") // cd
                {
                    switch (words[2])
                    {
                        case "/":
                            pwd.Clear();
                            break;
                        case "..":
                            break;
                            pwd.Pop();
                        default:
                            break;
                    }
                }
                else // ls
                {
                    // Can differentiate if ls or cd by $ being first char or not
                }
            }
            else // list output
            {
                char first = line[0];
                if (char.IsDigit(first)) // is a file
                {

                }
                else // is a directory
                {
                    // ignore existance for now, only matters when in directory
                }
            }
        }
    }
}