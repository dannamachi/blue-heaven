using System.Collections.Generic;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Components.Choice;
using BlueHeaven.src.Components.Navigation;
using BlueHeaven.src.Components.Title;
using BlueHeaven.src.Components.Help;
using BlueHeaven.src.Components.Credits;
using BlueHeaven.src.Components.Personality;
using BlueHeaven.src.Components.Graphic;
using BlueHeaven.src.Components.Reset;
using BlueHeaven.src.Components.Reload;
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
    // delegate for reset
    public delegate void VoidFunctionPointer();
    public delegate void VoidFunctionCodeParamPointer(PackageCode param);
    // root component
    public class RootComponent : IComponentMaster
    {
        private List<IGameComponent> _components;
        private RootProcessor _processor;
        private RootUpdater _updater;
        private RootRenderer _renderer;
        private IGameState _gameState;
        private IRoute _router;

        private PackageCode _currPackage;

        private GraphicsDevice _gp;
        private SpriteBatch _sb;
        private VoidFunctionPointer _resetPointer;
        private VoidFunctionCodeParamPointer _reloadPointer;
        public RootComponent(GraphicsDevice graphics, SpriteBatch sbatch)
        {
            _gp = graphics;
            _sb = sbatch;

            _resetPointer = new VoidFunctionPointer(Reset);
            _reloadPointer = new VoidFunctionCodeParamPointer(Reload);
            // current package set to Test
            _currPackage = PackageCode.Test;

            _router = new GameRouter();
            _processor = new RootProcessor();
            _updater = new RootUpdater(_router);
            _renderer = new RootRenderer();
            LoadComponents(_gp, _sb);
            LoadGame();
        }
        public bool HasEnded
        {
            get => _gameState.Finished;
        }

        private void Reload(PackageCode newPack)
        {
            _currPackage = newPack;
            Reset();
        }

        private void Reset()
        {
            _router = new GameRouter();
            _processor = new RootProcessor();
            _updater = new RootUpdater(_router);
            _renderer = new RootRenderer();
            LoadComponents(_gp, _sb);
            LoadGame();
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
            _components.Add(new GraphicComponent(sbatch));
            _components.Add(new ResetComponent(GraphicBuilder.GetGraphics("Reset"), sbatch, _resetPointer));
            _components.Add(new ReloadComponent(GraphicBuilder.GetGraphics("Reload"), sbatch, _reloadPointer));
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
                if (component is GraphicComponent) component.IsActive = true;
                if (component is ResetComponent) component.IsActive = false;
                if (component is ReloadComponent) component.IsActive = false;
            }
        }

        /// <summary>
        /// Load game data
        /// </summary>
        private void LoadGame()
        {
            // add package loader
            _gameState = new GameState();
            PackageBuilder.LoadPackage(_gameState, _currPackage);
            // set up all initial active
            // load component specific package data
            foreach (IGameComponent component in _components)
            {
                if (component.IsActive) component.Setup(_gameState);
                if (component is StoryComponent)
                {
                    PackageBuilder.LoadConversation(component as StoryComponent, _currPackage);
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