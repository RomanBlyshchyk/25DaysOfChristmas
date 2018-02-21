using Day1_InverseCaptcha;
using Day2_CorruptionChecksum;
using NUnit.Framework;


namespace _25DaysOfChristmasTests
{
    [TestFixture]
    public class Day02Tests
    {

        [TestCase("", 0)]
        [TestCase("1 2 3 \r\n 4 5 6 \r\n 7\t8 9", 6)]
        [TestCase("5 1 9 5\r\n7 5 3\r\n2 4 6 8",18)]
        [Test]
        public void InverseCapchaTest(string input, int result)
        {
            var x = Day02.CorruptionChecksum(input);
            Assert.AreEqual(result, x);
        }

        [TestCase("", 0)]
        [TestCase("5 9 2 8 \r\n 9 4 7 3\r\n3 8 6 5",9)]
        [Test]
        public void EvenDivideValuesTest(string input, int result)
        {
            var x = Day02.EvenDivideValues(input);
            Assert.AreEqual(result, x);
        }
    }
}
