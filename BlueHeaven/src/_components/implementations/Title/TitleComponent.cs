using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Title
{
    // component: main title => help/credits/reload
    public class TitleComponent : IGameComponent
    {
        private TitleProcessor _processor;
        private TitleUpdater _updater;
        private TitleRenderer _renderer;
        private List<IGraphicObject> _objects;
        public TitleComponent(List<IGraphicObject> objects, IRoute router, SpriteBatch sbatch)
        {
            _processor = new TitleProcessor();
            _updater = new TitleUpdater(router);
            _renderer = new TitleRenderer(objects,sbatch);
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
            _renderer.Hovering = _processor.Hovering;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            _processor.Process(gameState);
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
        public string ActiveUnderState { get => "Title"; }
    }
}