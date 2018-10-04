using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverExplorer.PlanetRepresentation;
using System;
using System.Collections.Generic;

namespace RoverExplorerTest
{
    [TestClass]
    public class TerrainGridTest
    {

        ITerrainGrid _terrainGridInstance;

        [TestMethod]
        public void TestAdvanceNorth()
        {
            var originalPosition = new GridPoint(2, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceNorth(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y + 1);
        }
        [TestMethod]
        public void TestAdvanceSouth()
        {
            var originalPosition = new GridPoint(2, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceSouth(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y - 1);
        }
        [TestMethod]
        public void TestAdvanceEast()
        {
            var originalPosition = new GridPoint(2, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceEast(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X + 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }
        [TestMethod]
        public void TestAdvanceWest()
        {
            var originalPosition = new GridPoint(2, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceWest(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X - 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod]
        public void TestAdvanceNorthWhenAtEdgeOfGrid()
        {
            var originalPosition = new GridPoint(2, 9);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceNorth(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == 0);
        }
        [TestMethod]
        public void TestAdvanceSouthWhenAtEdgeOfGrid()
        {
            var originalPosition = new GridPoint(2, 0);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceSouth(originalPosition);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == 9);
        }
        [TestMethod]
        public void TestAdvanceEastWhenAtEdgeOfGrid()
        {
            var originalPosition = new GridPoint(9, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceEast(originalPosition);

            Assert.IsTrue(newPosition.X == 0);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }
        [TestMethod]
        public void TestAdvanceWestWhenAtEdgeOfGrid()
        {
            var originalPosition = new GridPoint(0, 2);
            _terrainGridInstance = new TerrainGrid(10, 10);

            var newPosition = _terrainGridInstance.AdvanceWest(originalPosition);

            Assert.IsTrue(newPosition.X == 9);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod]
        public void TestObstacleExists()
        {
            var obstacles = new List<GridPoint>();
            int MaxX = new Random().Next(0, 100);
            int MaxY = new Random().Next(0, 100);

            GridPoint obstaclePosition = new GridPoint(new Random().Next(0, MaxX), new Random().Next(0, MaxY));
            obstacles.Add(new GridPoint(obstaclePosition.X, obstaclePosition.Y));

            _terrainGridInstance = new TerrainGrid(MaxX, MaxY, obstacles);

            var obstacleExists = _terrainGridInstance.ObstacleExists(obstaclePosition);

            Assert.IsTrue(obstacleExists);
        }

        [TestMethod]
        public void TestObstacleNOTExists()
        {
            var obstacles = new List<GridPoint>();
            int MaxX = new Random().Next(0, 100);
            int MaxY = new Random().Next(0, 100);

            GridPoint obstaclePosition = new GridPoint(new Random().Next(0, MaxX), new Random().Next(0, MaxY));
            obstacles.Add(new GridPoint(obstaclePosition.X + 1, obstaclePosition.Y));

            _terrainGridInstance = new TerrainGrid(MaxX, MaxY, obstacles);

            var obstacleExists = _terrainGridInstance.ObstacleExists(obstaclePosition);

            Assert.IsFalse(obstacleExists);
        }
    }
}
