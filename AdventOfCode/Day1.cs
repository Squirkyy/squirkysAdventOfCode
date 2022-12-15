using System.Net;

namespace AdventOfCode
{
    class Day1
    {
        static void Main()
        {
            CalorieCounting();
        }
        public static void CalorieCounting()
        {
            string s = File.ReadAllText(@"C:/Users/Dariu/Documents/source/AdventOfCode/AdventOfCode/CalorieCounting.txt");
            Console.WriteLine(s);
        }   
    }
}