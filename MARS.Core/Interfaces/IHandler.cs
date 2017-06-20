namespace MARS.Core.Interfaces
{
    public interface IHandler<T> where T : ISpeed
    {
        IHandler<T> StartIn(T @object, long x, long y, Direction direction);
        IHandler<T> TurnLeft();
        IHandler<T> TurnRight();
        IHandler<T> Move();
        string GetStatusMessage();
    }
}