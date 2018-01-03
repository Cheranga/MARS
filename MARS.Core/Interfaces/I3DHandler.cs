namespace MARS.Core.Interfaces
{
    public interface I3DHandler<T> where T : ISpeed
    {
        I3DHandler<T> StartIn(T @object, long x, long y, Direction direction);
        I3DHandler<T> TurnLeft();
        I3DHandler<T> TurnRight();
        I3DHandler<T> TurnUp();
        I3DHandler<T> TurnDown();
        I3DHandler<T> Move();
        string GetStatusMessage();
    }
}