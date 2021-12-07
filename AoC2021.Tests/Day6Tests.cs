
using AoC2021.Implementations;
using NUnit.Framework;
using System.Linq;

namespace AoC2021.Tests
{
    public class Day6Tests
    {
        string[] sampleData = {
            "3,4,3,1,2"
        };

        [Test]
        public void Task1_Returns5934_ForSampleData()
        {
            var d = new Day6();
            var output = d.Task1(sampleData);

            Assert.AreEqual(5934, output);
        }

        [Test]
        public void Task2_Returns26984457539_ForSampleData()
        {
            var d = new Day6();
            var output = d.Task2(sampleData);

            Assert.AreEqual(26984457539, output);
        }
    }
}