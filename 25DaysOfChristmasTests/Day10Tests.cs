using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day10;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day10Tests
    {

        [TestCase("187, 254, 0, 81, 169, 219, 1, 190, 19, 102, 255, 56, 46, 32, 2, 216", 1980)]
        [Test]
        public void KnotHashGameTest(string input, int result)
        {
            var list = new List<int>();
            foreach (var item in input.Split(','))
            {
                list.Add(Convert.ToInt32(item.ToString()));
            }

            var totalScore = Day10.Day10.KnotHashGame(list);
            Assert.AreEqual(result, totalScore);
        }


        [Test]
        public void KnotHashTest(string input, string result)
        {
            var inputList = new List<int>();
            foreach (var item in input.ToCharArray())
            {
                inputList.Add(Convert.ToInt32(item));
            }
            inputList.AddRange(new List<int>() { 17, 31, 73, 47, 23 });

            var totalScore = Day10.Day10.KnotHash(inputList);
            Assert.AreEqual(result, totalScore);
        }
    }
}
