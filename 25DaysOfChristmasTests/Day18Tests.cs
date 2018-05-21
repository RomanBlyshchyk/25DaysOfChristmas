using NUnit.Framework;

namespace _25DaysOfChristmasTests
{
    [TestFixture]
    class Day18Tests
    {
        // abcde
        const string _input = @"set a 1
                            add a 2
                            mul a a
                            mod a 5
                            snd a
                            set a 0
                            rcv a
                            jgz a -1
                            set a 1
                            jgz a -2";


        [TestCase(_input, 4)]
        [Test]
        public void Test(string input, long result)
        {
            var finalFrequency = Day18.Day18.FindFinalFrequency(input);
            Assert.AreEqual(result, finalFrequency);
        }



    }
}
