
using AoC2021.Interfaces;

namespace AoC2021.Implementations
{
    public class Day1 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            int[] parsedInput = input.Select(i => Convert.ToInt32(i)).ToArray();

            int numberOfIncreases = 0;

            for (int i = 1; i < parsedInput.Length; i++)
            {
                if(parsedInput[i] > parsedInput[i-1])
                {
                    numberOfIncreases++;
                }
            }

            return numberOfIncreases;
        }

        public long Task2(IEnumerable<string> input)
        {
            // Calculate the sliding window data
            int[] parsedInput = input.Select(i => Convert.ToInt32(i)).ToArray();

            List<int> slidingWindowSums = new List<int>();

            for (int i = 2; i < parsedInput.Length; i++)
            {
                var slidingWindowSum = parsedInput[i - 2] + parsedInput[i - 1] + parsedInput[i];
                slidingWindowSums.Add(slidingWindowSum);
            }

            // Feed the new data into Task1 to get the result
            var numberOfIncreases = Task1(slidingWindowSums.Select(i => i.ToString()));

            return numberOfIncreases;
        }
    }
}