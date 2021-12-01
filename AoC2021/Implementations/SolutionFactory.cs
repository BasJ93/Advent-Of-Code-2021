using System.Reflection;
using AoC2021.Interfaces;

namespace AoC2021.Implementations
{
    public class SolutionFactory
    {
        public ISolution GetSolutionClass(DateTime dateTime)
        {
            int day = dateTime.Day;

            Assembly assembly = typeof(ISolution).Assembly;

            ISolution dayClass = (ISolution)assembly.CreateInstance($"AoC2021.Implementations.Day{day}");

            return dayClass;
        }
    }
}