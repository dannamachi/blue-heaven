using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: updates game data for all components
    public interface IComponentUpdater
    {
        void Update(List<IGameComponent> components, IGameState gameState);
    }
}