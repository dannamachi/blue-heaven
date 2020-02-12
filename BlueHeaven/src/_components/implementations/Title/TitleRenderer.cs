using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Title
{
    // renderer: draws personality editor
    public class TitleRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private SpriteBatch _sbatch;
        public TitleRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _objects = objects;
            Hovering = -1;
            _sbatch = sbatch;
        }

        private void UpdateSelected()
        {
            string name = "";
            switch (Hovering)
            {
                case 0:
                    name = "Help";
                    break;
                case 1:
                    name = "Credits";
                    break;
                case 2:
                    name = "Reload";
                    break;
            }
            foreach (IGraphicObject obj in _objects)
            {
                obj.IsAlternate = obj.IsCalled(name + "Button");
            }
        }
        public void Draw(IGameState gameState)
        {
            UpdateSelected();
            foreach (IGraphicObject obj in _objects)
            {
                obj.Draw(_sbatch);
            }

            CommonUtilities.DrawFont(
                    "Help",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.TitleTextHelp),
                    Color.Black,
                    _sbatch);
            CommonUtilities.DrawFont(
                    "Credits",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.TitleTextCredits),
                    Color.Black,
                    _sbatch);
            CommonUtilities.DrawFont(
                    "Reload",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.TitleTextReload),
                    Color.Black,
                    _sbatch);
        }

        public int Hovering { get; set; }
    }
}