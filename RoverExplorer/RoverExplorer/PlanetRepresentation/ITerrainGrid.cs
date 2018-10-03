using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverExplorer.PlanetRepresentation
{
    public interface ITerrainGrid
    {
        bool ObstacleExists(GridPoint position);
        
    }
}
