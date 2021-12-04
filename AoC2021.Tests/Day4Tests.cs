
using AoC2021.Implementations;
using NUnit.Framework;

namespace AoC2021.Tests
{
    public class BingoCardTests
    {
        string[] sampleCardInput = {
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7"
            };

        [Test]
        public void Constructor_ThrowsNoException()
        {
           Assert.DoesNotThrow(() =>  new BingoCard(sampleCardInput));
        }

        [Test]
        public void HasBingo_ReturnsFalse_AfterInitialisation()
        {
            var card = new BingoCard(sampleCardInput);

            Assert.IsFalse(card.HasBingo());
        }

        [Test]
        public void HasBingo_ReturnsTrue_ForRow()
        {
            var card = new BingoCard(sampleCardInput);

            card.Draw(10);
            card.Draw(16);
            card.Draw(15);
            card.Draw(9);
            card.Draw(19);

            Assert.IsTrue(card.HasBingo());
        }

        [Test]
        public void HasBingo_ReturnsTrue_ForColumn()
        {
            var card = new BingoCard(sampleCardInput);

            card.Draw(17);
            card.Draw(15);
            card.Draw(23);
            card.Draw(13);
            card.Draw(12);

            Assert.IsTrue(card.HasBingo());
        }

        [Test]
        public void SumOfUnmarkedNumbers_Returns_188()
        {
            var card = new BingoCard(sampleCardInput);

            int[] numbersToDraw = { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24 };

            foreach (var value in numbersToDraw)
            {
                card.Draw(value);
            }

            Assert.AreEqual(188, card.SumOfUnmarkedNumbers());
        }
    }

    public class Day4Tests
    {
        string[] sampleData = { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
        "",
        "22 13 17 11  0",
        " 8  2 23  4 24",
        "21  9 14 16  7",
        " 6 10  3 18  5",
        " 1 12 20 15 19",
        "",
        " 3 15  0  2 22",
        " 9 18 13 17  5",
        "19  8  7 25 23",
        "20 11 10 24  4",
        "14 21 16 12  6",
        "",
        "14 21 17 24  4",
        "10 16 15  9 19",
        "18  8 23 26 20",
        "22 11 13  6  5",
        " 2  0 12  3  7" 
        };

        [Test]
        public void Task1_Returns4512_ForSampleData()
        {
            var d = new Day4();
            var output = d.Task1(sampleData);

            Assert.AreEqual(4512, output);
        }

        [Test]
        public void Task2_Returns1924_ForSampleData()
        {
            var d = new Day4();
            var output = d.Task2(sampleData);

            Assert.AreEqual(1924, output);
        }
    }
}