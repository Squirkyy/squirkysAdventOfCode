using System.Globalization;

namespace AdventOfCode;

public class Day2
{
    private enum PlayItems
    {
        Rock,
        Paper,
        Scissors
    }
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
        //score = PartI(battles, score);
        score = PartII(battles, score);
        return score;
    }

    private static int PartII(Dictionary<int, string> battles, int score)
    {
        foreach (KeyValuePair<int,string> battle in battles)
        {
            switch (GetPlayItemsFromState(GetPlayItemFromLetter(battle.Value[0]), GetStateFromLetter(battle.Value[1])))
            {
                case PlayItems.Rock:
                    score += 1;
                    break;
                case PlayItems.Paper:
                    score += 2;
                    break;
                case PlayItems.Scissors:
                    score += 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            switch (battle.Value[1])
            {
                case 'X':
                    score += 0;
                    break;
                case 'Y':
                    score += 3;
                    break;
                case 'Z':
                    score += 6;
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        return score;
    }

    private static int PartI(Dictionary<int, string> battles, int score)
    {
        foreach (KeyValuePair<int, string> battle in battles)
        {
            switch (GetPlayItemFromLetter(battle.Value[1]))
            {
                case PlayItems.Rock:
                    score += 1;
                    Console.Write(1);
                    break;
                case PlayItems.Paper:
                    score += 2;
                    Console.Write(2);
                    break;
                case PlayItems.Scissors:
                    score += 3;
                    Console.Write(3);
                    break;
            }

            switch (GetStateFromString(battle.Value))
            {
                case State.Loss:
                    Console.Write(" + Loss");
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

    private static PlayItems GetPlayItemsFromState(PlayItems enemy, State state)
    {
        switch (state)
        {
            case State.Draw:
                return enemy;
            case State.Win:
                switch (enemy)
                { 
                    case PlayItems.Paper:
                        return PlayItems.Scissors;
                    case PlayItems.Rock:
                        return PlayItems.Paper;
                    case PlayItems.Scissors:
                        return PlayItems.Rock;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(enemy), enemy, null);
                }
            case State.Loss:
                switch (enemy)
                { 
                    case PlayItems.Paper:
                        return PlayItems.Rock;
                    case PlayItems.Rock:
                        return PlayItems.Scissors;
                    case PlayItems.Scissors:
                        return PlayItems.Paper;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(enemy), enemy, null);
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    private static PlayItems GetPlayItemFromLetter(char letter)
    {
        switch (letter)
        {
            case 'A':
            case 'X':
                return PlayItems.Rock;
            case 'B':
            case 'Y':
                return PlayItems.Paper;
            case 'C':
            case 'Z':
                return PlayItems.Scissors;
        }

        throw new ArgumentException();
    }

    private static State GetStateFromLetter(char letter)
    {
        switch (letter)
        {
            case 'X':
                return State.Loss;
            case 'Y':
                return State.Draw;
            case 'Z':
                return State.Win;
            default:
                throw new ArgumentException();
        }
    }
    private static State GetStateFromString(string battle)
    {
        switch (GetPlayItemFromLetter(battle[1]))
        {
            case PlayItems.Rock:
                switch (GetPlayItemFromLetter(battle[0]))
                {
                    case PlayItems.Rock:
                        return State.Draw;
                    case PlayItems.Paper:
                        return State.Loss;
                    case PlayItems.Scissors:
                        return State.Win;
                }
                break;
            case PlayItems.Paper:
                switch (GetPlayItemFromLetter(battle[0]))
                {
                    case PlayItems.Rock:
                        return State.Win;
                    case PlayItems.Paper:
                        return State.Draw;
                    case PlayItems.Scissors:
                        return State.Loss;
                }

                break;
            case PlayItems.Scissors:
                switch (GetPlayItemFromLetter(battle[0]))
                {
                    case PlayItems.Rock:
                        return State.Loss;
                    case PlayItems.Paper:
                        return State.Win;
                    case PlayItems.Scissors:
                        return State.Draw;
                }

                break;
            default:
                throw new ArgumentException();
        }
        return State.Loss;
    }

}