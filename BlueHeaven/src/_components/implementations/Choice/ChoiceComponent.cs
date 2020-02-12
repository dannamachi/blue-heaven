using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Data;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Choice
{
    /// <summary>
    /// Choice component
    /// </summary>
    public class ChoiceComponent : IGameComponent
    {
        private ChoiceProcessor _processor;
        private ChoiceUpdater _updater;
        private ChoiceRenderer _renderer;
        public ChoiceComponent(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _processor = new ChoiceProcessor();
            _updater = new ChoiceUpdater();
            _renderer = new ChoiceRenderer(objects, sbatch);
            IsActive = true;
            Chosen = false;
        }
        public void Setup(IGameState gameState)
        {
            Chosen = false;
            _processor.RefreshService();
        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _renderer.Hovering = _processor.Hovering;
            if (_processor.ChosenDetected) _updater.Chosen = _processor.Chosen;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            Chosen = _updater.Chosen != -1;
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Choosing"; }
        public bool Chosen { get; set; }
    }
}