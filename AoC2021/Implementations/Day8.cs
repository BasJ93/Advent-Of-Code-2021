using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public class Day8 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            // We only care about the output section, i.e. after the '|'
            var outputSegments = input.Select(i => i.Split('|').Last()).Select(i => i.Split(' '));

            long countOfUniqueOutputs = 0;

            foreach (var segment in outputSegments)
            {
                foreach (var display in segment)
                {
                    // We only care about '1', '7', '4' and '8'
                    if (display.Length == 2 || display.Length == 3 || display.Length == 4 || display.Length == 7)
                    {
                        countOfUniqueOutputs++;
                    }
                }
            }

            return countOfUniqueOutputs;
        }

        public long Task2(IEnumerable<string> input)
        {
            foreach (var line in input)
            {

                var inputSegments = line.Split('|').First().Split(' ');
                var outputSegments = line.Split('|').Last().Split(' ');

                Dictionary<int, string> chars = new Dictionary<int, string>();

                // Search for all 2 lenght strings and add those on key '1'
                var ones = inputSegments.Where(i => i.Length == 2);
                if (ones.Count() > 0)
                {
                    chars.Add(1, ones.First());
                }

                // Same for 3 lenght on key '7'
                var sevens = inputSegments.Where(i => i.Length == 3);
                if (sevens.Count() > 0)
                {
                    chars.Add(7, sevens.First());
                }

                // And 4 lenght on key '4'
                var fours = inputSegments.Where(i => i.Length == 4);
                if (fours.Count() > 0)
                {
                    chars.Add(4, fours.First());
                }

                // And 7 lenght on key '8'
                var eights = inputSegments.Where(i => i.Length == 7);
                if (eights.Count() > 0)
                {
                    chars.Add(8, eights.First());
                }

                // Then attempt to match '1' and '7' to find the top and right most segments


                // Using that data and '4' find the middle and top-left segments
    
            }
            throw new NotImplementedException();
        }
    }
}