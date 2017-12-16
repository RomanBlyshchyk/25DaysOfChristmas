using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day6_Memory;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day6Tests
    {
        [TestCase(new int[] { 0, 2, 7, 0 }, 5)]
        [TestCase(new int[] { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 }, 5)]
        [Test]
        public void CountCyclesTest(int[] input, int result)
        {
            var count = Day6.CountCycles(input);
            Assert.AreEqual(result, count);
        }

        [TestCase(new int[] { 0, 2, 7, 0 }, new int[] { 2, 4, 1, 2 })]
        [TestCase(new int[] { 2, 4, 1, 2 }, new int[] { 3, 1, 2, 3 })]
        [TestCase(new int[] { 3, 1, 2, 3 }, new int[] { 0, 2, 3, 4 })]
        [TestCase(new int[] { 0, 2, 3, 4 }, new int[] { 1, 3, 4, 1 })]
        [TestCase(new int[] { 1, 3, 4, 1 }, new int[] { 2, 4, 1, 2 })]
        [Test]
        public void PerformRedistributionTest(int[] input, int[] result)
        {
            var output = Day6.PerformRedistribution(input);
            Assert.AreEqual(output, result);
        }
    }
}
