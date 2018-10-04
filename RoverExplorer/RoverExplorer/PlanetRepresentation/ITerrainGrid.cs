
namespace RoverExplorer.PlanetRepresentation
{
    public interface ITerrainGrid
    {
        bool ObstacleExists(GridPoint position);
 
        GridPoint GetNextGridPoint(GridPoint fromPosition, CompassDirection direction);

        //GridPoint AdvanceNorth(GridPoint currentPosition);
        //GridPoint AdvanceSouth(GridPoint currentPosition);
        //GridPoint AdvanceEast(GridPoint currentPosition);
        //GridPoint AdvanceWest(GridPoint currentPosition);
    }
}
