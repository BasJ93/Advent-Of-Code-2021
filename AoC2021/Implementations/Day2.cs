using AoC2021.Helpers;
using AoC2021.Interfaces;

namespace AoC2021.Implementations
{
    /// <summary>
    /// Class specific to the Horizontal and Depth positioning of the submarine.
    /// </summary>
    class Position2D
    {
        public int Horizontal { get; set; }
        public int Depth { get; set; }
    }

    class Position3D : Position2D
    {
        public int Aim { get; set; }
    }

    class Command
    {
        public string Direction { get; set; }

        public int Value { get; set; }
    }

    static class Day2Helpers
    {
        public static IEnumerable<Command> ParseToCommands(this IEnumerable<string> input)
        {
            return input.Select(i => new Command { Direction = i.Split(" ")[0], Value = Convert.ToInt32(i.Split(" ")[1]) });
        }
    }

    public class Day2 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            var commands = input.ParseToCommands();
            var position = new Position2D();

            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case "forward":
                        // Horizontal +
                        position.Horizontal += command.Value;
                        break;
                    case "up":
                        // Depth -
                        position.Depth -= command.Value;
                        break;
                    case "down":
                        // Depth +
                        position.Depth += command.Value;
                        break;
                }
            }

            return position.Horizontal * position.Depth;
        }

        public long Task2(IEnumerable<string> input)
        {
            var commands = input.ParseToCommands();
            var position = new Position3D();

            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case "forward":
                        // Horizontal + X
                        position.Horizontal += command.Value;
                        // Depth + Aim 8 X
                        position.Depth += position.Aim * command.Value;
                        break;
                    case "up":
                        // Aim -
                        position.Aim -= command.Value;
                        break;
                    case "down":
                        // Aim +
                        position.Aim += command.Value;
                        break;
                }
            }

            return position.Horizontal * position.Depth;
        }
    }
}