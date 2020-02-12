using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components;
using BlueHeaven.src.Enums;
using BlueHeaven.src.Services;
namespace BlueHeaven.src.Components.Story
{
    /// <summary>
    /// Processes user input (clicking to proceed)
    /// </summary>
    public class StoryProcessor : IActionProcessor
    {
        private ClickDetectingService _clicking;
        public StoryProcessor()
        {
            NextLine = false;
            RefreshService();
        }

        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }

        /// <summary>
        /// Processes story mode
        /// </summary>
        /// <param name="gameState"></param>
        public void Process(IGameState gameState)
        {
            _clicking.SnapShot();
            if (_clicking.IsClicked(GraphicDimension.StoryFrame)) NextLine = true;
            else NextLine = false;
        }

        public bool NextLine { get; set; }
    }
}