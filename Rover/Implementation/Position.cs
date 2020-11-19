namespace Rover.Implementation
{
    using Rover.Constants;
    using Rover.Contracts;
    using System;

    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public void SetPosition(int x, int y, Directions direction)
        {
            //X = 10;  //Can set initial value to 10 as suggested in problem statement, commenting for now to make generic.
            //Y = 10;  //Can set initial value to 10 as suggested in problem statement, commenting for now to make generic. 

            X = x;
            Y = y;
            Direction = direction;
        }

        public void Move(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        this.MoveInSamePath();
                        break;
                    case 'L':
                        this.Rotate(RoverConstants.Left, RoverConstants.NinetyDegrees);
                        break;
                    case 'R':
                        this.Rotate(RoverConstants.Right, RoverConstants.NinetyDegrees);
                        break;
                    default:
                        Console.WriteLine($"Invalid command {command}");
                        break;
                }

                if (this.X < 0 || this.X > RoverConstants.MaximumXCoordinate || this.Y < 0 || this.Y > RoverConstants.MaximumYCoordinate)
                {
                    throw new Exception($"Position can not be beyond bounderies (0, 0) and (40, 30)");
                }
            }
        }

        private void MoveInSamePath()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }

        private void Rotate(string direction, int degrees)
        {
            if (direction.ToUpper() == RoverConstants.Left && degrees== RoverConstants.NinetyDegrees)
            {
                switch (Direction)
                {
                    case Directions.N:
                        Direction = Directions.W;
                        break;
                    case Directions.S:
                        Direction = Directions.E;
                        break;
                    case Directions.E:
                        Direction = Directions.N;
                        break;
                    case Directions.W:
                        Direction = Directions.S;
                        break;
                    default:
                        break;
                }
            }
            if (direction.ToUpper() == RoverConstants.Right && degrees == RoverConstants.NinetyDegrees)
            {

                switch (Direction)
                {
                    case Directions.N:
                        Direction = Directions.E;
                        break;
                    case Directions.S:
                        Direction = Directions.W;
                        break;
                    case Directions.E:
                        Direction = Directions.S;
                        break;
                    case Directions.W:
                        Direction = Directions.N;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
