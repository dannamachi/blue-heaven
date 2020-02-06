using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Title
{
    // component: main title => help/credits/reset
    public class TitleComponent : IGameComponent
    {
        private TitleProcessor _processor;
        private TitleUpdater _updater;
        private TitleRenderer _renderer;
        private List<IGraphicObject> _objects;
        public TitleComponent(List<IGraphicObject> objects, IRoute router)
        {
            _processor = new TitleProcessor(objects);
            _updater = new TitleUpdater(router);
            _renderer = new TitleRenderer(objects);
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public void Setup(IGameState gameState)
        {

        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            _processor.Process(gameState);
            if (_processor.NavigationDetected)
            {
                _updater.NavigatingTo = _processor.NavigatingTo;
            }
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public string ActiveUnderState { get => "Title"; }
    }
}