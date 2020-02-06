using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: a component of the game
    public interface IGameComponent
    {
        // call when reactivated
        void Setup(IGameState gameState);
        void ProcessInput(IGameState gameState);
        void Update(IGameState gameState);
        void Draw(IGameState gameState);
        bool IsActive { get; set; }
        string ActiveUnderState { get; }
    }
}