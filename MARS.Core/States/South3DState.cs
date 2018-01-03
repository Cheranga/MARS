using System;
using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class South3DState : IGenericState
    {
        public Direction Direction
        {
            get { return Direction.S; }
        }

        public IGenericState TurnLeft()
        {
            return new East3DState();
        }

        public IGenericState TurnRight()
        {
            return new West3DState();
        }

        public IGenericState TurnUp()
        {
            return new Up3DState();
        }

        public IGenericState TurnDown()
        {
            return new Down3DState();
        }

        public ICoordinate Move<T>(T @object, ICoordinate currentCoordinate) where T : ISpeed
        {
            var d3Coordinate = currentCoordinate as D3Coordinate;
            if (d3Coordinate == null)
            {
                throw new NotSupportedException("Only 3D coordinations are supported");
            }

            return new D3Coordinate(d3Coordinate.X, d3Coordinate.Y - @object.Speed, d3Coordinate.Z);
        }
    }
}