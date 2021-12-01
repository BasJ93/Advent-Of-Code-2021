
using AoC2021.Implementations;
using NUnit.Framework;

namespace AoC2021.Tests
{
    public class Day1Tests
    {
        string[] sampleData = { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };

        [Test]
        public void Task1_Returns7_ForSampleData()
        {
            var d1 = new Day1();
            var output = d1.Task1(sampleData);

            Assert.AreEqual(7, output);
        }

        [Test]
        public void Task2_Returns5_ForSampleData()
        {
            var d1 = new Day1();
            var output = d1.Task2(sampleData);

            Assert.AreEqual(5, output);
        }
    }
}