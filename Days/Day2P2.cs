namespace AdventOfCode2022.Days;

public class Day2P2 : Day
{
    public override void Run(List<string> input)
    {
        // A rock
        // B paper
        // C scissors

        // X rock
        // Y paper
        // Z scissors

        // Score shape you selected
        // 1 rock
        // 2 paper
        // 3 scissors
        // plus 0 loss, 3 draw, 6 won

        // Time: 18:42.66

        int score = 0;

        foreach (var game in input)
        {
            string[] moves = game.Split(' ');
            string opponent = moves[0];
            string you = moves[1];
            switch (you)
            {
                case "X": // Lose
                    switch (opponent)
                    {
                        case "A": // rock
                            you = "Z";
                            break;
                        case "B": // paper
                            you = "X";
                            break;
                        case "C": // scissors
                            you = "Y";
                            break;
                    }
                    break;
                case "Y": // Draw
                    switch (opponent)
                    {
                        case "A": // rock
                            you = "X";
                            break;
                        case "B": // paper
                            you = "Y";
                            break;
                        case "C": // scissors
                            you = "Z";
                            break;
                    }
                    break;
                case "Z": // Win
                    switch (opponent)
                    {
                        case "A": // rock
                            you = "Y";
                            break;
                        case "B": // paper
                            you = "Z";
                            break;
                        case "C": // scissors
                            you = "X";
                            break;
                    }
                    break;
            }
            score += GetValue(you);
            switch (GetOutcome(opponent, you))
            {
                case WinDrawLoss.Win:
                    score += 6;
                    break;
                case WinDrawLoss.Draw:
                    score += 3;
                    break;
                case WinDrawLoss.Loss:
                    break;
            }
        }

        Console.WriteLine(score);
    }

    private int GetValue(string you)
    {
        return you switch
        {
            "X" => 1,
            "Y" => 2,
            "Z" => 3,
            _ => -100000,
        };
    }

    private WinDrawLoss GetOutcome(string opponent, string you)
    {
        if (opponent == "A" && you == "X")
        {
            return WinDrawLoss.Draw;
        }
        if (opponent == "B" && you == "Y")
        {
            return WinDrawLoss.Draw;
        }
        if (opponent == "C" && you == "Z")
        {
            return WinDrawLoss.Draw;
        }

        if (opponent == "A" && you == "Z")
        {
            return WinDrawLoss.Loss;
        }
        if (opponent == "B" && you == "X")
        {
            return WinDrawLoss.Loss;
        }
        if (opponent == "C" && you == "Y")
        {
            return WinDrawLoss.Loss;
        }

        return WinDrawLoss.Win;
    }

    public enum WinDrawLoss
    {
        Win,
        Draw,
        Loss
    }
}