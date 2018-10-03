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


        public void MoveForward()
        {
            CussrentGridPosition = new GridPoint(CussrentGridPosition.X, CussrentGridPosition.Y + 1);
        }

        public void  MoveBackward()
        {
            CussrentGridPosition = new GridPoint(CussrentGridPosition.X, CussrentGridPosition.Y - 1);
        }

        public void TurnLeft()
        {
            switch (CompassCurrentOrientation)
            {
                case CompassDirection.NORTH:
                    CompassCurrentOrientation = CompassDirection.WEST;
                    break;
                case CompassDirection.SOUTH:
                    CompassCurrentOrientation = CompassDirection.EAST;
                    break;
                case CompassDirection.EAST:
                    CompassCurrentOrientation = CompassDirection.NORTH;
                    break;
                case CompassDirection.WEST:
                    CompassCurrentOrientation = CompassDirection.SOUTH;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (CompassCurrentOrientation)
            {
                case CompassDirection.NORTH:
                    CompassCurrentOrientation = CompassDirection.EAST;
                    break;
                case CompassDirection.SOUTH:
                    CompassCurrentOrientation = CompassDirection.WEST;
                    break;
                case CompassDirection.EAST:
                    CompassCurrentOrientation = CompassDirection.SOUTH;
                    break;
                case CompassDirection.WEST:
                    CompassCurrentOrientation = CompassDirection.NORTH;
                    break;
            }
        }
    }
}
