using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class EastState : IState
    {
        public Direction Direction
        {
            get { return Direction.E; }
        }

        public D2Coordinate Move<T>(T @object, D2Coordinate currentCoordinate) where T : ISpeed
        {
            return new D2Coordinate(currentCoordinate.X + @object.Speed, currentCoordinate.Y);
        }

        public IState TurnLeft()
        {
            return new NorthState();
        }

        public IState TurnRight()
        {
            return new SouthState();
        }
    }
}