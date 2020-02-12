using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    /// <summary>
    /// Renders all sub components
    /// </summary>
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