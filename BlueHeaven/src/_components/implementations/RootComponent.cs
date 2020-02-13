using System.Collections.Generic;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Components.Choice;
using BlueHeaven.src.Components.Navigation;
using BlueHeaven.src.Components.Title;
using BlueHeaven.src.Components.Help;
using BlueHeaven.src.Components.Credits;
using BlueHeaven.src.Components.Personality;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Package;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework.Graphics;

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
        public RootComponent(GraphicsDevice graphics, SpriteBatch sbatch)
        {
            _router = new GameRouter();
            _processor = new RootProcessor();
            _updater = new RootUpdater(_router);
            _renderer = new RootRenderer();
            LoadComponents(graphics, sbatch);
            LoadGame();
        }
        public bool HasEnded
        {
            get => _gameState.Finished;
        }

        /// <summary>
        /// Load all sub components
        /// </summary>
        private void LoadComponents(GraphicsDevice graphics, SpriteBatch sbatch)
        {
            // add component builders
            _components = new List<IGameComponent>();
            _components.Add(new StoryComponent(GraphicBuilder.GetGraphics("Story"), sbatch));
            _components.Add(new ChoiceComponent(GraphicBuilder.GetGraphics("Choice"), sbatch));
            _components.Add(new NavigationComponent(GraphicBuilder.GetGraphics("Navigation"), _router, sbatch));
            _components.Add(new TitleComponent(GraphicBuilder.GetGraphics("Title"), _router, sbatch));
            _components.Add(new HelpComponent(GraphicBuilder.GetGraphics("Info"), sbatch));
            _components.Add(new CreditsComponent(GraphicBuilder.GetGraphics("Info"), sbatch));
            _components.Add(new PersonalityComponent(GraphicBuilder.GetGraphics("Personality"), sbatch));
            // initial active status
            foreach (IGameComponent component in _components)
            {
                if (component is StoryComponent) component.IsActive = false;
                if (component is ChoiceComponent) component.IsActive = false;
                if (component is NavigationComponent) component.IsActive = true;
                if (component is TitleComponent) component.IsActive = true;
                if (component is HelpComponent) component.IsActive = false;
                if (component is CreditsComponent) component.IsActive = false;
                if (component is PersonalityComponent) component.IsActive = false;
            }
        }

        /// <summary>
        /// Load game data
        /// </summary>
        private void LoadGame()
        {
            // current package set to Test
            PackageCode currPackage = PackageCode.Test;
            // add package loader
            _gameState = new GameState();
            PackageBuilder.LoadPackage(_gameState, currPackage);
            // set up all initial active
            // load component specific package data
            foreach (IGameComponent component in _components)
            {
                if (component.IsActive) component.Setup(_gameState);
                if (component is StoryComponent)
                {
                    PackageBuilder.LoadConversation(component as StoryComponent, currPackage);
                }
            }
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