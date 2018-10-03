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
        CompassDirection _currentOrientation;

        readonly GridPoint _cussrentGridPosition;

        public Rover(ITerrainGrid terrain)
        {
            _currentOrientation = CompassDirection.NORTH;
            _cussrentGridPosition = new GridPoint(0,0);
        }

    }
}
