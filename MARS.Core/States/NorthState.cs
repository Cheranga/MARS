using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class NorthState : IState
    {
        public Direction Direction
        {
            get
            {
                return Direction.N;
            }
        }

        public D2Coordinate Move<T>(T @object, D2Coordinate currentCoordinate) where T:ISpeed
        {
            return new D2Coordinate(currentCoordinate.X, currentCoordinate.Y + @object.Speed);
        }

        public IState TurnLeft()
        {
            return new WestState();
        }

        public IState TurnRight()
        {
            return new EastState();
        }
    }
}