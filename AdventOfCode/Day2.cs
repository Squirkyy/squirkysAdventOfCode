namespace AdventOfCode;

public class Day2
{
    private enum State
    {
        Win,
        Draw,
        Loss
    }
    public static void StratGuide()
    {
        Dictionary<int, string> battles = new Dictionary<int, string>();
        int index = 0;
        foreach (string line in File.ReadLines(
                     @"C:\Users\Dariu\Documents\source\squirkysAdventOfCode\AdventOfCode\StratGuide.txt"))
        {
            battles.Add(index, RemoveWhitespace(line));
            index++;
        }
        Console.WriteLine("After following the strategy guide, you end up with a score of: " + CalcScore(battles));
    }

    public static int CalcScore(Dictionary<int, string> battles)
    {
        int score = 0;
        foreach (KeyValuePair<int,string> battle in battles)
        {
            switch (battle.Value[0])
            {
                case 'A':
                    score += 1;
                    Console.Write(1);
                    break;
                case 'B':
                    score += 2;
                    Console.Write(2);
                    break;
                case 'C':
                    score += 3;
                    Console.Write(3);
                    break;
            }

            switch (GetState(battle.Value))
            {
                case State.Loss:
                    Console.Write("+ Loss");
                    break;
                case State.Draw:
                    Console.Write(" + 3");
                    score += 3;
                    break;
                case State.Win:
                    Console.Write(" + 6");
                    score += 6;
                    break;
                default:
                    throw new ArgumentException();
            }
            Console.WriteLine(" = " + score);
        }
        return score;
    }
    private static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
    }

    private static State GetState(string battle)
    {
        switch (battle[0])
        {
            case 'A':
                switch (battle[1])
                {
                    case 'X':
                        return State.Draw;
                    case 'Y':
                        return State.Loss;
                    case 'Z':
                        return State.Win;
                }

                break;
            case 'B':
                switch (battle[1])
                {
                    case 'X':
                        return State.Win;
                    case 'Y':
                        return State.Draw;
                    case 'Z':
                        return State.Loss;
                }

                break;
            case 'C':
                switch (battle[1])
                {
                    case 'X':
                        return State.Loss;
                    case 'Y':
                        return State.Win;
                    case 'Z':
                        return State.Draw;
                }

                break;
            default:
                throw new ArgumentException();
        }
        return State.Loss;
    }

}