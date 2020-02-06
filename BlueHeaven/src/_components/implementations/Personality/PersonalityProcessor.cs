using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Personality
{
    // processor: user input for editing personality
    public class PersonalityProcessor : IActionProcessor
    {
        private List<IGraphicObject> _objects;
        int _selected;
        bool _activated;
        public PersonalityProcessor(List<IGraphicObject> objects)
        {
            _objects = objects;
        }
        private void ToggleWhich()
        {
            // TO DO: remove Editable from GameState

            // get which toggle button clicked (index 0,1,2,3)
            _selected = -1;
            // deactivate all toggle buttons once one is clicked
            //if (_selected != -1)
            //    gameState.Editable = false;
        }
        public void Process(IGameState gameState)
        {
            CheckActivate(gameState);
            ToggleWhich();
            gameState.EditingIndex = _selected + 1;
        }
        private void CheckActivate(IGameState gameState)
        {
            _activated = gameState.Editable;
        }
    }
}