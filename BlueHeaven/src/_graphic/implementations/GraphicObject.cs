using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Graphic
{
    // graphic: object that can draw itself
    public class GraphicObject : IGraphicObject
    {
        private string _name;
        private IShape _shape, _shapeAlt;
        public GraphicObject(string name, IShape shape1, IShape shape2 = null) // pass in 2 ways of drawing??
        {
            _name = name;
            IsActive = true;
            IsAlternate = false;
            _shape = shape1;
            _shapeAlt = shape2;
        }
        public void Draw(SpriteBatch sbatch)
        {
            if (IsAlternate && _shapeAlt != null) _shapeAlt.Draw(sbatch);
            else _shape.Draw(sbatch);
        }
        public bool IsClicked(int mousex, int mousey)
        {
            if (!IsActive) return false;
            return _shape.IsClickedBy(mousex, mousey);
        }
        public bool IsCalled(string id)
        {
            return id.Trim() == _name.Trim();
        }
        public bool IsActive { get; set; }
        public bool IsAlternate { get; set; }
    }
}