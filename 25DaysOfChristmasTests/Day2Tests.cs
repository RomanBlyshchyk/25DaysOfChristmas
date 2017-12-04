using Day1_InverseCaptcha;
using Day2_CorruptionChecksum;
using NUnit.Framework;


namespace _25DaysOfChristmasTests
{
    [TestFixture]
    public class Day2Tests
    {

        [TestCase("", 0)]
        [TestCase("1 2 3 \n 4 5 6 \n 7\t8 9", 6)]
        [Test]
        public void InverseCapchaTest(string input, int result)
        {
            var x = Day2.CorruptionChecksum(input);
            Assert.AreEqual(result, x);
        }
    }
}
