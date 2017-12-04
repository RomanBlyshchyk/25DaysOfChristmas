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
            Console.WriteLine("Corruption Checksum:");
            Console.WriteLine(CorruptionChecksum("1 2 3 \n 4 5 6 \n 7\t8 9"));
            Console.ReadKey();
        }

        public static int CorruptionChecksum(string input)
        {
            var resultList = new List<int>();

            var lines = input.Split(new char[]{ '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var values = line.Split(new char[] {' ','\t' }, StringSplitOptions.RemoveEmptyEntries);
                var min = Convert.ToInt32(values.Min().ToString());
                var max = Convert.ToInt32(values.Max().ToString());
                resultList.Add(max - min);
            }

            var result = 0;
            resultList.ForEach(x => result += x);
            return result;
        }
    }
}
