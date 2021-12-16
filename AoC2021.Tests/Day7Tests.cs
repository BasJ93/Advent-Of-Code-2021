
using AoC2021.Implementations;
using NUnit.Framework;
using System.Linq;

namespace AoC2021.Tests
{
    public class Day7Tests
    {
        string[] sampleData = {
            "16,1,2,0,4,2,7,1,2,14"
        };

        [Test]
        public void Task1_Returns37_ForSampleData()
        {
            var d = new Day7();
            var output = d.Task1(sampleData);

            Assert.AreEqual(37, output);
        }

        [Test]
        public void Task2_Returns168_ForSampleData()
        {
            var d = new Day7();
            var output = d.Task2(sampleData);

            Assert.AreEqual(168, output);
        }
    }
}