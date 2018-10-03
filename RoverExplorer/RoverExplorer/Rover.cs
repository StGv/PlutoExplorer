using RoverExplorer.PlanetRepresentation;
using System;

namespace RoverExplorer
{
    public enum Orientation
    {
        Forward = 'F',
        Backward = 'B',
        Left = 'L',
        Right = 'R'
    }


    public class Rover
    {
        ITerrainGrid _planetTerrainGrid;

        public Rover(ITerrainGrid terrain)
        {
            _planetTerrainGrid = terrain;
            CompassCurrentOrientation = CompassDirection.NORTH;
            CussrentGridPosition = new GridPoint(0,0);
        }
        public Rover(ITerrainGrid terrain, GridPoint initialPosition, CompassDirection orientation) 
            : this(terrain)
        {
            CompassCurrentOrientation = orientation;
            CussrentGridPosition = initialPosition;
        }

        public CompassDirection CompassCurrentOrientation { get; private set; }
        public GridPoint CussrentGridPosition { get; private set; }


        public GridPoint MoveForward()
        {
            var newPosition = new GridPoint(CussrentGridPosition.X, CussrentGridPosition.Y + 1);
            return CussrentGridPosition = newPosition;
        }

        public GridPoint MoveBackward()
        {
            var newPosition = new GridPoint(CussrentGridPosition.X, CussrentGridPosition.Y - 1);
            return CussrentGridPosition = newPosition;

        }
    }
}
