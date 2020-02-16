using BlueHeaven.src.Data;
using BlueHeaven.src.Services;

namespace BlueHeaven.src.Components.Graphic
{
    /// <summary>
    /// Processes graphic component
    /// </summary>
    public class GraphicProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;

        public GraphicProcessor() { }

        public void Process(IGameState gameState) { }
    }
}
