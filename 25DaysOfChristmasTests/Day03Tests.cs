using System;
using NUnit.Framework;
using Day3_SpiralMemory;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    public class Day03Tests
    {

        [TestCase(0)]
        [Test]
        public void TestMethod1(int result)
        {
            var x = Day03.SomeMethod();//test
            Assert.AreEqual(x, result);
        }
    }
}
