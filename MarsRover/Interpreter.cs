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
                var cmd = _commands.GetCommand(instruction);
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

            public Func<Rover, Rover> GetCommand(char c)
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
    }
}