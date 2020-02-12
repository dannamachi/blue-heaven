using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueHeaven.src.Services;

namespace BlueHeaven.src.Components.Help
{
    /// <summary>
    /// Renders help component
    /// </summary>
    public class HelpRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private SpriteBatch _sbatch;
        private InfoService _info;
        public HelpRenderer(List<IGraphicObject> objects, SpriteBatch sbatch, InfoService info)
        {
            _info = info;
            _sbatch = sbatch;
            _objects = objects;
            Hovering = -1;
        }

        public void RefreshService(InfoService info)
        {
            _info = info;
        }

        public void UpdateSelected()
        {
            foreach (IGraphicObject obj in _objects)
            {
                if (obj.IsCalled("UpButton")) obj.IsAlternate = Hovering == 0;
                if (obj.IsCalled("DownButton")) obj.IsAlternate = Hovering == 1;
            }
        }

        public void Draw(IGameState gameState)
        {
            UpdateSelected();
            foreach (IGraphicObject object1 in _objects)
            {
                object1.Draw(_sbatch);
            }
            // print help info
            _info.PrintLines(
                GraphicDimension.InfoText,
                _sbatch,
                FontEnum.Font20);
            // print up down button text
            CommonUtilities.DrawFont(
                    "<<",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.DownText),
                    Color.Black,
                    _sbatch);
            CommonUtilities.DrawFont(
                    ">>",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.UpText),
                    Color.Black,
                    _sbatch);
        }
        public int Hovering { get; set; }
    }
}
