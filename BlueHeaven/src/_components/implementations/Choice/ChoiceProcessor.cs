using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Choice
{
    // processor: user input for choosing
    public class ChoiceProcessor : IActionProcessor
    {
        private List<IGraphicObject> _objects;
        int _hovered, _selected;
        public ChoiceProcessor(List<IGraphicObject> objects)
        {
            _objects = objects;
        }
        public void Process(IGameState gameState)
        {
            // if mouse over button, set it to hovered, otherwise -1
            _hovered = -1;
            // if clicked, set it to selected, otherwise -1
            _selected = -1;
        }
        public bool HoveringDetected { get => _hovered != -1; }
        public int Hovering { get => _hovered; }
        public bool ChosenDetected { get => _selected != -1; }
        public int Chosen { get; set; }
    }
}