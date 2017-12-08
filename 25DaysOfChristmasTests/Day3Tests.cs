using System;
using NUnit.Framework;
using Day3_SpiralMemory;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    public class Day3Tests
    {

        [TestCase(0)]
        [Test]
        public void TestMethod1(int result)
        {
            var x = Day3.SomeMethod();
            Assert.AreEqual(x, result);
        }
    }
}
