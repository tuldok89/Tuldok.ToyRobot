using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuldok.ToyRobot.Lib
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class Robot
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsPlaced { get; private set; }

        private readonly string _moveErrorMsg = "Movement cancelled. Robot is going to fall off the table.";
        private readonly string _placeErrorMsg = "Parameter must be within range 0 to 4";

        public Direction Direction { get; private set; }

        public void Move()
        {
            if (!IsPlaced)
            {
                throw new NotPlacedException();
            }

            int x = X;
            int y = Y;

            switch (Direction)
            {
                case Direction.North:
                    y++;
                    break;
                case Direction.West:
                    x--;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.South:
                    y--;
                    break;
            }

            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(message: _moveErrorMsg, innerException: null);
            }
            else if (y > 4)
            {
                throw new ArgumentOutOfRangeException(message: _moveErrorMsg, innerException: null);
            }
            else if (x < 0)
            {
                throw new ArgumentOutOfRangeException(message: _moveErrorMsg, innerException: null);
            }
            else if (x > 4)
            {
                throw new ArgumentOutOfRangeException(message: _moveErrorMsg, innerException: null);
            }

            Y = Math.Clamp(y, 0, 4);
            X = Math.Clamp(x, 0, 4);
        }

        public void TurnLeft()
        {
            if (!IsPlaced)
            {
                throw new NotPlacedException();
            }

            int dir = (int)Direction;
            dir = Normalize(--dir,4);
            Direction = (Direction)dir;
        }

        public void TurnRight()
        {
            if (!IsPlaced)
            {
                throw new NotPlacedException();
            }

            int dir = (int)Direction;
            dir = Normalize(++dir,4);
            Direction = (Direction)dir;
        }

        private static int Normalize(int value, int modulo)
        {
            int remainder = value % modulo;

            return (remainder < 0) ? (modulo + remainder) : remainder;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (x < 0 || x > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(x), _placeErrorMsg);
            }
            else if (y < 0 || y > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(y), _placeErrorMsg);
            }

            X = x;
            Y = y;
            Direction = direction;
            IsPlaced = true;
        }
    }
}
