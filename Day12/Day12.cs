using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Day12
    {
        static void Main(string[] args)
        {

            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day12\\input.txt"))
            {
                Console.WriteLine(FindGroupSize(sr.ReadToEnd()));
            }
        }

        public static int FindGroupSize(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var groupSize = 0;

            foreach (var line in lines)
            {
                var lineParts = line.Split(' ');
                var program = lineParts[0];
                var friends = new List<string>();

                for (int i = 2; i < lineParts.Length; i++)
                {
                    friends.Add(lineParts[i]);
                }
            }

            return 0;
        }
    }
}
