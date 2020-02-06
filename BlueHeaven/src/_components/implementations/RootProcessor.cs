using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // processor: processes all active components
    public class RootProcessor : IComponentProcessor
    {
        public RootProcessor() { }
        public void Process(List<IGameComponent> components, IGameState gameState)
        {
            foreach (IGameComponent component in components)
            {
                if (component.IsActive)
                    component.ProcessInput(gameState);
            }
        }
    }
}