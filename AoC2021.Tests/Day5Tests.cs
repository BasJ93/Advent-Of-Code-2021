
using AoC2021.Implementations;
using NUnit.Framework;
using System.Linq;

namespace AoC2021.Tests
{
    public class LineTests
    {
        [Test]
        public void LineOf2Points_Returns2Points()
        {
            var line = new Line("0,0 -> 0,1");

            var points = line.GetPointsInLine();

            Assert.AreEqual(2, points.Count());
        }

        [Test]
        public void LineOf3Points_At45Degrees_Returns3Points()
        {
            var line = new Line("0,0 -> 2,2");

            var points = line.GetPointsInLine();

            Assert.AreEqual(3, points.Count());

            Assert.AreEqual(0, points.First().X);
            Assert.AreEqual(1, points.ElementAt(1).X);
            Assert.AreEqual(2, points.Last().X);
        }

        [Test]
        public void LineOf3Points_At45DegreesWithOffset_Returns3Points()
        {
            var line = new Line("9,7 -> 7,9");

            var points = line.GetPointsInLine();

            Assert.AreEqual(3, points.Count());

            Assert.AreEqual(7, points.First().X);
            Assert.AreEqual(9, points.First().Y);
            Assert.AreEqual(8, points.ElementAt(1).X);
            Assert.AreEqual(8, points.ElementAt(1).Y);
            Assert.AreEqual(9, points.Last().X);
            Assert.AreEqual(7, points.Last().Y);
        }

    }

    public class Day5Tests
    {
        string[] sampleData = {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Test]
        public void Task1_Returns5_ForSampleData()
        {
            var d = new Day5();
            var output = d.Task1(sampleData);

            Assert.AreEqual(5, output);
        }

        [Test]
        public void Task2_Returns12_ForSampleData()
        {
            var d = new Day5();
            var output = d.Task2(sampleData);

            Assert.AreEqual(12, output);
        }
    }
}