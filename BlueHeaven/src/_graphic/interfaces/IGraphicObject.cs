namespace BlueHeaven.src.Graphic
{
    // abstract: general object that draws itself
    public interface IGraphicObject
    {
        void Draw();
        void DrawAlternate();
        bool IsClicked();
        bool IsCalled(string id);
        bool IsActive { get; set; }
    }
}