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
        string GetCurrentPath()
        {
            string path = $"/{string.Join('/', new Stack<string>(pwd))}";
            return path;
        }
        Dictionary<string, List<(int size, string name)>> directories = new();
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
                            pwd.Pop();
                            break;
                        default:
                            // Add dir file list just have size -1 to mark
                            directories.TryAdd(GetCurrentPath(), new());
                            var directory = directories[GetCurrentPath()];
                            bool contains = false;
                            foreach (var file in directory)
                            {
                                if (file.size == -1 && file.name == words[2])
                                {
                                    contains = true;
                                }
                            }
                            if (!contains)
                            {
                                directory.Add((-1, words[2]));
                            }
                            pwd.Push(words[2]);
                            break;
                    }
                    directories.TryAdd(GetCurrentPath(), new());
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
                    string[] file = line.Split(' ');
                    directories[GetCurrentPath()].Add((int.Parse(file[0]), file[1]));
                }
                else // is a directory
                {
                    // ignore existance for now, only matters when in directory
                }
            }
        }

        foreach ((var dir, var files) in directories)
        {
            Console.WriteLine(dir);
            foreach ((var size, var name) in files)
            {
                Console.WriteLine($"\t{name}: {size}");
            }
        }
    }
}