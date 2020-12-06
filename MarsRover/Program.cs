using System;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var inputLines = System.IO.File.ReadAllLines(@"../../../input.txt");
            var upperCoordinates = inputLines[0].Split(' ');
            var upperRightX = int.Parse(upperCoordinates[0]);
            var upperRightY = int.Parse(upperCoordinates[1]);
            var plateau = new Plateau(upperRightX, upperRightY);

            for (var i = 1; i < inputLines.Length; i += 2)
            {
                var roverInformation = inputLines[i].Split(' ');
                var roverX = int.Parse(roverInformation[0]);
                var roverY = int.Parse(roverInformation[1]);
                var direction = (Direction) Enum.Parse(typeof(Direction), roverInformation[2]);

                if (upperRightX < roverX || Plateau.LowerLeftX > roverX ||
                    upperRightY < roverY || Plateau.LowerLeftY > roverY)
                    throw new Exception("Rover's coordinates are outside the boundary values in input data.");

                var rover = new Rover(roverX, roverY, direction);

                var nasaDirectionInstructions = inputLines[i + 1];

                rover.ApplyInstructions(nasaDirectionInstructions, plateau);

                Console.WriteLine(rover.ToString());
            }
        }
    }
}