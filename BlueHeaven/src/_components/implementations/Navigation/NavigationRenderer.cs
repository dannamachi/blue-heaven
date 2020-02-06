using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Navigation
{
    // renderer: draws personality editor
    public class NavigationRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private IRoute _router;
        public NavigationRenderer(List<IGraphicObject> objects, IRoute router)
        {
            _objects = objects;
            _router = router;
        }
        public void Draw(IGameState gameState)
        {
            // draw navigation buttons (alternate for current state)
            foreach (IGraphicObject object1 in _objects)
            {
                if (!object1.IsCalled("NavigationButton" + _router.CurrentState.Name))
                    object1.Draw();
                else
                    object1.DrawAlternate();
            }
        }
    }
}