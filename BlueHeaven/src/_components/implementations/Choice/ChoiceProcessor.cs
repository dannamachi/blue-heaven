using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework.Input;
using BlueHeaven.src.Services;
namespace BlueHeaven.src.Components.Choice
{
    // processor: user input for choosing
    public class ChoiceProcessor : IActionProcessor
    {
        int _hovered, _selected;
        private ClickDetectingService _clicking;
        public ChoiceProcessor()
        {
            RefreshService();
        }

        public void RefreshService()
        {
            _clicking = new ClickDetectingService();
        }

        /// <summary>
        /// Process choice component
        /// </summary>
        /// <param name="gameState"></param>
        public void Process(IGameState gameState)
        {
            _clicking.SnapShot();
            // hovering index
            _hovered = _clicking.WhichIsHovered(new List<int[]>
            {
                GraphicDimension.ChoiceBox1,
                GraphicDimension.ChoiceBox2,
                GraphicDimension.ChoiceBox3
            });

            // choosing index
            _selected = _clicking.WhichIsClicked(new List<int[]>
            {
                GraphicDimension.ChoiceBox1,
                GraphicDimension.ChoiceBox2,
                GraphicDimension.ChoiceBox3
            });

            if (_selected >= gameState.ChoiceDispenser.Choices.Count) _selected = -1;
        }
        public int Hovering { get => _hovered; }
        public bool ChosenDetected { get => _selected != -1; }
        public int Chosen { get => _selected; }
    }
}