using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Reset
{
    public class ResetComponent : IGameComponent
    {
        private ResetProcessor _processor;
        private ResetUpdater _updater;
        private ResetRenderer _renderer;

        public ResetComponent(List<IGraphicObject> objects, SpriteBatch sbatch, VoidFunctionPointer resetPointer)
        {
            _processor = new ResetProcessor();
            _updater = new ResetUpdater(resetPointer);
            _renderer = new ResetRenderer(objects, sbatch);
            IsActive = true;
        }

        public void Setup(IGameState gameState)
        {
            _processor.RefreshService();
            _processor.IsReset = false;
        }

        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.IsReset = _processor.IsReset;
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
        public string ActiveUnderState { get => "Setting"; }
    }
}
