
using AoC2021.Implementations;
using NUnit.Framework;

namespace AoC2021.Tests
{
    public class Day2Tests
    {
        string[] sampleData = { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

        [Test]
        public void Task1_Returns150_ForSampleData()
        {
            var d = new Day2();
            var output = d.Task1(sampleData);

            Assert.AreEqual(150, output);
        }

        [Test]
        public void Task2_Returns900_ForSampleData()
        {
            var d = new Day2();
            var output = d.Task2(sampleData);

            Assert.AreEqual(900, output);
        }
    }
}