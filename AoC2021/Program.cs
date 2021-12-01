using AoC2021.Interfaces;
using AoC2021.Implementations;
using AoC2021.Helpers;

namespace AoC2021
{
    class Program
    {
        // TODO: Add appsettings to provide the directory with input data
        static void Main(string[] args)
        {
            DateTime date = DateTime.Today;

            // TODO: Implement the option of running a specific day using a parameter.

            var factory = new SolutionFactory();
            ISolution solver = factory.GetSolutionClass(date);

            var inputReader = new InputReader();

            if (solver != null)
            {
                Console.WriteLine($"Running solver for Day [{date.Day}]");

                var input = inputReader.ReadFromInputFile(date.Day);

                try
                {
                    var result1 = solver.Task1(input);
                    Console.WriteLine($"Task1: [{result1}]");
                }
                catch (NotImplementedException)
                {

                }

                try
                {
                    var result2 = solver.Task2(input);
                    Console.WriteLine($"Task2: [{result2}]");
                }
                catch (NotImplementedException)
                {

                }
            }
            else
            {
                Console.WriteLine("No solver for specified day found");
            }
        }
    }
}