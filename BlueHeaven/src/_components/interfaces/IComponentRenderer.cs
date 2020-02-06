using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: renders all components
    public interface IComponentRenderer
    {
        void Draw(List<IGameComponent> components, IGameState gameState);
    }
}