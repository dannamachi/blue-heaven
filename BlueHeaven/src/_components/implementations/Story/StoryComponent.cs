using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Components.Story
{
    // component: shows the conversation and speaker's name
    public class StoryComponent : IGameComponent
    {
        private StoryProcessor _processor;
        private StoryUpdater _updater;
        private StoryRenderer _renderer;
        private List<IGraphicObject> _objects;
        public StoryComponent(List<ConversationCode> codes, List<IGraphicObject> objects, IRoute router)
        {
            _processor = new StoryProcessor();
            _updater = new StoryUpdater(codes, router);
            _renderer = new StoryRenderer(objects);
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public string ActiveUnderState { get => "Reading"; }
        public void Setup(IGameState gameState)
        {

        }
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