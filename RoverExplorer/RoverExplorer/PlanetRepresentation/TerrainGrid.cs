
using System.Linq;
using System;
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

        //public (int X, int Y) GetSize()
        //{
        //    return (X: MaxX, Y MaxY);
        //}

        public bool ObstacleExists(GridPoint position)
        {
            return Obstacles.Any(obstacle => obstacle.X == position.X && obstacle.Y == position.Y);
        }
    }
}
