using RoverExplorer.PlanetRepresentation;
using System;

namespace RoverExplorer
{
    public enum Directions
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
            CurrentGridPosition = new GridPoint(0,0);
        }
        public Rover(ITerrainGrid terrain, GridPoint initialPosition, CompassDirection orientation) 
            : this(terrain)
        {
            CompassCurrentOrientation = orientation;
            CurrentGridPosition = initialPosition;
        }

        public CompassDirection CompassCurrentOrientation { get; private set; }
        public GridPoint CurrentGridPosition { get; private set; }

        public void MoveForward()
        {
            GridPoint newPosition; 
            switch (CompassCurrentOrientation)
            {
                case CompassDirection.NORTH:
                    newPosition = _planetTerrainGrid.AdvanceNorth(CurrentGridPosition);
                    break;
                case CompassDirection.SOUTH:
                    newPosition = _planetTerrainGrid.AdvanceSouth(CurrentGridPosition);
                    break;
                case CompassDirection.EAST:
                    newPosition = _planetTerrainGrid.AdvanceEast(CurrentGridPosition);
                    break;
                case CompassDirection.WEST:
                    newPosition = _planetTerrainGrid.AdvanceWest(CurrentGridPosition);
                    break;
                default:
                    newPosition = CurrentGridPosition;
                    break;
            }

            if (_planetTerrainGrid.ObstacleExists(newPosition))
                return;

            CurrentGridPosition = newPosition;
        }

        public void MoveBackward()
        {
            GridPoint newPosition;
            switch (CompassCurrentOrientation)
            {
                case CompassDirection.NORTH:
                    newPosition = _planetTerrainGrid.AdvanceSouth(CurrentGridPosition);
                    break;
                case CompassDirection.SOUTH:
                    newPosition = _planetTerrainGrid.AdvanceNorth(CurrentGridPosition);
                    break;
                case CompassDirection.EAST:
                    newPosition = _planetTerrainGrid.AdvanceWest(CurrentGridPosition);
                    break;
                case CompassDirection.WEST:
                    newPosition = _planetTerrainGrid.AdvanceEast(CurrentGridPosition);
                    break;
                default:
                    newPosition = CurrentGridPosition;
                    break;
            }

            if (_planetTerrainGrid.ObstacleExists(newPosition))
                return;

            CurrentGridPosition = newPosition;
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
