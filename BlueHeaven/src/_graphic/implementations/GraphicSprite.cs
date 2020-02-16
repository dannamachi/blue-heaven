using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Graphic
{
    /// <summary>
    /// graphic object for external sprite
    /// </summary>
    public class GraphicSprite : IShape
    {
        private Texture2D _texture;
        private Rectangle _rect;

        public GraphicSprite(Texture2D texture, int x, int y, int width, int height)
            : this(texture, new int[] { x, y, width, height }) { }

        public GraphicSprite(Texture2D texture, int[] dimensions)
        {
            if (dimensions.Length != 4) dimensions = new int[] { 0, 0, 100, 100 };
            _texture = texture;
            _rect = new Rectangle(dimensions[0], dimensions[1], dimensions[2], dimensions[3]);
        }
        public void Draw(SpriteBatch sbatch)
        {
            sbatch.Begin();
            sbatch.Draw(_texture, _rect, Color.White);
            sbatch.End();
        }
        public bool IsClickedBy(int x, int y)
        {
            return _rect.Contains(x, y);
        }
    }
}
