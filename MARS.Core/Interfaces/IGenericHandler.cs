namespace MARS.Core.Interfaces
{
    public interface IGenericHandler<T> where T : ISpeed
    {
        GenericHandler<T> TurnLeft();
        GenericHandler<T> TurnRight();
        GenericHandler<T> TurnUp();
        GenericHandler<T> TurnDown();
        GenericHandler<T> Move();
        string GetStatusMessage();
    }
}