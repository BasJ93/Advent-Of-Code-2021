using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public static class MatrixExtentions
    {
        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }

    public class BingoCard
    {
        private int[,] Card { get; set; } = new int[5, 5];

        private bool[,] Markings { get; set; } = new bool[5, 5];

        public BingoCard(IEnumerable<string> input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                var values = input.ElementAt(i).Split(" ").Where(v => !string.IsNullOrEmpty(v)).Select(v => Convert.ToInt32(v));

                for (int j = 0; j < values.Count(); j++)
                {
                    Card[i, j] = values.ElementAt(j);
                }
            }
        }

        /// <summary>
        /// Checks if a number is on this card, and if so marks the location.
        /// </summary>
        /// <param name="drawnNumber">The number that was drawn</param>
        public void Draw(int drawnNumber)
        {
            for (int i = 0; i < Card.GetLength(1); i++)
            {
                for (int j = 0; j < Card.GetLength(0); j++)
                {
                    if (Card[i, j] == drawnNumber)
                    {
                        Markings[i, j] = true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the card contains a Bingo in a row and or column.
        /// </summary>
        /// <returns>A boolean bingo</returns>
        public bool HasBingo()
        {
            // Check the rows
            for (int i = 0; i < 5; i++)
            {
                if(!Markings.GetRow(i).Contains(false))
                {
                    return true;
                }
            }

            // Check the columns
            for (int i = 0; i < 5; i++)
            {
                if(!Markings.GetColumn(i).Contains(false))
                {
                    return true;
                }
            }

            return false;
        }

        public long SumOfUnmarkedNumbers()
        {
            long result = 0;
            for (int i = 0; i < Markings.GetLength(1); i++)
            {
                for (int j = 0; j < Markings.GetLength(0); j++)
                {
                    if (!Markings[i, j])
                    {
                        result += Card[i, j];
                    }
                }
            }

            return result;
        }
    }

    public class Day4 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            var numbersToDraw = input.First().Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            var cards = new List<BingoCard>();

            var inputArray = input.Skip(2).ToArray();

            for (int i = 0; i < input.Count() - 5; i+=6)
            {
                cards.Add(new BingoCard(inputArray[i..(i + 5)]));
            }

            long cardValue = 0;
            int j = 0;

            for (j = 0; j < numbersToDraw.Count(); j++)
            {
                foreach (var card in cards)
                {
                    card.Draw(numbersToDraw[j]);
                    if(card.HasBingo())
                    {
                        cardValue = card.SumOfUnmarkedNumbers();
                        break;
                    }
                }
                if(cardValue != 0)
                {
                    break;
                }
            }

            return cardValue * numbersToDraw[j];
        }

        public long Task2(IEnumerable<string> input)
        {
            var numbersToDraw = input.First().Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            var cards = new List<BingoCard>();

            var inputArray = input.Skip(2).ToArray();

            for (int i = 0; i < input.Count() - 5; i+=6)
            {
                cards.Add(new BingoCard(inputArray[i..(i + 5)]));
            }

            List<BingoCard> lastCardWithBingo = new List<BingoCard>();
            int lastCardWithBingoInput = 0;

            for (int j = 0; j < numbersToDraw.Count(); j++)
            {
                foreach(var card in cards)
                {
                    card.Draw(numbersToDraw[j]);
                    if(card.HasBingo())
                    {
                        lastCardWithBingo.Add(card);
                        lastCardWithBingoInput = numbersToDraw[j];
                    }
                }
                if (lastCardWithBingo.Count() != 0)
                {
                    foreach (var card in lastCardWithBingo)
                    {
                        cards.Remove(card);
                    }
                    //lastCardWithBingo.Clear();
                }
            }

            return lastCardWithBingo.Last().SumOfUnmarkedNumbers() * lastCardWithBingoInput;
        }
    }
}