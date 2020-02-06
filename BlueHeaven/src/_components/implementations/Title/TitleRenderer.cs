using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Title
{
    // renderer: draws personality editor
    public class TitleRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        public TitleRenderer(List<IGraphicObject> objects)
        {
            _objects = objects;
        }
        public void Draw(IGameState gameState)
        {

        }
    }
}