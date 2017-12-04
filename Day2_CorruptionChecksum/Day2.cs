using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_CorruptionChecksum
{
    public class Day2
    {
        static void Main(string[] args)
        {
            int part1Result;
            int part2Result;
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day2_CorruptionChecksum\\input.txt"))
            {
                var input = sr.ReadToEnd();
                part1Result = CorruptionChecksum(input);
                part2Result = EvenDivideValues(input);
            }

            Console.WriteLine($"Corruption Checksum result: {part1Result}");
            Console.WriteLine($"EvenDivideValues result: {part2Result}");
            Console.ReadKey();
        }

        public static int EvenDivideValues(string input)
        {
            var resultList = new List<int>();

            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var intValues = new List<int>();
                foreach (var value in values)
                {
                    intValues.Add(Convert.ToInt32(value.ToString()));
                }
                // Find the only two numbers in each row where one evenly divides the other.
                // That is, where the result of the division operation is a whole number. 
                // They would like you to find those numbers on each line, divide them, and add up each line's result.
                for(int i = 0; i < intValues.Count-1; i++)
                {
                    for(int j = i+1; j < intValues.Count; j++)
                    {
                        if (intValues[i] % intValues[j] == 0)
                            resultList.Add(intValues[i] / intValues[j]);
                        else if (intValues[j] % intValues[i] == 0)
                            resultList.Add(intValues[j] / intValues[i]);
                    }
                }

            }

            var result = 0;
            resultList.ForEach(x => result += x);
            return result;
        }

        public static int CorruptionChecksum(string input)
        {
            var resultList = new List<int>();

            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var intValues = new List<int>();
                foreach (var value in values)
                {
                    intValues.Add(Convert.ToInt32(value.ToString()));
                }
                var min = intValues.Min();
                var max = intValues.Max();
                resultList.Add(max - min);
            }

            var result = 0;
            resultList.ForEach(x => result += x);
            return result;
        }
    }
}
