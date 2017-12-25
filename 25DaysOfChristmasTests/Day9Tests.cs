using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day9;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day9Tests
    {
        /*
            {}, score of 1.
            {{{}}}, score of 1 + 2 + 3 = 6.
            {{},{}}, score of 1 + 2 + 2 = 5.
            {{{},{},{{}}}}, score of 1 + 2 + 3 + 3 + 3 + 4 = 16.
            {<a>,<a>,<a>,<a>}, score of 1.
            {{<ab>},{<ab>},{<ab>},{<ab>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
            {{<!!>},{<!!>},{<!!>},{<!!>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
            {{<a!>},{<a!>},{<a!>},{<ab>}}, score of 1 + 2 = 3.  
        */


        [Test]
        public void Day9TestMethod()
        {

        }
    }
}
