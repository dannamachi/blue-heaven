using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Navigation
{
    // component: go to different statebeacon of the game
    public class NavigationComponent : IGameComponent
    {
        private NavigationProcessor _processor;
        private NavigationUpdater _updater;
        private NavigationRenderer _renderer;
        private List<IGraphicObject> _objects;
        public NavigationComponent(List<IGraphicObject> objects, IRoute router)
        {
            _processor = new NavigationProcessor(objects);
            _updater = new NavigationUpdater(router);
            _renderer = new NavigationRenderer(objects, router);
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public void Setup(IGameState gameState)
        {

        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            if (_processor.NavigationDetected)
            {
                _updater.NavigatingTo = _processor.NavigatingTo;
            }
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public string ActiveUnderState { get => "Root"; }
    }
}