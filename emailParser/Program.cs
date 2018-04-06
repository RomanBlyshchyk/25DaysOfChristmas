using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emailParser
{
    /// <summary>
    /// Parses out copied email text form Outlook email.  Not part of AOC Challenge. Just something I did for fun :) 
    /// </summary>
    class Program
    {
        // Input format Bob Smith <bob.smith@foocompany.com>;
        // Output format: bob.smith@foocompany.com
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"C:\Development\VS2015\Projects\25DaysOfChristmas\emailParser\input.txt"))
            {
                var input = sr.ReadToEnd();

                var names = input.Split(';');
                using (var sw = new StreamWriter(@"C:\Development\VS2015\Projects\25DaysOfChristmas\emailParser\output.txt"))
                {
                    foreach (var name in names)
                    {
                        var start = name.IndexOf('<') + 1;
                        var end = name.IndexOf('>');
                        var length = end - start;
                        var email = name.Substring(start, length);
                        sw.WriteLine(email);
                    } 
                }
            }

        }
    }
}
