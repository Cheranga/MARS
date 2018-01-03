using System;
using MARS.Core.Interfaces;

namespace MARS.Core.States
{
    public class East3DState : IGenericState
    {
        public Direction Direction
        {
            get { return Direction.E; }
        }

        public IGenericState TurnDown()
        {
            return new Down3DState();
        }


        public IGenericState TurnLeft()
        {
            return new North3DState();
        }

        public IGenericState TurnRight()
        {
            return new South3DState();
        }

        public IGenericState TurnUp()
        {
            return new Up3DState();
        }

        public ICoordinate Move<T>(T @object, ICoordinate currentCoordinate) where T : ISpeed
        {
            var d3Coordinate = currentCoordinate as D3Coordinate;
            if (d3Coordinate == null)
            {
                throw new NotSupportedException("Only 3D coordinations are supported");
            }

            return new D3Coordinate(d3Coordinate.X + @object.Speed, d3Coordinate.Y, d3Coordinate.Z);
        }
    }
}