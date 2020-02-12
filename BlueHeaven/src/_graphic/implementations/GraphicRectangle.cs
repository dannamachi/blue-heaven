using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Graphic
{
    /// <summary>
    /// rectangle with uniform color that can draw itself
    /// </summary>
    public class GraphicRectangle : IShape
    {
        private Texture2D _rect;
        private Vector2 _pos;
        private Color _color;

        public GraphicRectangle(GraphicsDevice graphics, int x, int y, int width, int height, Color color) 
            : this(graphics,new int[] { x,y,width,height},color) { }

        public GraphicRectangle(GraphicsDevice graphics, int[] dimensions, Color color)
        {
            if (dimensions.Length != 4) dimensions = new int[] { 0, 0, 100, 100 };
            _rect = new Texture2D(graphics, dimensions[2], dimensions[3]);
            SetColor(color);
            _pos = new Vector2(dimensions[0], dimensions[1]);
        }

        /// <summary>
        /// Change color of rectangle
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            Color[] data = new Color[_rect.Width * _rect.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            _rect.SetData(data);
        }

        /// <summary>
        /// Set coord for top left corner (where rectangle is draw)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetCorner(int x, int y)
        {
            _pos = new Vector2(x, y);
        }

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="sbatch"></param>
        public void Draw(SpriteBatch sbatch)
        {
            sbatch.Begin();
            sbatch.Draw(_rect, _pos, Color.White);
            sbatch.End();
        }

        /// <summary>
        /// Get bool if point is within rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsClickedBy(int x, int y)
        {
            Rectangle rect = new Rectangle((int)_pos.X, (int)_pos.Y, _rect.Width, _rect.Height);
            return rect.Contains(x, y);
        }
    }
}
