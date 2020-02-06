using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Choice
{
    // renderer: draws choices
    public class ChoiceRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        public ChoiceRenderer(List<IGraphicObject> objects)
        {
            _objects = objects;
            Hovering = -1;
        }
        public void Draw(IGameState gameState)
        {
            foreach (IGraphicObject object1 in _objects)
            {
                // draw selected choice box
                if (!object1.IsCalled("ChoiceBox" + Hovering.ToString()))
                    object1.Draw();
                else
                    object1.DrawAlternate();
            }
            foreach (IChoice choice in gameState.ChoiceDispenser.Choices)
            {
                //choice.Name; // TO DO: draw choice string
            }
        }
        public int Hovering { get; set; }
    }
}