
namespace RoverExplorer.PlanetRepresentation
{
    public interface ITerrainGrid
    {
        bool ObstacleExists(GridPoint position);
        GridPoint AdvanceNorth(GridPoint currentPosition);
        GridPoint AdvanceSouth(GridPoint currentPosition);
        GridPoint AdvanceEast(GridPoint currentPosition);
        GridPoint AdvanceWest(GridPoint currentPosition);
    }
}
