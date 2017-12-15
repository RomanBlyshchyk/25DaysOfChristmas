using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day5_Trampolines;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day5Tests
    {

        [TestCase(new int[] { 0, 3, 0, 1, -3 }, 5)]
        [TestCase(new int[] { 3, 0, 0, -3 }, 3)]
        [TestCase(new int[] { 1, -1, -2, -3 }, 7)]
        [TestCase(new int[] { }, 0)]
        [Test]
        public void CountStepsToExitTest(int[] input, int result)
        {
            var stepCount = Day5.CountStepsToExit(input);
            Assert.AreEqual(stepCount, result);
        }

        [TestCase(new int[] { 0, 3, 0, 1, -3 }, 10)]
        [Test]
        public void CountStepsToExitStrangeTest(int[] input, int result)
        {
            var stepCount = Day5.CountStepsToExitStrange(input);
            Assert.AreEqual(stepCount, result);
        }
    }
}
