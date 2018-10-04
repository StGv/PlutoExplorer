
namespace RoverExplorer.PlanetRepresentation
{
    public static class Compass
    {
        public static CompassDirection GetOppositeDirection(CompassDirection direction)
        {
            switch (direction)
            {
                case CompassDirection.NORTH:
                    return CompassDirection.SOUTH;
                case CompassDirection.SOUTH:
                    return CompassDirection.NORTH;
                case CompassDirection.EAST:
                    return CompassDirection.WEST;
                case CompassDirection.WEST:
                    return CompassDirection.EAST;
                default:
                    return direction;
            }
        }
    }
}
