using NUnit.Framework;
using System;
using System.Collections.Generic;
using Day16;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day16Tests
    {
        // abcde

        [TestCase("s1", "eabcd")]
        [TestCase("s4", "bcdea")]
        [TestCase("s0", "abcde")]
        [TestCase("x2/4", "abedc")]
        [TestCase("pb/e", "aecdb")]
        [TestCase("s1,x3/4,pe/b", "baedc")]
        [TestCase("s3","cdeab")]
        [TestCase("s3,pc/e","edcab")]
        [TestCase("s3,pc/e,x0/4","bdcae")]
        [Test]
        public void Test(string input, string result)
        {
            var state = Day16.Day16.LetsDance(input);
            Assert.AreEqual(result, state);
        }



    }
}
