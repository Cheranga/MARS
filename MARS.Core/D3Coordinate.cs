namespace MARS.Core
{
    public class D3Coordinate
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
    }
}