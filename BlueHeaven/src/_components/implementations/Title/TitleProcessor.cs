using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Services;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Components.Title
{
    // processor: processes request to navigate
    public class TitleProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;
        public TitleProcessor()
        {
            RefreshService();
            NavigatingTo = -1;
        }
        
        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }
        public void Process(IGameState gameState)
        {
            _clicking.SnapShot();
            Hovering = _clicking.WhichIsHovered(new List<int[]>
            {
                GraphicDimension.TitleHelp,
                GraphicDimension.TitleCredits,
                GraphicDimension.TitleReload
            });
            NavigatingTo = _clicking.WhichIsClicked(new List<int[]>
            {
                GraphicDimension.TitleHelp,
                GraphicDimension.TitleCredits,
                GraphicDimension.TitleReload
            });
  
        }
        public int Hovering { get; set; }
        public int NavigatingTo { get; set; }
    }
}