using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    /// <summary>
    /// Draws graphic objects stored
    /// </summary>
    public interface IObjectRenderer
    {
        void Draw(IGameState gameState);
    }
}