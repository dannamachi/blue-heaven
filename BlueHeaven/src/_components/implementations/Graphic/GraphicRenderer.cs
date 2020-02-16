using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Graphic
{
    /// <summary>
    /// Renders story graphic
    /// </summary>
    public class GraphicRenderer : IObjectRenderer
    {
        private SpriteBatch _sbatch;
        public GraphicRenderer(SpriteBatch sbatch)
        {
            _sbatch = sbatch;
        }

        public void Draw(IGameState gameState)
        {
            GraphicBuilder.GetBackground(CurrentBackground).Draw(_sbatch);
            GraphicBuilder.GetStoryGraphic(CurrentGraphic).Draw(_sbatch);
        }

        public StoryGraphicCode CurrentGraphic { get; set; }

        public BackgroundCode CurrentBackground { get; set; }
    }
}
