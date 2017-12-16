using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Memory
{
    public class Day6
    {
        // input:
        // 11	11	13	7	0	15	5	5	4	4	1	1	7	1	15	11
        static void Main(string[] args)
        {
            var input = new int[] { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 };
            var testinput = new int[] { 0, 2, 7, 0 };
            CountCycles(input);
        }

        public static int CountCycles(int[] input)
        {
            var history = new List<int[]>();
            var inputCopy = new int[input.Length];
            input.CopyTo(inputCopy, 0);
            history.Add(inputCopy);
            var newState = PerformRedistribution(input);
            while (history.FindIndex(x => x.SequenceEqual(newState)) < 0)
            {
                var x = new int[input.Length];
                newState.CopyTo(x,0);
                history.Add(x);
                newState = PerformRedistribution(newState);
            }
            var cycleCount = history.Count -  history.FindIndex(x => x.SequenceEqual(newState));
            return history.Count;
        }

        public static int[] PerformRedistribution(int[] input)
        {
            // find largest bloc 
            var maxValue = input.Max();
            var indexOfMax = Array.IndexOf(input, input.Max());

            //take the value out of Max and redistribute
            input[indexOfMax] = 0;
            while (maxValue != 0)
            {
                input[++indexOfMax % input.Length]++;
                maxValue--;
            }

            return input;
        }
    }
}
