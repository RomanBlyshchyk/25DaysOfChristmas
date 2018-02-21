using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day7_Circus;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day07Tests
    {

        [TestCase("","")]
        [Test]
        public void FindRootTest(string input, string result)
        {
            var root = Day07.FindRoot(input);
            Assert.AreEqual(result, root);
        }
    }
}
