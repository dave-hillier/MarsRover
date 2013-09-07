using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RotateLeftFromNorth()
        {
            var rover = new Rover { Orientation = Rover.Direction.N };
            rover.RotateLeft();
            Assert.AreEqual(Rover.Direction.W, rover.Orientation);
        }

        [TestMethod]
        public void RotateLeftFromWest()
        {
            var rover = new Rover { Orientation = Rover.Direction.W };
            rover.RotateLeft();
            Assert.AreEqual(Rover.Direction.S, rover.Orientation);
        }

        [TestMethod]
        public void RotateLeftFromSouth()
        {
            var rover = new Rover { Orientation = Rover.Direction.S };
            rover.RotateLeft();
            Assert.AreEqual(Rover.Direction.E, rover.Orientation);
        }

        [TestMethod]
        public void RotateLeftFromEast()
        {
            var rover = new Rover { Orientation = Rover.Direction.E };
            rover.RotateLeft();
            Assert.AreEqual(Rover.Direction.N, rover.Orientation);
        }

        [TestMethod]
        public void RotateRightFromNorth()
        {
            var rover = new Rover { Orientation = Rover.Direction.N };
            rover.RotateRight();
            Assert.AreEqual(Rover.Direction.E, rover.Orientation);
        }

        [TestMethod]
        public void RotateRightFromWest()
        {
            var rover = new Rover { Orientation = Rover.Direction.W };
            rover.RotateRight();
            Assert.AreEqual(Rover.Direction.N, rover.Orientation);
        }

        [TestMethod]
        public void RotateRightFromSouth()
        {
            var rover = new Rover { Orientation = Rover.Direction.S };
            rover.RotateRight();
            Assert.AreEqual(Rover.Direction.W, rover.Orientation);
        }

        [TestMethod]
        public void RotateRightFromEast()
        {
            var rover = new Rover { Orientation = Rover.Direction.E };
            rover.RotateRight();
            Assert.AreEqual(Rover.Direction.S, rover.Orientation);
        }

        [TestMethod]
        public void MoveNorth()
        {
            var rover = new Rover { Orientation = Rover.Direction.N };
            rover.Move();
            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
        }

        [TestMethod]
        public void MoveWest()
        {
            var rover = new Rover { Orientation = Rover.Direction.W };
            rover.Move();
            Assert.AreEqual(-1, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
        }

        [TestMethod]
        public void MoveEast()
        {
            var rover = new Rover { Orientation = Rover.Direction.E };
            rover.Move();
            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
        }

        [TestMethod]
        public void MoveSouth()
        {
            var rover = new Rover { Orientation = Rover.Direction.S };
            rover.Move();
            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(-1, rover.Position.Y);
        }
    }
}