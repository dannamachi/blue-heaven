namespace BlueHeaven.src.Data
{
    // abstract: tells what state the game is in
    public interface IShowState
    {
        IShowState RouteTo(string name);
        string Name { get; }
        bool IsCalled(string name);
    }
}