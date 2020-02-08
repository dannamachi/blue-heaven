using System.Collections.Generic;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Components.Choice;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;

/// <summary>
/// Main program component
/// </summary>
namespace BlueHeaven.src.Components
{
    // root component
    public class RootComponent : IComponentMaster
    {
        private List<IGameComponent> _components;
        private RootProcessor _processor;
        private RootUpdater _updater;
        private RootRenderer _renderer;
        private IGameState _gameState;
        private IRoute _router;
        public RootComponent()
        {
            LoadComponents();
            LoadGame();
            _router = new GameRouter();
            _processor = new RootProcessor();
            _updater = new RootUpdater(_router);
            _renderer = new RootRenderer();
        }
        public bool HasEnded
        {
            get => _gameState.Finished;
        }

        /// <summary>
        /// Load all sub components
        /// </summary>
        private void LoadComponents()
        {
            // add component builders
            _components = new List<IGameComponent>();
            _components.Add(new StoryComponent(new List<ConversationCode>(),new List<IGraphicObject>(),_router));
            _components.Add(new ChoiceComponent(new List<IGraphicObject>(),_router));
            // initial active status
            foreach (IGameComponent component in _components)
            {
                if (component is StoryComponent) component.IsActive = true;
                if (component is ChoiceComponent) component.IsActive = false;
            }
        }

        /// <summary>
        /// Load game data
        /// </summary>
        private void LoadGame()
        {
            // add game builder
            _gameState = new GameState();
        }

        /// <summary>
        /// Process user inputs
        /// </summary>
        public void ProcessInput()
        {
            _processor.Process(_components, _gameState);
        }

        /// <summary>
        /// Update program
        /// </summary>
        public void Update()
        {
            _updater.Update(_components, _gameState);
        }

        /// <summary>
        /// Draw program graphic
        /// </summary>
        public void Draw()
        {
            _renderer.Draw(_components, _gameState);
        }
    }
}