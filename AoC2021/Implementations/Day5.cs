using AoC2021.Helpers;
using AoC2021.Interfaces;
using System.Linq;

namespace AoC2021.Implementations
{
    public class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Line
    {
        private Point2D P1 { get; set; }
        private Point2D P2 { get; set; }

        public bool IsHorizotal => P1.X == P2.X;
        public bool IsVertical => P1.Y == P2.Y;

        public Point2D MaxValues { get; }

        public Line(string input)
        {
            var sections = input.Split("->").SelectMany(s => s.Split(',')).Select(s => Convert.ToInt32(s)).ToArray();

            P1 = new Point2D { X = sections[0], Y = sections[1] };
            P2 = new Point2D { X = sections[2], Y = sections[3] };

            MaxValues = new Point2D { X = P1.X > P2.X ? P1.X : P2.X, Y = P1.Y > P2.Y ? P1.Y : P2.Y };
        }

        public IEnumerable<Point2D> GetPointsInLine()
        {
            var points = new List<Point2D>();

            var stepsX = Math.Abs(P1.X - P2.X);
            var stepsY = Math.Abs(P1.Y - P2.Y);

            if (IsHorizotal)
            {
                int yStart = 0;
                int yEnd = 0;
                if (P1.Y < P2.Y)
                {
                    yStart = P1.Y;
                    yEnd = P2.Y;
                }
                else
                {
                    yStart = P2.Y;
                    yEnd = P1.Y;
                }

                for (int y = yStart; y <= yEnd; y++)
                {
                    points.Add(new Point2D { X = P1.X, Y = y });
                }
            }

            if (IsVertical)
            {
                int xStart = 0;
                int xEnd = 0;
                if (P1.X < P2.X)
                {
                    xStart = P1.X;
                    xEnd = P2.X;
                }
                else
                {
                    xStart = P2.X;
                    xEnd = P1.X;
                }

                for (int x = xStart; x <= xEnd; x++)
                {
                    points.Add(new Point2D { X = x, Y = P1.Y });
                }
            }

            if (!IsVertical && !IsHorizotal)
            {
                // Determine x and y signus and start point
                int xStart = 0;
                int xEnd = 0;
                int yStart = 0;
                int yEnd = 0;

                int ySignus = 1;
                if (P1.X < P2.X)
                {
                    xStart = P1.X;
                    yStart = P1.Y;
                    xEnd = P2.X;
                    yEnd = P2.Y;
                }
                else
                {
                    xStart = P2.X;
                    yStart = P2.Y;
                    xEnd = P1.X;
                    yEnd = P1.Y;
                }

                if(yStart > yEnd)
                {
                    ySignus = -1;
                }

                for (int i = 0; i <= stepsX; i++)
                {
                    points.Add(new Point2D { X = xStart + i, Y = yStart + i * ySignus});
                }
            }

            return points;
        }
    }

    public class Day5 : ISolution
    {
        public long Task1(IEnumerable<string> input)
        {
            int maxX = 0;
            int maxY = 0;
            List<Line> lines = new List<Line>();

            foreach (var line in input)
            {
                var ventLine = new Line(line);
                if (ventLine.IsHorizotal || ventLine.IsVertical)
                {
                    if (ventLine.MaxValues.X > maxX)
                    {
                        maxX = ventLine.MaxValues.X;
                    }
                    if (ventLine.MaxValues.Y > maxY)
                    {
                        maxY = ventLine.MaxValues.Y;
                    }
                    lines.Add(ventLine);
                }
            }

            maxX++;
            maxY++;

            int[,] map = new int[maxX, maxY];

            foreach (var line in lines)
            {
                foreach (var point in line.GetPointsInLine())
                {
                    map[point.X, point.Y] += 1;
                }
            }

            long overlaps = 0;



            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    if (map[i, j] > 1)
                    {
                        overlaps++;
                    }
                }
            }

            return overlaps;
        }

        public long Task2(IEnumerable<string> input)
        {
            int maxX = 0;
            int maxY = 0;
            List<Line> lines = new List<Line>();

            foreach (var line in input)
            {
                var ventLine = new Line(line);
                if (ventLine.MaxValues.X > maxX)
                {
                    maxX = ventLine.MaxValues.X;
                }
                if (ventLine.MaxValues.Y > maxY)
                {
                    maxY = ventLine.MaxValues.Y;
                }
                lines.Add(ventLine);
            }

            maxX++;
            maxY++;

            int[,] map = new int[maxX, maxY];

            foreach (var line in lines)
            {
                foreach (var point in line.GetPointsInLine())
                {
                    map[point.X, point.Y] += 1;
                }
            }

            long overlaps = 0;



            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    if (map[i, j] > 1)
                    {
                        overlaps++;
                    }
                }
            }

            return overlaps;
        }
    }
}