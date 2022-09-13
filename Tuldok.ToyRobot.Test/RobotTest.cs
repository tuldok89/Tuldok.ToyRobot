using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuldok.ToyRobot.Lib;

namespace Tuldok.ToyRobot.Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void CorrectPlace()
        {
            var robot = new Robot();
            robot.Place(4, 4, Direction.North); // Should not throw an exception here
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OutOfBoundsPlace()
        {
            var robot = new Robot();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Place(5, 0, Direction.North);
            });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Place(0, 5, Direction.North);
            });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Place(-1, 0, Direction.North);
            });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Place(0, -1, Direction.North);
            });
        }

        [TestMethod]
        public void NotPlaced()
        {
            var robot = new Robot();
            Assert.ThrowsException<NotPlacedException>(() =>
            {
                robot.TurnLeft();
            });
            Assert.ThrowsException<NotPlacedException>(() =>
            {
                robot.TurnRight();
            });
            Assert.ThrowsException<NotPlacedException>(() =>
            {
                robot.Move();
            });
        }

        [TestMethod]
        public void MoveWest()
        {
            var robot = new Robot();
            robot.Place(1, 0, Direction.West);
            robot.Move();

            Assert.AreEqual(0, robot.X);
        }

        [TestMethod]
        public void MoveEast()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.East);
            robot.Move();

            Assert.AreEqual(1, robot.X);
        }

        [TestMethod]
        public void MoveNorth()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            robot.Move();

            Assert.AreEqual(1, robot.Y);
        }

        [TestMethod]
        public void MoveSouth()
        {
            var robot = new Robot();
            robot.Place(0, 1, Direction.South);
            robot.Move();
            
            Assert.AreEqual(0, robot.Y);
        }

        [TestMethod]
        public void TurnRight()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.West);
            robot.TurnRight();

            Assert.AreEqual(Direction.North, robot.Direction);
        }

        [TestMethod]
        public void TurnLeft()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            robot.TurnLeft();

            Assert.AreEqual(Direction.West, robot.Direction);
        }

        [TestMethod]
        public void InvalidMoveEast()
        {
            var robot = new Robot();
            robot.Place(4, 0, Direction.East);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Move();
            });
            Assert.AreEqual(4, robot.X);
        }

        [TestMethod]
        public void InvalidMoveWest()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.West);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Move();
            });
            
            Assert.AreEqual(0, robot.X);
        }

        [TestMethod]
        public void InvalidMoveNorth()
        {
            var robot = new Robot();
            robot.Place(0, 4, Direction.North);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Move();
            });

            Assert.AreEqual(4, robot.Y);
        }

        [TestMethod]
        public void InvalidMoveSouth()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.South);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                robot.Move();
            });
        }
    }
}
