using System;
using System.ComponentModel;

namespace MarsRover
{
    public class Rover
    {
        private int _x;
        private int _y;
        private Direction _direction;

        public Rover(int x, int y, Direction direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public Direction Direction
        {
            get => _direction;
            set => _direction = value;
        }

        public override string ToString()
        {
            return this._x + " " + this._y + " " + this._direction;
        }

        public void ApplyInstructions(string nasaDirectionInstructions, Plateau plateau)
        {
            foreach (var instruction in nasaDirectionInstructions)
            {
                if (instruction.ToString() == NasaInstruction.M.ToString())
                {
                    MoveRover(plateau);
                }
                else
                {
                    Turn((NasaInstruction) Enum.Parse(typeof(NasaInstruction), instruction.ToString()));
                }
            }
        }

        public void Turn(NasaInstruction nasaInstruction)
        {
            _direction = nasaInstruction switch
            {
                NasaInstruction.L => (Direction) Enum.Parse(typeof(Direction),
                    ((int.Parse(_direction.ToString("D")) + 1) % 4).ToString()),
                NasaInstruction.R => (Direction) Enum.Parse(typeof(Direction),
                    ((int.Parse(_direction.ToString("D")) + 3) % 4).ToString()),
                _ => _direction
            };
        }

        public void MoveRover(Plateau plateau)
        {
            switch (_direction)
            {
                case Direction.N:
                    _y += 1;
                    break;
                case Direction.E:
                    _x -= 1;
                    break;
                case Direction.S:
                    _y -= 1;
                    break;
                case Direction.W:
                    _x += 1;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            if (plateau.UpperRightX < _x || Plateau.LowerLeftX > _x ||
                plateau.UpperRightY < _y || Plateau.LowerLeftY > _y)
                throw new Exception(
                    "According to the instructions given, the rover were out limit values.");
        }
    }
}