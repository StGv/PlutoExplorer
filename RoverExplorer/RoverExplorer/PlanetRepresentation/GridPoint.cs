using System;

namespace RoverExplorer.PlanetRepresentation
{
    public class GridPoint
    {
        public GridPoint(int X, int Y)
        {
            if (X < 0 || Y < 0)
                throw new ArgumentException("X and Y can be only positive numbers");

            this.X = X;
            this.Y = Y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

    }
}
