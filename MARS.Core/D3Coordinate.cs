using MARS.Core.Interfaces;

namespace MARS.Core
{
    public class D3Coordinate : ICoordinate, IDisplay
    {
        public D3Coordinate(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public long X { get; }
        public long Y { get; }
        public long Z { get; }

        public bool IsValid()
        {
            return X >= 0 && Y >= 0 && Z >= 0;
        }

        public bool IsWithinBounds(ICoordinate coordinate)
        {
            var d3Coordinate = coordinate as D3Coordinate;

            if (d3Coordinate == null)
            {
                return IsValid();
            }

            return IsValid() &&
                d3Coordinate.IsValid() && 
                (d3Coordinate.X <= X && d3Coordinate.Y <= Y && d3Coordinate.Z <= Z);
        }

        public string Display()
        {
            return $"[{X}, {Y}, {Z}]";
        }
    }
}