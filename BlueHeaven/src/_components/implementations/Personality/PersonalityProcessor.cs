using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Services;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Components.Personality
{
    // processor: user input for editing personality
    public class PersonalityProcessor : IActionProcessor
    {
        int _selected;
        bool _activated;
        private ClickDetectingService _clicking;
        public PersonalityProcessor()
        {
            RefreshService();
            _activated = false;
        }
        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }
        private void ToggleWhich(IGameState gameState)
        {
            // TO DO: remove Editable from GameState
            if (_activated && gameState.Editable)
            {
                _clicking.SnapShot();
                _selected = _clicking.WhichIsClicked(new List<int[]>
                    {
                        GraphicDimension.ToggleButton1,
                        GraphicDimension.ToggleButton2,
                        GraphicDimension.ToggleButton3,
                        GraphicDimension.ToggleButton4
                    });
            }
            else _selected = -1;
            // get which toggle button clicked (index 0,1,2,3)
            // deactivate all toggle buttons once one is clicked
            if (_selected != -1)
                _activated = false;
        }
        public void Process(IGameState gameState)
        {
            ToggleWhich(gameState);
            EditingIndex = _selected + 1;
        }

        public bool Activated { set => _activated = value; }

        public int EditingIndex { get; set; }
    }
}