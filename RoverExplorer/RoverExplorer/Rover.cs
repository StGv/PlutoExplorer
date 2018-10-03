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
        
        readonly GridPoint _cussrentGridPosition;

        public Rover(ITerrainGrid terrain)
        {
            _planetTerrainGrid = terrain;
            CompassCurrentOrientation = CompassDirection.NORTH;
            _cussrentGridPosition = new GridPoint(0,0);
        }
        public Rover(ITerrainGrid terrain, GridPoint initialPosition, CompassDirection orientation) 
            : this(terrain)
        {
            CompassCurrentOrientation = orientation;
            _cussrentGridPosition = initialPosition;
        }

        public CompassDirection CompassCurrentOrientation { get; private set; }

        public GridPoint MoveForward()
        {
            switch (CompassCurrentOrientation)
            {
                case CompassDirection.NORTH:
                    return new GridPoint(_cussrentGridPosition.X + 1, _cussrentGridPosition.Y);
                default:
                    return _cussrentGridPosition;
            }
            
        }
    }
}
