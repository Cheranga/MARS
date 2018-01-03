using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class East3DState : I3DState
    {
        public Direction Direction
        {
            get { return Direction.E; }
        }

        public I3DState TurnDown()
        {
            return new Down3DState();
        }

        public D3Coordinate Move<T>(T @object, D3Coordinate currentCoordinate) where T : ISpeed
        {
            return new D3Coordinate(currentCoordinate.X + @object.Speed, currentCoordinate.Y, currentCoordinate.Z);
        }

        public I3DState TurnLeft()
        {
            return new North3DState();
        }

        public I3DState TurnRight()
        {
            return new South3DState();
        }

        public I3DState TurnUp()
        {
            return new Up3DState();
        }
    }
}