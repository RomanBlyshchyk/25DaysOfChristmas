using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class Day16
    {
        public static char[] _danceFloor = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm','n', 'o', 'p' };
        //public static char[] _danceFloor = new char[] { 'a', 'b', 'c', 'd', 'e' };


        //aklbdihfncopemgj ==> WRONG
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"C:\Development\VS2015\Projects\25DaysOfChristmas\Day16\input.txt"))
            {
                var input = sr.ReadToEnd();
                var finalSequence = LetsDance(input);
                Console.WriteLine(finalSequence);
                
                Console.ReadKey();
            }
        }

        public static string LetsDance(string input)
        {
            var danceMoves = input.Split(',');
            //_danceFloor = new char[] { 'a', 'b', 'c', 'd', 'e' };
            foreach (var move in danceMoves)
            {
                if (move[0] == 's')
                {
                    // Spin     sX
                    SpinMove(move[1]);
                }
                else if (move[0] == 'x')
                {
                    // Exchange     xA/B
                    var moves = move.Substring(1).Split('/');
                    var position1 = Convert.ToInt32(moves[0].ToString());
                    var position2 = Convert.ToInt32(moves[1].ToString());

                    ExchangeMove(position1, position2);
                }
                else if (move[0] == 'p')
                {
                    // Partner      pA/B
                    PartnerMove(move[1], move[3]);
                }
                else
                {
                    // Throw Error. Unknown move
                }
            }

            string result = new string(_danceFloor);
            return result;
        }

        /// <summary>
        /// Moves by name
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private static void PartnerMove(char p1, char p2)
        {
            var position1 = 0;
            var position2 = 0;
            for (int i = 0; i < _danceFloor.Length; i++)
            {
                if (_danceFloor[i] == p1)
                {
                    position1 = Convert.ToInt32(i);
                }
                else if (_danceFloor[i] == p2)
                {
                    position2 = Convert.ToInt32(i);
                }
            }

            _danceFloor[position1] = p2;
            _danceFloor[position2] = p1;

        }

        /// <summary>
        /// Moves by reference
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private static void ExchangeMove(int p1, int p2)
        {
            var name1 = _danceFloor[p1];
            var name2 = _danceFloor[p2];

            _danceFloor[p1] = name2;
            _danceFloor[p2] = name1;

        }

        private static void SpinMove(char number)
        {
            var size = Convert.ToInt32(number.ToString());

            var backEnd = new char[size];
            var frontEnd = new char[_danceFloor.Length - size];

            for (int i = 0; i < _danceFloor.Length - size; i++)
            {
                frontEnd[i] = _danceFloor[i];
            }
            var j = 0;
            for (int i = _danceFloor.Length - size; i < _danceFloor.Length; i++)
            {
                backEnd[j++] = _danceFloor[i];
            }

            var result = backEnd.Concat(frontEnd);
            _danceFloor = result.ToArray();
        }
    }
}
