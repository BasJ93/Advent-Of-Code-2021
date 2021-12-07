using AoC2021.Interfaces;
using AoC2021.Implementations;
using AoC2021.Helpers;
using System.CommandLine;
using System.Diagnostics;
using System.CommandLine.Invocation;

namespace AoC2021
{
    class Program
    {
        // TODO: Add appsettings to provide the directory with input data
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<int>(
                    "--dayToRun",
                    getDefaultValue: () => 0,
                    description: "The day to run"
                ),
            };

            rootCommand.Description = "Advent of Code 2021";

            rootCommand.Handler = CommandHandler.Create<int>((dayToRun) =>
            {
                DateTime date = DateTime.Today;

                if (dayToRun != 0)
                {
                    date = DateTime.Parse($"2021-12-{dayToRun}");
                }

                var factory = new SolutionFactory();
                ISolution solver = factory.GetSolutionClass(date);

                if (solver != null)
                {
                    Console.WriteLine($"Running solver for Day [{date.Day}]");

                    var input = InputReader.ReadFromInputFile(date.Day);

                    Stopwatch stopwatch1 = new Stopwatch();
                    try
                    {
                        stopwatch1.Start();

                        var result1 = solver.Task1(input);

                        stopwatch1.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopwatch1.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine($"Task1: [{result1}] (Time: [{elapsedTime}])");
                    }
                    catch (NotImplementedException)
                    {

                    }
                    catch (Exception ex)
                    {
                        stopwatch1.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopwatch1.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine($"Task1 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
                    }

                    Stopwatch stopwatch2 = new Stopwatch();
                    try
                    {
                        stopwatch2.Start();

                        var result2 = solver.Task2(input);

                        stopwatch2.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopwatch2.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);

                        Console.WriteLine($"Task2: [{result2}] (Time: [{elapsedTime}])");
                    }
                    catch (NotImplementedException)
                    {

                    }
                    catch (Exception ex)
                    {
                        stopwatch2.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopwatch2.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine($"Task2 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
                    }
                }
                else
                {
                    Console.WriteLine("No solver for specified day found");
                }
            });

            return rootCommand.InvokeAsync(args).Result;
        }
    }
}