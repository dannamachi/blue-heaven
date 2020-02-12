using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Graphic
{
    /// <summary>
    /// abstract for game shapes (not content)
    /// </summary>
    public interface IShape
    {
        void Draw(SpriteBatch sbatch);
        bool IsClickedBy(int x, int y);
    }
}
