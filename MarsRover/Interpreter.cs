using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRover
{
    public class Interpreter
    {
        private readonly Commands _commands = new Commands();

        public void Run(TextReader input, TextWriter output)
        {
            _commands.Bounds = GetBounds(input.ReadLine());
            string line;
            while ((line = input.ReadLine()) != null)
            {
                var rover = Rover.Parse(line);
                line = input.ReadLine();
                if (line == null)
                    break;
                var instructions = line.ToCharArray();
                ProcessInstructions(ref rover, instructions);
                output.WriteLine(rover);
            }
        }

        private Vector2 GetBounds(string line)
        {
            var @params = line.Split(' ');
            return new Vector2(Int32.Parse(@params[0]), Int32.Parse(@params[1]));
        }

        internal void ProcessInstructions(ref Rover rover, IEnumerable<char> instructions)
        {
            foreach (var instruction in instructions)
            {
                var cmd = _commands.Get(instruction);
                rover = cmd(rover);
            }
        }

        private class Commands
        {
            public Vector2 Bounds { private get; set; }
            private readonly Dictionary<char, Func<Rover, Rover>> _commandMap;
            public Commands()
            {
                _commandMap = new Dictionary<char, Func<Rover, Rover>> {
                    { 'M', Move },
                    { 'L', r => { r.RotateLeft(); return r; } },
                    { 'R', r => { r.RotateRight(); return r; } },
                };
            }

            public Func<Rover, Rover> Get(char c)
            {
                return _commandMap[c];
            }

            private Rover Move(Rover rover)
            {
                rover.Move();
                if (rover.Position.X > Bounds.X || rover.Position.X < 0 || rover.Position.Y > Bounds.Y || rover.Position.Y < 0)
                    throw new InvalidOperationException("Out of bounds");
                return rover;
            }
        }

        internal enum Direction { N, E, S, W }

        internal struct Rover
        {
            private static readonly Vector2[] Directions = new[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };
            public Vector2 Position;
            public Direction Direction;

            public void RotateLeft()
            {
                var numDirections = Enum.GetNames(typeof(Direction)).Length;
                Direction = (Direction)(((int)Direction - 1 + numDirections) % numDirections);
            }

            public void RotateRight()
            {
                var numDirections = Enum.GetNames(typeof(Direction)).Length;
                Direction = (Direction)(((int)Direction + 1) % numDirections);
            }

            public void Move()
            {
                Position += Directions[(int)Direction];
            }

            public static Rover Parse(string line)
            {
                var @params = line.Split(' ');
                var r = new Rover
                {
                    Position = new Vector2 { X = Int32.Parse(@params[0]), Y = Int32.Parse(@params[1]) },
                    Direction = (Direction)Enum.Parse(typeof(Direction), @params[2], ignoreCase: true)
                };
                return r;
            }

            public override string ToString()
            {
                return String.Format("{0} {1} {2}", Position.X, Position.Y, Direction);
            }
        }
    }
}