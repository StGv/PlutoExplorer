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

            rover.MoveForward();
            var newPosition = rover.CussrentGridPosition;

            Assert.AreNotEqual(newPosition, originalPOsition);
            Assert.IsTrue(newPosition.X == originalPOsition.X && newPosition.Y == originalPOsition.Y + 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveBackward()
        {
            GridPoint originalPOsition = new GridPoint(0, 0);
            CompassDirection originalRoverDirection = CompassDirection.NORTH;
            var rover = new Rover(terrainGrid.Object, originalPOsition, originalRoverDirection);

            rover.MoveBackward();
            var newPosition = rover.CussrentGridPosition;

            Assert.AreNotEqual(newPosition, originalPOsition);
            Assert.IsTrue(newPosition.X == originalPOsition.X && newPosition.Y == originalPOsition.Y - 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }


        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.WEST)]
        [DataRow(CompassDirection.WEST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.EAST)]
        public void TestTurnRight(CompassDirection originalRoverDirection, CompassDirection expectedRoverDirection)
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.TurnRight();

            Assert.IsTrue(rover.CompassCurrentOrientation == expectedRoverDirection);
            Assert.IsTrue(rover.CussrentGridPosition == originalPosition);
        }

        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.EAST)]
        [DataRow(CompassDirection.WEST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.WEST)]
        public void TestTurnLeft(CompassDirection originalRoverDirection, CompassDirection expectedRoverDirection)
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.TurnLeft();

            Assert.IsTrue(rover.CompassCurrentOrientation == expectedRoverDirection);
            Assert.IsTrue(rover.CussrentGridPosition == originalPosition);
        }
    }
}
