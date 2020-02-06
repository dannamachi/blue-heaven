using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Navigation
{
    // processor: processes request to navigate
    public class NavigationProcessor : IActionProcessor
    {
        private List<IGraphicObject> _objects;
        public NavigationProcessor(List<IGraphicObject> objects)
        {
            _objects = objects;
            NavigatingTo = -1;
        }
        public void Process(IGameState gameState)
        {
            // detect clicking of button
            NavigatingTo = -1;
        }
        public bool NavigationDetected { get => NavigatingTo != -1; }
        public int NavigatingTo { get; set; }
    }
}