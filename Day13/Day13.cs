using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Day13
    {
        static void Main(string[] args)
        {
            //"C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day13\\input.txt"
            //@"c:\users\roman\source\repos\25daysofchristmas\day13\input.txt"
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day13\\input.txt"))
            {
                Console.WriteLine(FindSeverity(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static bool FindSeverity(string v)
        {
            throw new NotImplementedException();
        }
    }
}
