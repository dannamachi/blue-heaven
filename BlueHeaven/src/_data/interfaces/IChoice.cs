namespace BlueHeaven.src.Data
{
    // abstract: string chosen by user that affects ICharacter 
    public interface IChoice
    {
        string Name { get; }
        bool IsCalled(string name);
        void IsChosen(IGameState gameState);
    }
}