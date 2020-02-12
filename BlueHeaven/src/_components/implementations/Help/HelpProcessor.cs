using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using System.Collections.Generic;

namespace BlueHeaven.src.Components.Help
{
    /// <summary>
    /// Processes input in Help page
    /// </summary>
    public class HelpProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;
        public HelpProcessor()
        {
            RefreshService();
        }

        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }

        /// <summary>
        /// Process help component
        /// </summary>
        /// <param name="gameState"></param>
        public void Process(IGameState gameState)
        {
            _clicking.SnapShot();
            Hovering = _clicking.WhichIsHovered(new List<int[]>
            {
                GraphicDimension.UpButton,
                GraphicDimension.DownButton
            });
            UpPage = _clicking.IsClicked(GraphicDimension.UpButton);
            DownPage = _clicking.IsClicked(GraphicDimension.DownButton);
        }

        public int Hovering { get; set; }

        public bool UpPage { get; set; }

        public bool DownPage { get; set; }
    }
}
