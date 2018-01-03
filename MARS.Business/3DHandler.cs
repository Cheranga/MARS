using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MARS.Business.Helpers;
using MARS.Core;
using MARS.Core.Interfaces;
using MARS.Core.States;

namespace MARS.Business
{
    public class D3Handler<T> : I3DHandler<T> where T : ISpeed
    {
        private readonly D3Coordinate _bounds;
        private D3Coordinate _current;
        private T _object;
        private I3DState _state;

        public D3Handler(long x, long y, long z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
            {
                throw new ArgumentException(@"The dimensions are incorrect");
            }

            _bounds = new D3Coordinate(x, y, z);
        }

        public I3DHandler<T> StartIn(T @object, long x, long y, long z, Direction direction)
        {
            if (_bounds == null)
            {
                throw new Exception("Please provide bounds first");
            }

            return PutObjectIn(@object, new D3Coordinate(x, y, z), direction);
        }

        private I3DHandler<T> PutObjectIn(T @object, D3Coordinate coordinate, Direction direction)
        {
            //
            // TODO: Write separate test cases to showcase these errors
            //
            if (@object == null)
            {
                throw new NullReferenceException("Please provide an object for the handler to move");
            }
            if (!IsWithinBounds(coordinate))
            {
                throw new ArgumentException("The starting position is not within bounds", "startingPosition");
            }
            if (direction == Direction.NotSupported)
            {
                throw new NotSupportedException("Please provide a valid direction for the object");
            }

            _current = coordinate;
            _state = GetState(direction);
            _object = @object;

            return this;
        }

        private bool IsWithinBounds(D3Coordinate position)
        {
            if (position == null)
            {
                return false;
            }

            return ((position.X >= 0 && position.Y >= 0 && position.Z >= 0) &&
                    (position.X <= _bounds.X && position.Y <= _bounds.Y && position.Z <= _bounds.Z));
        }

        private I3DState GetState(Direction direction)
        {
            I3DState state = null;
            switch (direction)
            {
                case Direction.N:
                    state = new North3DState();
                    break;

                case Direction.E:
                    state = new East3DState();
                    break;

                case Direction.S:
                    state = new South3DState();
                    break;

                case Direction.W:
                    state = new West3DState();
                    break;

                case Direction.Up:
                    state = new Up3DState();
                    break;

                case Direction.Down:
                    state = new Down3DState();
                    break;
            }

            return state;
        }

        public I3DHandler<T> TurnLeft()
        {
            _state = _state.TurnLeft();
            return this;
        }

        public I3DHandler<T> TurnRight()
        {
            _state = _state.TurnRight();
            return this;
        }

        public I3DHandler<T> TurnUp()
        {
            _state = _state.TurnUp();
            return this;
        }

        public I3DHandler<T> TurnDown()
        {
            _state = _state.TurnDown();
            return this;
        }

        public I3DHandler<T> Move()
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

            return $"{displayObjectMessage} in [{_current.X}, {_current.Y}, {_current.Z}] facing [{_state.Direction}]";
        }
    }
}
