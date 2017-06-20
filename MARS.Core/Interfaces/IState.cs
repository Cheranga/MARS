namespace MARS.Core.Interfaces
{
    public interface IState
    {
        Direction Direction { get; }
        IState TurnLeft();
        IState TurnRight();
        D2Coordinate Move<T>(T @object, D2Coordinate currentCoordinate) where T:ISpeed;
    }
}