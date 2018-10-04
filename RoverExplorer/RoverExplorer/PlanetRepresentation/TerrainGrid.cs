
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

        public TerrainGrid(int maxX, int maxY, List<GridPoint> obstacles = null)
        {
            Obstacles = obstacles ?? new List<GridPoint>();
            MaxX = maxX;
            MaxY = maxX;
        }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public List<GridPoint> Obstacles { get; private set; }

        public bool ObstacleExists(GridPoint position)
        {
            return Obstacles.Any(obstacle => obstacle.X == position.X && obstacle.Y == position.Y);
        }

        public GridPoint AdvanceNorth(GridPoint fromPosition)
        {
            return (fromPosition.Y + 1 == MaxY)
                ? new GridPoint(fromPosition.X, 0)
                : new GridPoint(fromPosition.X, fromPosition.Y + 1);
        }

        public GridPoint AdvanceSouth(GridPoint fromPosition)
        {
            return (fromPosition.Y == 0)
                ? new GridPoint(fromPosition.X, MaxY - 1)
                : new GridPoint(fromPosition.X, fromPosition.Y - 1);
        }

        public GridPoint AdvanceEast(GridPoint fromPosition)
        {
            return (fromPosition.X + 1 == MaxX)
                ? new GridPoint( 0, fromPosition.Y)
                : new GridPoint(fromPosition.X + 1, fromPosition.Y);
        }
        public GridPoint AdvanceWest(GridPoint fromPosition)
        {
            return (fromPosition.X == 0)
                ? new GridPoint(MaxX - 1, fromPosition.Y)
                : new GridPoint(fromPosition.X - 1, fromPosition.Y);
        }
    }
}
