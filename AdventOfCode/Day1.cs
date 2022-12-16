using System.Net;

namespace AdventOfCode
{
    class Day1
    {
        static void Main()
        {
            CalorieCounting();
        }

        private static void CalorieCounting()
        {
            Dictionary<int, int> elves = new Dictionary<int, int>();
            elves.Add(0, 0);
            int index = 0;
            foreach (string line in File.ReadLines(
                         @"C:/Users/Dariu/Documents/source/AdventOfCode/AdventOfCode/CalorieCounting.txt"))
            {
                if (String.IsNullOrEmpty(line))
                {
                    index++;
                    elves.Add(index, 0);
                    continue;
                }

                elves[index] += Convert.ToInt32(line);
            }
            GetTopElves(elves, 1);
            GetTopElves(elves, 3);
        }

        private static void GetTopElves(Dictionary<int, int> elves, int topCount)
        {
            if (topCount == 1)
            { 
                Console.WriteLine(
                    $"The elf with the highest calorie amount is elf {elves.Keys.Max()} with a count of {elves.Values.Max()} \n");
            }
            
            for (int i = 1; i < topCount + 1; i++)
            {
                Console.WriteLine(
                    $"The elf with the {i}. calorie amount is elf {elves.Keys.Max()} with a count of {elves.Values.Max()} \n");
                elves.Remove(elves.Keys.Max());
            }
        }
    }
}