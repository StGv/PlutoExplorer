

namespace RoverExplorer.PlanetRepresentation
{
    public class GridPoint
    {
        public GridPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

    }
}
