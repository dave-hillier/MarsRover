using System;

namespace MarsRover
{
    internal struct Rover
    {
        private static readonly Vector2[] Directions = new[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };

        public Vector2 Position;
        
        internal enum Direction { N, E, S, W }

        public Direction Orientation;

        public void RotateLeft()
        {
            var numDirections = Enum.GetNames(typeof(Direction)).Length;
            Orientation = (Direction)(((int)Orientation - 1 + numDirections) % numDirections);
        }

        public void RotateRight()
        {
            var numDirections = Enum.GetNames(typeof(Direction)).Length;
            Orientation = (Direction)(((int)Orientation + 1) % numDirections);
        }

        public void Move()
        {
            Position += Directions[(int)Orientation];
        }

        public static Rover Parse(string line)
        {
            var @params = line.Split(' ');
            var r = new Rover
                {
                    Position = new Vector2 { X = Int32.Parse(@params[0]), Y = Int32.Parse(@params[1]) },
                    Orientation = (Direction)Enum.Parse(typeof(Direction), @params[2], ignoreCase: true)
                };
            return r;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Position.X, Position.Y, Orientation);
        }
    }
}