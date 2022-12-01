namespace AdventOfCode2022.Days;

public class Day1P2 : Day
{
    public override void Run(List<string> input)
    {
        List<Elf> elves = new();

        List<int> currentElf = new();
        foreach (var line in input)
        {
            if (!string.IsNullOrWhiteSpace(line)) // int
            {
                int calories = int.Parse(line);
                currentElf.Add(calories);
            }
            else // blank
            {
                elves.Add(new Elf(currentElf));
                currentElf = new();
            }
        }
        elves.Add(new Elf(currentElf));

        List<int> totalCalories = new();
        foreach (var elf in elves)
        {
            totalCalories.Add(elf.Calories.Sum());
        }
        totalCalories.Sort();

        Console.WriteLine(totalCalories.TakeLast(3).Sum());
    }

    public record Elf(List<int> Calories)
    {
        public void PrintTotal()
        {
            Console.WriteLine(Calories.Sum());
        }
    }
}