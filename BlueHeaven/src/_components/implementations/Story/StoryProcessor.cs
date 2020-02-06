using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components;
namespace BlueHeaven.src.Components.Story
{
    // processor: process user input for story component (clicking to proceed)
    public class StoryProcessor : IActionProcessor
    {
        private bool HasClicked()
        {
            return true; // detect clicking
        }
        private bool HasFinishedChoosing(IGameState gameState)
        {
            return gameState.ChoiceDispenser == null;
        }
        public void Process(IGameState gameState)
        {
            if (HasClicked())
            {
                if (HasFinishedChoosing(gameState))
                    gameState.NextLine = true;
            }
            else
                gameState.NextLine = false;
        }
    }
}