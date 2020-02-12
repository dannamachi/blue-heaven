using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    /// <summary>
    /// Renders all sub components
    /// </summary>
    public interface IComponentRenderer
    {
        void Draw(List<IGameComponent> components, IGameState gameState);
    }
}