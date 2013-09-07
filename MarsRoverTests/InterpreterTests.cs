using System;
using System.Collections.Generic;
using System.IO;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void FinalTest()
        {
            const string input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
            const string output = @"1 3 N
5 1 E
";

            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);

            Assert.AreEqual(output, writer.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BoundsTest()
        {
            const string input = @"1 1
0 0 N
MM
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FirstLineMalformedTest()
        {
            const string input = @"First Line Malformed
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RoverPositionMalformed()
        {
            const string input = @"2 2
A 0 N
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverMissingDirection()
        {
            const string input = @"2 2
1 2 X
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RoverInstructionsBroken()
        {
            const string input = @"2 2
0 0 N
A
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);
        }


        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void SecondInstructionIncorrect()
        {
            const string input = @"2 2
0 0 N
MA
";
            var reader = new StringReader(input);
            var writer = new StringWriter();
            var i = new Interpreter();
            i.Run(reader, writer);
        }


    }
}
