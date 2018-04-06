using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class Day14
    {
        static void Main(string[] args)
        {
            var puzzleInput = "flqrgnkx"; //real:   ffayrhll    test:flqrgnkx
            var hashResult = new List<string>();
            for (int i = 0; i < 128; i++)
            {
                var x = CalculateKnotHash($"{puzzleInput}-{i}");
                hashResult.Add(HexToBinary(x));
            }

            var usedSquares = CalculateUsedSquares(hashResult);

        }

        private static int CalculateUsedSquares(List<string> hashResult)
        {
            var result = 0;
            hashResult.ForEach(s => result += s.ToCharArray().Count(x => x == '1'));
            return result;
        }

        private static string HexToBinary(string x)
        {
            string result = "";

            try
            {
                result = string.Join("", x.Select(
                                            c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                                          )
                                        );

            }
            catch (Exception ex)
            {
                var error = ex;
            }
            return result;
        }

        private static string CalculateKnotHash(string input)
        {
            var inputList = new List<int>();
            foreach (var item in input.ToCharArray())
            {
                inputList.Add(Convert.ToInt32(item));
            }
            inputList.AddRange(new List<int>() { 17, 31, 73, 47, 23 });

            return Day10.Day10.KnotHash(inputList);
        }
    }
}
