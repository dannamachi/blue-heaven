using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Navigation
{
    // component: go to different statebeacon of the game
    public class NavigationComponent : IGameComponent
    {
        private NavigationProcessor _processor;
        private NavigationUpdater _updater;
        private NavigationRenderer _renderer;

        public NavigationComponent(List<IGraphicObject> objects, IRoute router, SpriteBatch sbatch)
        {
            _processor = new NavigationProcessor();
            _updater = new NavigationUpdater(router);
            _renderer = new NavigationRenderer(objects,sbatch);
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public void Setup(IGameState gameState)
        {
            _processor.RefreshService();
        }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.NavigatingTo = _processor.NavigatingTo;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            _renderer.CurrentState = _updater.CurrentState;
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public string ActiveUnderState { get => "Root"; }
    }
}