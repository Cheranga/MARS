using System;

namespace MARS.Core.Interfaces
{
    public class GenericHandler<T> : IGenericHandler<T> where T : ISpeed
    {
        private readonly T _item;
        private readonly ICoordinate _bounds;
        private ICoordinate _current;
        private IGenericState _state;


        public GenericHandler(ICoordinate bounds, ICoordinate current, T item, IGenericState state)
        {
            _bounds = bounds;
            _current = current;
            _item = item;
            _state = state;
        }

        public GenericHandler<T> TurnLeft()
        {
            _state = _state.TurnLeft();
            return this;
        }

        public GenericHandler<T> TurnRight()
        {
            _state = _state.TurnRight();
            return this;
        }

        public GenericHandler<T> TurnUp()
        {
            _state = _state.TurnUp();
            return this;
        }

        public GenericHandler<T> TurnDown()
        {
            _state = _state.TurnDown();
            return this;
        }

        public GenericHandler<T> Move()
        {
            var position = _state.Move(_item, _current);
            //
            // Check whether the position returned is within bounds. If it's set it as the new position, otherwise no need to anything
            //
            if (_bounds.IsWithinBounds(position))
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
            var displayObject = _item as IDisplay;
            var displayObjectMessage = displayObject == null ? "Item is" : displayObject.Display();

            var displayCooordinate = _current as IDisplay;
            var displayCoordinateMessage = displayCooordinate == null ? string.Empty : displayCooordinate.Display();

            return $"{displayObjectMessage} in {displayCoordinateMessage} facing [{_state.Direction}]";
        }
    }
}