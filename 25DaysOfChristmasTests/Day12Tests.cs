using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day12Tests
    {

        [TestCase(@"0 <-> 2
                    1 <-> 1
                    2 <-> 0, 3, 4
                    3 <-> 2, 4
                    4 <-> 2, 3, 6
                    5 <-> 6
                    6 <-> 4, 5",6)]
        [Test]
        public void FindGroupSizeTest(string input, int result)
        {
            var totalScore = Day12.Day12.FindGroupSize(input);
            Assert.AreEqual(result, totalScore);
        }
    }
}
