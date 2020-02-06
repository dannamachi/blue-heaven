using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: updates data in gameState for each cycle, within a component
    public interface IStateUpdater
    {
        void Update(IGameState gameState);
    }
}