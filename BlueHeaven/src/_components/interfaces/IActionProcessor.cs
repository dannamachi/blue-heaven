using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: process user input for individual component
    public interface IActionProcessor
    {
        void Process(IGameState gameState);
    }
}
