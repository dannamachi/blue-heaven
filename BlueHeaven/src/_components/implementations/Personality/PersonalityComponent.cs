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
            _processor = new PersonalityProcessor(objects);
            _updater = new PersonalityUpdater();
            _renderer = new PersonalityRenderer(objects,sbatch);
            IsActive = true;
        }
        public void Setup(IGameState gameState)
        {
            gameState.Editable = (gameState.EditingCharacter != null);
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Editing"; }
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
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