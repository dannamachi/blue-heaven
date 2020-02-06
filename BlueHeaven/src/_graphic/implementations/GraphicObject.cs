namespace BlueHeaven.src.Graphic
{
    // graphic: object that can draw itself
    public class GraphicObject : IGraphicObject
    {
        private string _name;
        private int[] _drawRect;
        public GraphicObject(string name, int[] drawRect) // pass in 2 ways of drawing??
        {
            _name = name;
            _drawRect = drawRect;
            IsActive = true;
        }
        public void Draw()
        {
            // draw code
        }
        public void DrawAlternate()
        {
            // draw code for alt form
        }
        public bool IsClicked()
        {
            // check mouse is within draw rect
            // false if not IsActive
            return true;
        }
        public bool IsCalled(string id)
        {
            return id.Trim() == _name.Trim();
        }
        public bool IsActive { get; set; }
    }
}