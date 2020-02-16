using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;
using BlueHeaven.src.Services;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Story
{
    /// <summary>
    /// Story component
    /// </summary>
    public class StoryComponent : IGameComponent
    {
        private StoryProcessor _processor;
        private StoryUpdater _updater;
        private StoryRenderer _renderer;

        public StoryComponent(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _processor = new StoryProcessor();
            _updater = new StoryUpdater(new List<ConversationCode>());
            _renderer = new StoryRenderer(objects, sbatch);
            IsActive = true;
            Choosing = false;
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Reading/Story"; }

        public void SetConversation(List<ConversationCode> convos)
        {
            _updater.SetConversations(convos);
        }

        public bool NewConversation { get => _updater.NewConversation; }

        /// <summary>
        /// Call when story is resumed
        /// </summary>
        /// <param name="gameState"></param>
        public void Setup(IGameState gameState)
        {
            Choosing = false;
            _processor.NextLine = true;
            _processor.RefreshService();
            _updater.NextLine = true;
            _updater.Choosing = false;
        }

        /// <summary>
        /// Process clicking
        /// </summary>
        /// <param name="gameState"></param>
        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.NextLine = _processor.NextLine;
        }

        /// <summary>
        /// Update clicking
        /// </summary>
        /// <param name="gameState"></param>
        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            Choosing = _updater.Choosing;
            _renderer.Finished = _updater.Finished;
            if (_updater.DetectChangeLine)
            {
                _renderer.CurrentLine = _updater.CurrentLine;
                _updater.DetectChangeLine = false;
            }
            _renderer.NextLine = _updater.NextLine;
            _processor.Finished = _updater.Finished;
        }

        /// <summary>
        /// Renders story
        /// </summary>
        /// <param name="gameState"></param>
        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
            _processor.NextLine = false;
            _updater.NextLine = false;
        }
        
        public bool Choosing { get; set; }

        public IConversationLine CurrentLine { get => _updater.CurrentLine; }
    }
}