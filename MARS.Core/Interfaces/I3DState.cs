namespace MARS.Core.Interfaces
{
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