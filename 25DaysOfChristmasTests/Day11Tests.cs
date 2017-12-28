using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day11Tests
    {

        [TestCase("", 0)]
        [TestCase("n", 1)]
        [TestCase("n,n,n",3)]
        [TestCase("s,s,s,s,s,s,s,s",8)]
        [TestCase("n,s,n,s",0)]
        [TestCase("ne,ne,ne,ne",4)]
        [TestCase("ne,ne,s", 2)]
        [TestCase("nw,nw,nw", 3)]
        [TestCase("se,se,se", 3)]
        [TestCase("sw,sw,sw,sw", 4)]
        [TestCase("ne,ne,sw,sw", 0)]
        [TestCase("ne,ne,s,s", 2)]
        [TestCase("se,sw,se,sw,sw", 3)]
        [TestCase("n,se,s,sw,nw,n,ne", 1)]
        [TestCase("n,se,s,sw,nw,n,ne,s", 0)]
        [TestCase("n,n,se,se,s,s,sw,sw,nw,nw,n,n,ne,ne", 2)]
        [TestCase("n,n,se,se,s,s,sw,sw,nw,nw,n,n,ne,ne,s,s", 0)]
        [TestCase("s,ne,n,nw,sw,s,se,n",0)]
        [Test]
        public void FindShortestDistanceTest(string input, int result)
        {
            var totalScore = Day11.Day11.FindShortestDistance(input);
            Assert.AreEqual(result, totalScore);
        }
    }
}
