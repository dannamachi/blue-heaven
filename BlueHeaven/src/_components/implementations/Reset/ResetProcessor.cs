using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Components.Reset
{
    public class ResetProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;
        public ResetProcessor()
        {
            RefreshService();
            IsReset = false;
        }
        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }
        public void Process(IGameState gameState)
        {
            _clicking.SnapShot();
            IsReset = _clicking.IsClicked(GraphicDimension.ResetButton);
        }
        public bool IsReset { get; set; }
    }
}
