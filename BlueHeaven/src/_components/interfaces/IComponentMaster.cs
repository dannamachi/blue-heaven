namespace BlueHeaven.src.Components
{
    // abstract: root component
    public interface IComponentMaster
    {
        void ProcessInput();
        void Update();
        void Draw();
    }
}