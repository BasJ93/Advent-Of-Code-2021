using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public class Day3 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            Dictionary<int, Dictionary<char, int>> positionalValues = PreProcessInput(input);

            // Most common bit
            string gamma = String.Empty;

            // Least common bit
            string epsilon = String.Empty;

            for (int x = 0; x < positionalValues.Count; x++)
            {
                var bit = positionalValues[x];
                var ordered = bit.OrderByDescending(b => b.Value);
                gamma += ordered.First().Key;
                epsilon += ordered.Last().Key;
            }

            // Multiply and return
            var result = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);

            return result;
        }

        public long Task2(IEnumerable<string> input)
        {
            // Oxygen
            // First bit is the most common
            // Search until a single input is left
            var maxNumberOfPositions = input.First().Length;
            var reducedInput = input;
            for (int i = 0; i < maxNumberOfPositions; i++)
            {
                reducedInput = ReduceInput(reducedInput, i, '1', true);

                if(reducedInput.Count() == 1)
                {
                    break;
                }
            }

            var oxygen = Convert.ToInt32(reducedInput.First(), 2);

            // CO2
            reducedInput = input;
            for (int i = 0; i < maxNumberOfPositions; i++)
            {
                reducedInput = ReduceInput(reducedInput, i, '0', false);

                if(reducedInput.Count() == 1)
                {
                    break;
                }
            }

            var co2 = Convert.ToInt32(reducedInput.First(), 2);

            return oxygen * co2;
        }

        private IEnumerable<string> ReduceInput(IEnumerable<string> input, int bitToEvaluate, char defaultValue, bool highestCount)
        {
            Dictionary<int, Dictionary<char, int>> positionalValues = PreProcessInput(input);

            char bitValue;

            if (positionalValues[bitToEvaluate]['0'] == positionalValues[bitToEvaluate]['1'])
            {
                bitValue = defaultValue;
            }
            else
            {
                if(highestCount)
                    bitValue = positionalValues[bitToEvaluate].OrderByDescending(b => b.Value).First().Key;
                else
                    bitValue = positionalValues[bitToEvaluate].OrderByDescending(b => b.Value).Last().Key;
            }

            var reducedInput = input.Where(i => i[bitToEvaluate] == bitValue);

            return reducedInput;
        }


        private Dictionary<int, Dictionary<char, int>> PreProcessInput(IEnumerable<string> input)
        {
            Dictionary<int, Dictionary<char, int>> positionalValues = new Dictionary<int, Dictionary<char, int>>();

            foreach (var i in input)
            {
                for (int j = 0; j < i.Length; j++)
                {
                    if (!positionalValues.ContainsKey(j))
                    {
                        positionalValues.Add(j, new Dictionary<char, int>());
                    }

                    if (!positionalValues[j].ContainsKey(i[j]))
                    {
                        positionalValues[j].Add(i[j], 0);
                    }

                    positionalValues[j][i[j]]++;
                }
            }

            return positionalValues;
        }
    }
}