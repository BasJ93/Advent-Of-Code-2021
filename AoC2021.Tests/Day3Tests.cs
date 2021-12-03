
using AoC2021.Implementations;
using NUnit.Framework;

namespace AoC2021.Tests
{
    public class Day3Tests
    {
        string[] sampleData = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

        [Test]
        public void Task1_Returns198_ForSampleData()
        {
            var d = new Day3();
            var output = d.Task1(sampleData);

            Assert.AreEqual(198, output);
        }

        [Test]
        public void Task2_Returns230_ForSampleData()
        {
            var d = new Day3();
            var output = d.Task2(sampleData);

            Assert.AreEqual(230, output);
        }
    }
}