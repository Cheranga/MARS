namespace MARS.Core.Interfaces
{
    public interface IGenericState
    {
        Direction Direction { get; }
        IGenericState TurnLeft();
        IGenericState TurnRight();
        IGenericState TurnUp();
        IGenericState TurnDown();
        ICoordinate Move<T>(T @object, ICoordinate currentCoordinate) where T : ISpeed;
    }
}