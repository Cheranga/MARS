namespace MARS.Core.Interfaces
{
    public interface ICoordinate
    {
        bool IsValid();
        bool IsWithinBounds(ICoordinate coordinate);
    }
}