using System.Security.Policy;
using MARS.Core.Interfaces;

namespace MARS.Core
{
    public class D2Coordinate : ICoordinate, IDisplay
    {
        public D2Coordinate(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; }
        public long Y { get; }
        public bool IsValid()
        {
            return X >= 0 && Y >= 0;
        }

        public bool IsWithinBounds(ICoordinate coordinate)
        {
            var d2Coordinate = coordinate as D2Coordinate;
            if (d2Coordinate == null)
            {
                return IsValid();
            }

            return IsValid() &&
                   (d2Coordinate.X <= X && d2Coordinate.Y <= Y);
        }

        public string Display()
        {
            return $"[{X}, {Y}]";
        }
    }
}