using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoverExplorer;
using RoverExplorer.PlanetRepresentation;

namespace RoverExplorerTest
{
    [TestClass]
    public class RoverTest
    {
        Mock<ITerrainGrid> terrainGrid;

        [TestInitialize]
        public void SetUp()
        {
            terrainGrid = new Mock<ITerrainGrid>();
        }

        [TestMethod]
        public void TestMoveForward()
        {
            var rover = new Rover(terrainGrid.Object, new GridPoint(0, 0), CompassDirection.NORTH);

            var newPosition = rover.MoveForward();

            Assert.IsTrue(newPosition.X == 1 && newPosition.Y == 0);
            Assert.IsTrue(rover.CompassCurrentOrientation == CompassDirection.NORTH);
        }
    }
}
