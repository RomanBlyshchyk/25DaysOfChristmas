using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4_Passphrases;
using NUnit.Framework;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day04Tests
    {

        [TestCase("",0)]
        [TestCase("abc", 1)]
        [TestCase("abc ab ac", 1)]
        [TestCase("abc \r\n ab", 2)]
        [TestCase("aa bb cc dd ee \r\n aa bb cc dd aa \r\n aa bb cc dd aaa",2)]
        [Test]
        public void CountValidPassphrasesTest(string input, int result)
        {
            var feedback = Day04.CountValidPassphrases(input);
            Assert.AreEqual(result, feedback);
        }

        [TestCase("abc", 1)]
        [TestCase("abcde fghij", 1)]
        [TestCase("abcde xyz ecdab", 0)]
        [TestCase("a ab abc abd abf abj", 1)]
        [TestCase("iiii oiii ooii oooi oooo", 1)]
        [TestCase("oiii ioii iioi iiio", 0)]
        [TestCase("oiii ioii iioi iiio \r\n iiii oiii ooii oooi oooo\r\n abcde fghij", 2)]
        [Test]
        public void CountValidPassphrasesHardTest(string input, int result)
        {
            var feedback = Day04.CountValidPassphrasesHard(input);
            Assert.AreEqual(result, feedback);
        }
    }
}
