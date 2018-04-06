using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    class Day15
    {
        private static int _factorA = 16807;
        private static int _factorB = 48271;
        private static int _dividor = 2147483647;
        private static long _startValueA = 591; // real: 591 test: 65
        private static long _startValueB = 393; // real: 393 test: 8921
        private static int _iterations = 5000000;

        static void Main(string[] args)
        {
            //var pairCount = FindPairCount(_startValueA, _startValueB);
            //Console.WriteLine(pairCount);
            //Console.Read();

            var fancyPairCount = FindFancyPairCount(_startValueA, _startValueB);
            Console.WriteLine(fancyPairCount);
            Console.Read();
        }

        private static int FindFancyPairCount(long startA, long startB)
        {
            var result = 0;
            for (int i = 0; i < _iterations; i++)
            {
                startA = (startA * _factorA) % _dividor;
                while(startA % 4 != 0)
                    startA = (startA * _factorA) % _dividor;

                startB = (startB * _factorB) % _dividor;
                while(startB % 8 != 0)
                    startB = (startB * _factorB) % _dividor;

                //compare lowest 16 bits in both startA and startB
                //var lowStartA = startA 
                var lowerStartA = Convert.ToUInt16(startA & 65535);
                var lowerStartB = Convert.ToUInt16(startB & 65535);
                if (lowerStartA == lowerStartB)
                    result++;
            }

            return result;
        }

        private static int FindPairCount(long startA, long startB)
        {
            var result = 0;
            for(int i = 0; i < _iterations; i++)
            {
                startA = (startA * _factorA) % _dividor;
                startB = (startB * _factorB) % _dividor;

                //compare lowest 16 bits in both startA and startB
                //var lowStartA = startA 
                var lowerStartA = Convert.ToUInt16(startA & 65535);
                var lowerStartB = Convert.ToUInt16(startB & 65535);
                if (lowerStartA == lowerStartB)
                    result++;
            }

            return result;
        }
    }
}
