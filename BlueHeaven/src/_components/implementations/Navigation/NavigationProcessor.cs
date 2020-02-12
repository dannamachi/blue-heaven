using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Services;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Components.Navigation
{
    // processor: processes request to navigate
    public class NavigationProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;
        public NavigationProcessor()
        {
            NavigatingTo = -1;
            RefreshService();
        }
        
        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }
        public void Process(IGameState gameState)
        {
            // detect clicking of button
            _clicking.SnapShot();
            NavigatingTo = _clicking.WhichIsClicked(new List<int[]>
            {
                GraphicDimension.NavigationTitle,
                GraphicDimension.NavigationReading,
                GraphicDimension.NavigationSetting,
            });
        }

        public int NavigatingTo { get; set; }
    }
}