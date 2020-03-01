using BlueHeaven.src.Components;
using BlueHeaven.src.Enums;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Reset
{
    public class ResetRenderer : IObjectRenderer
    {
        private SpriteBatch _sbatch;
        private List<IGraphicObject> _objects;
        public ResetRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _sbatch = sbatch;
            _objects = objects;
        }

        public void Draw(IGameState gameState)
        {
            foreach (IGraphicObject obj in _objects)
            {
                obj.Draw(_sbatch);
            }
            CommonUtilities.DrawFont(
                "Reset?",
                FontEnum.Font20,
                CommonUtilities.GetPositionFromInt(GraphicDimension.ResetText),
                Color.Black,
                _sbatch);
        }
    }
}
