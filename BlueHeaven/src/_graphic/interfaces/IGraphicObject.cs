using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Graphic
{
    /// <summary>
    /// General object that draws itself, detects clicking and can be re/deactivated
    /// </summary>
    public interface IGraphicObject
    {
        void Draw(SpriteBatch sbatch);
        bool IsAlternate { get; set; }
        bool IsClicked(int x, int y);
        bool IsCalled(string id);
        bool IsActive { get; set; }
    }
}