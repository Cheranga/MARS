using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class SouthState : IState
    {
        public Direction Direction
        {
            get
            {
                return Direction.S;
            }
        }

        public D2Coordinate Move<T>(T @object, D2Coordinate currentCoordinate) where T : ISpeed
        {
            return new D2Coordinate(currentCoordinate.X, currentCoordinate.Y - @object.Speed);
        }

        public IState TurnLeft()
        {
            return new EastState();
        }

        public IState TurnRight()
        {
            return new WestState();
        }
    }
}