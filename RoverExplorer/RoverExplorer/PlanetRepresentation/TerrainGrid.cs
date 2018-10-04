
using System.Linq;
using System.Collections.Generic;

namespace RoverExplorer.PlanetRepresentation
{
    public enum CompassDirection
    {
        NORTH = 'N',
        EAST = 'E',
        SOUTH = 'S',
        WEST = 'W',
    }

    public class TerrainGrid : ITerrainGrid
    {
        public TerrainGrid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxX;
        }

        public TerrainGrid(int maxX, int maxY, List<GridPoint> obstacles) : this(maxX, maxY)
        {
            Obstacles = obstacles;
        }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public List<GridPoint> Obstacles { get; private set; }

        public bool ObstacleExists(GridPoint position)
        {
            return Obstacles.Any(obstacle => obstacle.X == position.X && obstacle.Y == position.Y);
        }

        public GridPoint GetNextGridPoint(GridPoint fromPosition, CompassDirection direction)
        {
            switch (direction)
            {
                case CompassDirection.NORTH:
                    return AdvanceNorth(fromPosition);
                case CompassDirection.SOUTH:
                    return AdvanceSouth(fromPosition);
                case CompassDirection.EAST:
                    return AdvanceEast(fromPosition);
                case CompassDirection.WEST:
                    return AdvanceWest(fromPosition);
                default:
                    return new GridPoint(fromPosition.X, fromPosition.Y);
            }
        }

        public GridPoint AdvanceNorth(GridPoint currentPosition)
        {
            return new GridPoint(currentPosition.X, currentPosition.Y + 1);
        }

        public GridPoint AdvanceSouth(GridPoint currentPosition)
        {
            return new GridPoint(currentPosition.X, currentPosition.Y - 1);
        }

        public GridPoint AdvanceEast(GridPoint currentPosition)
        {
            return new GridPoint(currentPosition.X + 1, currentPosition.Y);
        }
        public GridPoint AdvanceWest(GridPoint currentPosition)
        {
            return new GridPoint(currentPosition.X - 1, currentPosition.Y);
        }
    }
}
