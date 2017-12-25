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


        [TestCase("",0)]
        [TestCase("{}",1)]
        [TestCase("{{}}",3)]
        [TestCase("{{{}}}",6)]
        [TestCase("{{},{}}",5)]
        [TestCase("{{{},{},{{}}}}",16)]
        [TestCase("{<a>,<a>,<a>,<a>}",1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}",9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}",9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}",3)]
        [Test]
        public void FindTotalGroupScoreTest(string input, int result)
        {
            var totalScore = Day9.Day9.FindTotalGroupScore(input);
            Assert.AreEqual(result, totalScore);
        }
    }
}
