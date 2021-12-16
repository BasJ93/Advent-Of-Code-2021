using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public class Day7 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            var positions = input.First().Split(",").Select(i => Convert.ToInt32(i));
            // Determine the median value
            var median = Median(positions);

            // Then calculate the deltas and sum those
            long fuelcost = 0;
            foreach(var position in positions)
            {
                fuelcost += Math.Abs(position - median);
            }

            return fuelcost;
        }

        public long Task2(IEnumerable<string> input)
        {
            var positions = input.First().Split(",").Select(i => Convert.ToInt32(i));

            // Determine the average
            var unroundedAverage = positions.Average();
            var average = Convert.ToInt32(Math.Ceiling(unroundedAverage));

            // Calculate the delta and new fuel consumption. Sum the consumption
            long fuelcost = 0;
            foreach(var position in positions)
            {
                var delta = Math.Abs(position - average);
                for (int i = 1; i < delta + 1; i++)
                {
                    fuelcost += i;
                }
            }

            return fuelcost;
        }

        private int Median(IEnumerable<int> input)
        {
            var numberOfItems = input.Count();

            input = input.OrderBy(n => n);

            var midpoint = numberOfItems / 2;

            if(numberOfItems % 2 == 0)
            {
                return (input.ElementAt(midpoint - 1) + input.ElementAt(midpoint)) / 2;
            }
            return input.ElementAt(midpoint);
        }
    }
}