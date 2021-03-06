﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Day13;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day13Tests
    {
        private const string input = @"0: 3
                                        1: 2
                                        4: 4
                                        6: 4";


        [TestCase(input, 24)]
        [TestCase("", 0)]
        [Test]
        public void FindSeverityTest(string input, int result)
        {
            var totalScore = Day13.Day13.FindSeverity(input);  //
            Assert.AreEqual(result, totalScore);
        }

        [TestCase(input, 10)]
        [TestCase("", 0)]
        [Test]
        public void FindDelayTimeTest(string input, int result)
        {
            var totalScore = Day13.Day13.FindDelayTime(input);  //
            Assert.AreEqual(result, totalScore);
        }

    }
}
