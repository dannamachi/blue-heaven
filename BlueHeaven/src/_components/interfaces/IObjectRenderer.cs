using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: render graphic objects of a component
    public interface IObjectRenderer
    {
        void Draw(IGameState gameState);
    }
}