using RoverExplorer.PlanetRepresentation;
using System;

namespace RoverExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            int MaxX = new Random().Next(0, 100);
            int MaxY = new Random().Next(0, 100);

            var rover = new Rover(new TerrainGrid(MaxX, MaxY));

            string input = Console.ReadLine();
            foreach(char letter in input)
            {
                switch (letter)
                {
                    case (char)Directions.Forward:
                        rover.MoveForward();
                        Console.WriteLine($"Moving to {rover.CurrentGridPosition.X}, {rover.CurrentGridPosition.Y} facing {rover.CompassCurrentOrientation}");
                        break;
                    case (char)Directions.Backward:
                        rover.MoveBackward();
                        Console.WriteLine($"Moving to {rover.CurrentGridPosition.X}, {rover.CurrentGridPosition.Y} facing {rover.CompassCurrentOrientation}");
                        break;
                    case (char)Directions.Left:
                        rover.TurnLeft();
                        Console.WriteLine($"Moving to {rover.CurrentGridPosition.X}, {rover.CurrentGridPosition.Y} facing {rover.CompassCurrentOrientation}");
                        break;
                    case (char)Directions.Right:
                        rover.TurnRight();
                        Console.WriteLine($"Moving to {rover.CurrentGridPosition.X}, {rover.CurrentGridPosition.Y} facing {rover.CompassCurrentOrientation}");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
