namespace MARS.Core.Interfaces
{
    public interface IState
    {
        Direction Direction { get; }
        IState TurnLeft();
        IState TurnRight();
        D2Coordinate Move<T>(T @object, D2Coordinate currentCoordinate) where T:ISpeed;
    }

    public interface I3DState
    {
        Direction Direction { get; }
        I3DState TurnLeft();
        I3DState TurnRight();
        I3DState TurnUp();
        I3DState TurnDown();
        D3Coordinate Move<T>(T @object, D3Coordinate currentCoordinate) where T : ISpeed;
    }
}