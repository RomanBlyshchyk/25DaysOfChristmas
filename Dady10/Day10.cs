using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Day10
    {
        private static int _hashSize = 256;
        private static int _skipSize = 0;
        private static int _startPosition = 0;
        //input : 187,254,0,81,169,219,1,190,19,102,255,56,46,32,2,216
        static void Main(string[] args)
        {
            #region Part 1
            //var input = new List<int>()
            //{
            //    187, 254, 0, 81, 169, 219, 1, 190, 19, 102, 255, 56, 46, 32, 2, 216
            //};

            //var input2 = new List<int>()
            //{
            //    3,4,1,5
            //};

            //Console.WriteLine(KnotHashRound(input)); 
            #endregion

            var stringInput = "187,254,0,81,169,219,1,190,19,102,255,56,46,32,2,216";
            var input = new List<int>();
            foreach (var item in stringInput.ToCharArray())
            {
                input.Add(Convert.ToInt32(item));
            }
            input.AddRange(new List<int>() { 17, 31, 73, 47, 23 });
            Console.WriteLine(KnotHash(input));
            Console.ReadKey();

        }

        public static string KnotHash(List<int> input)
        {
            var list = new List<int>();
            for (int i = 0; i < _hashSize; i++)
                list.Add(i);

            for (int i = 0; i < 64; i++)
                KnotHashRound(input, list);

            // calculate dense hash --> 16 numbers 
            var denseHash = new List<int>();
            for (int i = 0; i < _hashSize; i += 16)
            {
                var subset = list.GetRange(i, 16);
                var denseValue = 0;
                foreach (var item in subset)
                {
                    denseValue = denseValue ^ item;
                }
                denseHash.Add(denseValue);
            }

            // convert each number into hex value and combine into 32 hex digit value
            var hexValue = "";
            foreach (var item in denseHash)
            {
                // convert item to hex....somehow
                var hex = item.ToString("X");
                if(hex.Length == 1)
                {
                    var leadingZero = "0";
                    var sum = leadingZero + hex;
                    hex = sum;
                }
                hexValue += hex;
            }

            return hexValue.ToLower();    //3efbe78a8d82f29979031a4aa0b16a9d
        }

        private static void KnotHashRound(List<int> input, List<int> list)
        {
            foreach (var item in input)
            {
                if (_startPosition + item <= list.Count)
                {
                    list.Reverse(_startPosition, item);
                }
                else
                {
                    var startCount = (_startPosition + item) % (list.Count);
                    var endCount = item - startCount;

                    var selectedList = list.GetRange(_startPosition, endCount);
                    selectedList.AddRange(list.GetRange(0, startCount));
                    selectedList.Reverse();

                    // replace items in the original list with the changed selection
                    list.RemoveRange(_startPosition, endCount);
                    list.RemoveRange(0, startCount);

                    list.AddRange(selectedList.GetRange(0, endCount));
                    list.InsertRange(0, selectedList.GetRange(endCount, startCount));
                }

                _startPosition = (_startPosition + item + _skipSize) % list.Count;
                _skipSize++;
            }
        }

        public static int KnotHashGame(List<int> input)
        {
            var list = new List<int>();
            for (int i = 0; i < _hashSize; i++)
                list.Add(i);

            KnotHashRound(input, list);

            var result = list[0] * list[1];
            return result;
        }
    }
}
