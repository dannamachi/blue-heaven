using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BlueHeaven.src.Components.Reload
{
    public class ReloadRenderer : IObjectRenderer
    {
        private SpriteBatch _sbatch;
        private List<IGraphicObject> _objects;
        public ReloadRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _sbatch = sbatch;
            _objects = objects;
            CurrentString = "";
            Invalid = false;
            NoExist = false;
        }
        
        public void Draw(IGameState gameState)
        {
            foreach (IGraphicObject obj in _objects)
            {
                obj.Draw(_sbatch);
            }

            CommonUtilities.DrawFont(
                "Enter your product code:",
                FontEnum.Font20,
                CommonUtilities.GetPositionFromInt(GraphicDimension.ReloadText),
                Color.White,
                _sbatch);
            CommonUtilities.DrawFont(
                CurrentString,
                FontEnum.Font20,
                CommonUtilities.GetPositionFromInt(GraphicDimension.ReloadInput),
                Color.White,
                _sbatch);
            CommonUtilities.DrawFont(
                "Reload",
                FontEnum.Font20,
                CommonUtilities.GetPositionFromInt(GraphicDimension.ReloadButtonText),
                Color.White,
                _sbatch);

            if (Invalid)
            {
                CommonUtilities.DrawFont(
                    "Seems like an invalid code",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.ReloadValidation),
                    Color.White,
                    _sbatch);
            }

            if (NoExist)
            {
                CommonUtilities.DrawFont(
                    "That product does not exist",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.ReloadValidation),
                    Color.White,
                    _sbatch);
            }
        }

        public string CurrentString { get; set; }
        public bool Invalid { get; set; }
        public bool NoExist { get; set; }
    }
}
