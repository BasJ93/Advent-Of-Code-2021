using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public class Day6 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            List<int> listOfFish = input.First().Split(',').Select(s => Convert.ToInt32(s)).ToList();

            return SimulateFish(listOfFish, 80);
        }

        public long Task2(IEnumerable<string> input)
        {
            List<int> listOfFish = input.First().Split(',').Select(s => Convert.ToInt32(s)).ToList();

            return SimulateFish(listOfFish, 256);
        }

        private long SimulateFish(List<int> initialPopulation, int numberOfDays)
        {
            Dictionary<int, long> fish = new Dictionary<int, long>();

            for (int i = 0; i < 9; i++)
            {
                fish.Add(i, 0);
            }

            foreach(var exisitingFish in initialPopulation)
            {
                fish[exisitingFish]++;
            }

            for (int i = 0; i < numberOfDays; i++)
            {
                var newFish = fish[0];

                fish[0] = fish[1];
                fish[1] = fish[2];
                fish[2] = fish[3];
                fish[3] = fish[4];
                fish[4] = fish[5];
                fish[5] = fish[6];
                fish[6] = fish[7] + newFish;
                fish[7] = fish[8];
                fish[8] = newFish;
            }

            long numberOfFish = 0;

            foreach(var group in fish)
            {
                numberOfFish += group.Value;
            }

            return numberOfFish;
        }
    }
}