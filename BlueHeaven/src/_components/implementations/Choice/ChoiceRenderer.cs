using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Choice
{
    // renderer: draws choices
    public class ChoiceRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private SpriteBatch _sbatch;
        public ChoiceRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _sbatch = sbatch;
            _objects = objects;
            Hovering = -1;
        }
        private void UpdateSelected(IGameState gameState)
        {
            foreach (IGraphicObject obj in _objects)
            {
                if (obj.IsCalled("ChoiceBox" + (Hovering + 1).ToString())) obj.IsAlternate = true;
                else obj.IsAlternate = false;
            }
        }
        public void Draw(IGameState gameState)
        {
            foreach (IGraphicObject object1 in _objects)
            {
                object1.Draw(_sbatch);
            }
            UpdateSelected(gameState);
            int index = 0;
            Vector2[] posArray = new Vector2[]
            {
                CommonUtilities.GetPositionFromInt(GraphicDimension.ChoiceTextFrame1),
                CommonUtilities.GetPositionFromInt(GraphicDimension.ChoiceTextFrame2),
                CommonUtilities.GetPositionFromInt(GraphicDimension.ChoiceTextFrame3)
            };
            foreach (IChoice choice in gameState.ChoiceDispenser.Choices)
            {
                CommonUtilities.DrawFont(
                    choice.Name,
                    FontEnum.Font20,
                    posArray[index],
                    Color.Black,
                    _sbatch);
                index += 1;
            }
        }
        public int Hovering { get; set; }
    }
}