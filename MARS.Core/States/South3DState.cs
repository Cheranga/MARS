using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class South3DState : I3DState
    {
        public Direction Direction
        {
            get { return Direction.S; }
        }

        public I3DState TurnLeft()
        {
            return new West3DState();
        }

        public I3DState TurnRight()
        {
            return new East3DState();
        }

        public I3DState TurnUp()
        {
            return new Up3DState();
        }

        public I3DState TurnDown()
        {
            return new Down3DState();
        }

        public D3Coordinate Move<T>(T @object, D3Coordinate currentCoordinate) where T : ISpeed
        {
            return new D3Coordinate(currentCoordinate.X, currentCoordinate.Y - @object.Speed, currentCoordinate.Z);
        }
    }
}