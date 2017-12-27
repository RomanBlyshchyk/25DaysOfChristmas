using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dady10
{
    public class Day10
    {
        //input : 187,254,0,81,169,219,1,190,19,102,255,56,46,32,2,216
        static void Main(string[] args)
        {
            var input = new List<int>()
            {
                187, 254, 0, 81, 169, 219, 1, 190, 19, 102, 255, 56, 46, 32, 2, 216
            };


        }

        public static int KnotHash(List<int> input)
        {
            var list = new List<int>();
            for (int i = 0; i < 256; i++)
                list.Add(i);

            var skipSize = 0;
            var startPosition = 0;
            foreach (var item in input)
            {


                startPosition = (startPosition + item + skipSize) % list.Count;
                skipSize++;
            }
            return 0;
        }
    }
}
