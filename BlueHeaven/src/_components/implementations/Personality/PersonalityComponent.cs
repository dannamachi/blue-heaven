using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Personality
{
    // component for changing personality
    public class PersonalityComponent : IGameComponent
    {
        private PersonalityProcessor _processor;
        private PersonalityUpdater _updater;
        private PersonalityRenderer _renderer;
        private List<IGraphicObject> _objects;
        public PersonalityComponent(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _processor = new PersonalityProcessor();
            _updater = new PersonalityUpdater();
            _renderer = new PersonalityRenderer(objects,sbatch);
            IsActive = true;
            RefreshActive();
        }
        public void Setup(IGameState gameState)
        {
            _processor.RefreshService();
        }
        public void RefreshActive()
        {
            _processor.Activated = true;
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Setting"; }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.EditingIndex = _processor.EditingIndex;
        }
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
        }
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }
    }
}