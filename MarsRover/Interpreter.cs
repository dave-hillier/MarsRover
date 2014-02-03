using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRover
{
    public class Interpreter
    {
        private Vector2 _bounds;
        private readonly Dictionary<char, Func<Rover, Rover>> _commandLookup;

        public Interpreter()
        {
            _commandLookup = new Dictionary<char, Func<Rover, Rover>> {
                    { 'M', Move },
                    { 'L', r => { r.RotateLeft(); return r; } },
                    { 'R', r => { r.RotateRight(); return r; } },
                };
        }

        public void Run(TextReader input, TextWriter output)
        {
            _bounds = GetBoundary(input.ReadLine());
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

        private static Vector2 GetBoundary(string line)
        {
            var @params = line.Split(' ');
            return new Vector2(Int32.Parse(@params[0]), Int32.Parse(@params[1]));
        }

        internal void ProcessInstructions(ref Rover rover, IEnumerable<char> instructions)
        {
            foreach (var instruction in instructions)
            {
                var cmd = GetCommand(instruction);
                rover = cmd(rover);
            }
        }

        private Func<Rover, Rover> GetCommand(char c)
        {
            return _commandLookup[c];
        }

        private Rover Move(Rover rover)
        {
            rover.Move();
            if (rover.Position.X > _bounds.X || rover.Position.X < 0 || 
                rover.Position.Y > _bounds.Y || rover.Position.Y < 0)
                throw new InvalidOperationException("Out of bounds");
            return rover;
        }
    }
}