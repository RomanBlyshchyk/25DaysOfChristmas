using Day1_InverseCaptcha;
using NUnit.Framework;

namespace InverseCaptcha_Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class Day1Tests
    {

        [TestCase("1122", 3)]
        [TestCase("1111",4)]
        [TestCase("1234",0)]
        [TestCase("91212129",9)]
        [TestCase("534666",12)]
        [TestCase("41234567895598765432144",13)]
        [Test]
        public void InverseCapchaTest(string input, int result)
        {
            var x = Day1.InverseCapcha(input);
            Assert.AreEqual(result, x);
        }

        [TestCase("1212",6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        [Test]
        public void InverseCapchaRoundTest(string input, int result)
        {
            var x = Day1.InverseCapchaRound(input);
            Assert.AreEqual(result, x);
        }
    }
}
