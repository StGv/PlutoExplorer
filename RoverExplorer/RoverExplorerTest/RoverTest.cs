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
            GridPoint originalPOsition = new GridPoint(0, 0);
            CompassDirection originalRoverDirection = CompassDirection.NORTH;
            var rover = new Rover(terrainGrid.Object, originalPOsition, originalRoverDirection);

            var newPosition = rover.MoveForward();

            Assert.IsTrue(newPosition.X == originalPOsition.X && newPosition.Y == originalPOsition.Y + 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveBackward()
        {
            GridPoint originalPOsition = new GridPoint(0, 0);
            CompassDirection originalRoverDirection = CompassDirection.NORTH;
            var rover = new Rover(terrainGrid.Object, originalPOsition, originalRoverDirection);

            var newPosition = rover.MoveBackward();

            Assert.IsTrue(newPosition.X == originalPOsition.X && newPosition.Y == originalPOsition.Y - 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }
    }
}
