using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Help
{
    public class HelpComponent : IGameComponent
    {
        private HelpProcessor _processor;
        private HelpUpdater _updater;
        private HelpRenderer _renderer;
        private InfoService _info;

        public HelpComponent(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _info = new InfoService("HELP", 7);
            _processor = new HelpProcessor();
            _updater = new HelpUpdater(_info);
            _renderer = new HelpRenderer(objects, sbatch, _info);

        }
        public void Setup(IGameState gameState)
        {
            _info = new InfoService("HELP",7);
            _updater.RefreshService(_info);
            _renderer.RefreshService(_info);
            _processor.RefreshService();
            _processor.Hovering = -1;
        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.UpPage = _processor.UpPage;
            _updater.DownPage = _processor.DownPage;
            _renderer.Hovering = _processor.Hovering;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            _updater.UpPage = false;
            _updater.DownPage = false;
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
            _renderer.Hovering = -1;
        }
        public bool IsActive { get; set; }

        public string ActiveUnderState { get => "Help"; }
    }
}
