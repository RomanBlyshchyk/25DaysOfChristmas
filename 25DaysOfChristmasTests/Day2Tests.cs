using Day1_InverseCaptcha;
using Day2_CorruptionChecksum;
using NUnit.Framework;


namespace _25DaysOfChristmasTests
{
    [TestFixture]
    public class Day2Tests
    {

        [TestCase("", 0)]
        [Test]
        public void InverseCapchaTest(string input, int result)
        {
            var x = Day2.CorruptionChecksum(input);
            Assert.AreEqual(result, x);
        }
    }
}
