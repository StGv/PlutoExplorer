using System;
using System.Collections.Generic;
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
        public void TestMoveForwardWhenFacingNorthShouldIncreaseY()
        {
            GridPoint originalPosition = new GridPoint(0, 0);
            CompassDirection originalRoverDirection = CompassDirection.NORTH;
            terrainGrid.Setup(x => x.AdvanceNorth(originalPosition)).Returns(new GridPoint(0, 1));
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveForward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y + 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingEastShouldIncreaseX()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRoverDirection = CompassDirection.EAST;
            terrainGrid.Setup(x => x.AdvanceEast(originalPosition)).Returns(new GridPoint(3, 2));
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveForward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == originalPosition.X + 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingSouthShouldDecreaseY()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRoverDirection = CompassDirection.SOUTH;
            terrainGrid.Setup(x => x.AdvanceSouth(originalPosition)).Returns(new GridPoint(2, 1));
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveForward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y - 1);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingWestShouldDecreaseX()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRoverDirection = CompassDirection.WEST;
            terrainGrid.Setup(x => x.AdvanceWest(originalPosition)).Returns(new GridPoint(1, 2));
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveForward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == originalPosition.X - 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveBackwardWhenFacingNorthShouldDecreaseY()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            GridPoint expectedPosition = new GridPoint(2, 1);
            var originalRoverDirection = CompassDirection.NORTH;
            terrainGrid.Setup(x => x.AdvanceSouth(originalPosition)).Returns(expectedPosition);
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveBackward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == expectedPosition.X);
            Assert.IsTrue(newPosition.Y == expectedPosition.Y);
            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
        }

        [TestMethod]
        public void TestMoveBackwardWhenFacingSouthShouldIncreaseY()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            GridPoint expectedPosition = new GridPoint(2, 3);
            var originalRoverDirection = CompassDirection.SOUTH;
            terrainGrid.Setup(x => x.AdvanceNorth(originalPosition)).Returns(expectedPosition);
            var rover = new Rover(terrainGrid.Object, originalPosition, originalRoverDirection);

            rover.MoveBackward();
            var newPosition = rover.CurrentGridPosition;

            Assert.IsTrue(newPosition.X == expectedPosition.X);
            Assert.IsTrue(newPosition.Y == expectedPosition.Y);
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
            Assert.IsTrue(rover.CurrentGridPosition == originalPosition);
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
            Assert.IsTrue(rover.CurrentGridPosition == originalPosition);
        }

        [TestMethod]
        public void TestMoveForwardWhenObstacleExists()
        {
            var obstacles = new List<GridPoint>();
            GridPoint originalPosition = new GridPoint(2, 2);
            GridPoint expectedPosition = new GridPoint(2, 3);

            obstacles.Add(expectedPosition);
            var originalRoverDirection = CompassDirection.NORTH;
            terrainGrid.Setup(x => x.AdvanceNorth(originalPosition)).Returns(expectedPosition);

            var rover = new Rover(new TerrainGrid(10, 10, obstacles), originalPosition, originalRoverDirection);

            rover.MoveForward();

            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
            Assert.IsTrue(rover.CurrentGridPosition == originalPosition);
        }

        [TestMethod]
        public void TestMoveBackwardWhenObstacleExists()
        {
            var obstacles = new List<GridPoint>();
            GridPoint originalPosition = new GridPoint(2, 2);
            GridPoint expectedPosition = new GridPoint(2, 1);

            obstacles.Add(expectedPosition);
            var originalRoverDirection = CompassDirection.NORTH;
            terrainGrid.Setup(x => x.AdvanceSouth(originalPosition)).Returns(expectedPosition);

            var rover = new Rover(new TerrainGrid(10, 10, obstacles), originalPosition, originalRoverDirection);

            rover.MoveBackward();

            Assert.IsTrue(rover.CompassCurrentOrientation == originalRoverDirection);
            Assert.IsTrue(rover.CurrentGridPosition == originalPosition);
        }
    }
}
