using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Reload
{
    /// <summary>
    /// Component to reload game based on package code
    /// </summary>
    public class ReloadComponent : IGameComponent
    {
        private ReloadProcessor _processor;
        private ReloadUpdater _updater;
        private ReloadRenderer _renderer;
        public ReloadComponent(List<IGraphicObject> objects, SpriteBatch sbatch, VoidFunctionCodeParamPointer reloadPointer)
        {
            _processor = new ReloadProcessor();
            _updater = new ReloadUpdater(reloadPointer);
            _renderer = new ReloadRenderer(objects, sbatch);
        }
        public void Setup(IGameState gameState)
        {
            _processor.RefreshService();
        }

        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            if (_processor.IsClicked)
            {
                _updater.Code = _processor.Code;
                _processor.IsClicked = false;
            }
            _renderer.CurrentString = _processor.CurrentString;
            _renderer.Invalid = _processor.Invalid;
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
        public string ActiveUnderState { get => "Reload"; }
    }
}
