using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // renderer: draws all active components
    public class RootRenderer : IComponentRenderer
    {
        public RootRenderer() { }
        public void Draw(List<IGameComponent> components, IGameState gameState)
        {
            foreach (IGameComponent component in components)
            {
                if (component.IsActive)
                    component.Draw(gameState);
            }
        }
    }
}