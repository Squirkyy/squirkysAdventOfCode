using System.Net;

namespace AdventOfCode
{
    class Day1
    {
        public static void CalorieCounting()
        {
            Dictionary<int, int> elves = new Dictionary<int, int>();
            elves.Add(0, 0);
            int index = 0;
            foreach (string line in File.ReadLines(
                         @"C:\Users\Dariu\Documents\source\squirkysAdventOfCode\AdventOfCode\CalorieCounting.txt"))
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
            var list = 
                (from entry in elves
                orderby entry.Value descending
                select entry).Take(topCount);
            int i = 1;
            int sum = 0;
            foreach (var test in list)
            {
                Console.WriteLine(
                    $"The elf with the {i}. calorie amount is elf {test.Key} with a count of {test.Value} \n");
                i++;
                sum += test.Value;
            }
            Console.WriteLine("They have a combined calorie count of " + sum);
        }
    }
}