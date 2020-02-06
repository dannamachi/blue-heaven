using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Choice
{
    // component: component for choices
    public class ChoiceComponent : IGameComponent
    {
        private ChoiceProcessor _processor;
        private ChoiceUpdater _updater;
        private ChoiceRenderer _renderer;
        private bool _isactive;
        public ChoiceComponent(List<IGraphicObject> objects, IRoute router)
        {
            _processor = new ChoiceProcessor(objects);
            _updater = new ChoiceUpdater(router);
            _renderer = new ChoiceRenderer(objects);
            _isactive = true;
        }
        public void Setup(IGameState gameState)
        {

        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            if (_processor.HoveringDetected) _renderer.Hovering = _processor.Hovering;
            if (_processor.ChosenDetected) _updater.Chosen = _processor.Chosen;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Choosing"; }
    }
}