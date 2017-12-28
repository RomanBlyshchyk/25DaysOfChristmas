using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day12Tests
    {

        [TestCase("", 0)]
        [Test]
        public void FindGroupSizeTest(string input, int result)
        {
            var totalScore = Day12.Day12.FindGroupSize(input);
            Assert.AreEqual(result, totalScore);
        }
    }
}
