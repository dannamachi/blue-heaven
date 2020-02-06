using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: process user input for all components
    public interface IComponentProcessor
    {
        void Process(List<IGameComponent> components, IGameState gameState);
    }
}