using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Title
{
    // processor: processes request to navigate
    public class TitleProcessor : IActionProcessor
    {
        private List<IGraphicObject> _objects;
        public TitleProcessor(List<IGraphicObject> objects)
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