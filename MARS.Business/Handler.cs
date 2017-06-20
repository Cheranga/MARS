using System;
using MARS.Business;
using MARS.Business.Helpers;
using MARS.Core;
using MARS.Core.Interfaces;

namespace MARS.Business
{
    //
    //  TODO:
    //  1.  Instead of throwing errors in operations, wrap the status of the operation in a class called "Result<T>" and
    //      use it pass information about the operation, and let the caller decide whether to throw exceptions or not.
    //
    //  2.  Also the operations "TurnLeft", "TurnRight" and "Move" must be mapped to user input parser (i.e. "L" => "TurnLeft", "R" => "TurnRight") and so on)
    // 
    public class Handler<T> : IHandler<T> where T : ISpeed
    {
        private readonly D2Coordinate _bounds;
        private D2Coordinate _current;
        private T _object;
        private IState _state;

        public Handler(long width, long height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException(@"Both [width] and [height] must be greater than zero");
            }

            _bounds = new D2Coordinate(width, height);
        }

        public IHandler<T> StartIn(T @object, long x, long y, Direction direction)
        {
            if (_bounds == null)
            {
                throw new Exception("Please provide bounds first");
            }

            return PutObjectIn(@object, new D2Coordinate(x, y), direction);
        }

        public IHandler<T> TurnLeft()
        {
            _state = _state.TurnLeft();
            return this;
        }

        public IHandler<T> TurnRight()
        {
            _state = _state.TurnRight();
            return this;
        }

        public IHandler<T> Move()
        {
            var position = _state.Move(_object, _current);
            //
            // Check whether the position returned is within bounds. If it's set it as the new position, otherwise no need to anything
            //
            if (IsWithinBounds(position))
            {
                _current = position;
            }

            return this;
        }

        public string GetStatusMessage()
        {
            //
            // If the current item supports its way of displaying information (i.e. "IDisplay") use it
            //
            var displayObject = _object as IDisplay;
            var displayObjectMessage = displayObject == null ? "Item is" : displayObject.Display();

            return string.Format("{0} in [{1}, {2}] facing [{3}]", displayObjectMessage, _current.X, _current.Y, _state.Direction);
        }

        private IHandler<T> PutObjectIn(T @object, D2Coordinate startingPosition, Direction direction)
        {   
            //
            // TODO: Write separate test cases to showcase these errors
            //
            if (@object == null)
            {
                throw new NullReferenceException("Please provide an object for the handler to move");
            }
            if (!IsWithinBounds(startingPosition))
            {
                throw new ArgumentException("The starting position is not within bounds", "startingPosition");
            }
            if (direction == Direction.NotSupported)
            {
                throw new NotSupportedException("Please provide a valid direction for the object");
            }

            _current = startingPosition;
            _state = direction.State();
            _object = @object;

            return this;
        }

        private bool IsWithinBounds(D2Coordinate position)
        {
            if (position == null)
            {
                return false;
            }

            return ((position.X >= 0 && position.Y >= 0) &&
                    (position.X <= _bounds.X && position.Y <= _bounds.Y));
        }
    }
}