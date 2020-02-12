using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Components.Navigation
{
    // renderer: draws personality editor
    public class NavigationRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private SpriteBatch _sbatch;
        public NavigationRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _objects = objects;
            _sbatch = sbatch;
        }
        private void UpdateAlternate()
        {
            int currState = -1;
            switch (CurrentState)
            {
                case "Title":
                case "Help":
                case "Credits":
                    currState = 1;
                    break;
                case "Reading/Choosing":
                case "Reading/Story":
                    currState = 2;
                    break;
                case "Setting":
                    currState = 3;
                    break;
            }
            foreach (IGraphicObject obj in _objects)
            {
                obj.IsAlternate = obj.IsCalled("NavigationButton" + currState.ToString());
            }
        }

        public void Draw(IGameState gameState)
        {
            UpdateAlternate();
            // draw navigation buttons (alternate for current state)
            foreach (IGraphicObject object1 in _objects)
            {
                object1.Draw(_sbatch);
            }
            // draw button text
            CommonUtilities.DrawFont(
                    "Title",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.NavigationTextTitle),
                    Color.Black,
                    _sbatch);
            CommonUtilities.DrawFont(
                    "Reading",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.NavigationTextReading),
                    Color.Black,
                    _sbatch);
            CommonUtilities.DrawFont(
                    "Setting",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.NavigationTextSetting),
                    Color.Black,
                    _sbatch);
        }

        public string CurrentState { get; set; }
    }
}