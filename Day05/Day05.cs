using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Trampolines
{
    public class Day05
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day5_Trampolines\\input.txt"))
            {

                var input = new List<int>();
                var line = sr.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    input.Add(Convert.ToInt32(line));
                    line = sr.ReadLine();
                }

                Console.WriteLine(CountStepsToExitStrange(input.ToArray()));
                Console.ReadKey();
            }
        }

        public static int CountStepsToExit(int[] input)
        {
            var stepCount = 0;
            var inputLength = input.Length;
            var currentPosition = 0;

            while(currentPosition >= 0 && currentPosition < inputLength)
            {
                var offset = input[currentPosition];
                input[currentPosition]++;
                currentPosition += offset;
                stepCount++;
            }

            return stepCount;
        }

        public static int CountStepsToExitStrange(int[] input)
        {
            var stepCount = 0;
            var inputLength = input.Length;
            var currentPosition = 0;

            while (currentPosition >= 0 && currentPosition < inputLength)
            {
                var offset = input[currentPosition];
                if (offset >= 3)
                    input[currentPosition]--;
                else
                    input[currentPosition]++;
                currentPosition += offset;
                stepCount++;
            }

            return stepCount;
        }
    }
}
