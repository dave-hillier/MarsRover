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
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.N };
            rover.RotateLeft();
            Assert.AreEqual(Interpreter.Direction.W, rover.Direction);
        }

        [TestMethod]
        public void RotateLeftFromWest()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.W };
            rover.RotateLeft();
            Assert.AreEqual(Interpreter.Direction.S, rover.Direction);
        }

        [TestMethod]
        public void RotateLeftFromSouth()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.S };
            rover.RotateLeft();
            Assert.AreEqual(Interpreter.Direction.E, rover.Direction);
        }

        [TestMethod]
        public void RotateLeftFromEast()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.E };
            rover.RotateLeft();
            Assert.AreEqual(Interpreter.Direction.N, rover.Direction);
        }

        [TestMethod]
        public void RotateRightFromNorth()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.N };
            rover.RotateRight();
            Assert.AreEqual(Interpreter.Direction.E, rover.Direction);
        }

        [TestMethod]
        public void RotateRightFromWest()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.W };
            rover.RotateRight();
            Assert.AreEqual(Interpreter.Direction.N, rover.Direction);
        }

        [TestMethod]
        public void RotateRightFromSouth()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.S };
            rover.RotateRight();
            Assert.AreEqual(Interpreter.Direction.W, rover.Direction);
        }

        [TestMethod]
        public void RotateRightFromEast()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.E };
            rover.RotateRight();
            Assert.AreEqual(Interpreter.Direction.S, rover.Direction);
        }

        [TestMethod]
        public void MoveNorth()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.N };
            rover.Move();
            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
        }

        [TestMethod]
        public void MoveWest()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.W };
            rover.Move();
            Assert.AreEqual(-1, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
        }

        [TestMethod]
        public void MoveEast()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.E };
            rover.Move();
            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(0, rover.Position.Y);
        }

        [TestMethod]
        public void MoveSouth()
        {
            var rover = new Interpreter.Rover { Direction = Interpreter.Direction.S };
            rover.Move();
            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(-1, rover.Position.Y);
        }
    }
}