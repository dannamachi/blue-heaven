using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Enums;

namespace BlueHeaven
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RootComponent _root;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = GraphicDimension.MainWindow[0];
            graphics.PreferredBackBufferHeight = GraphicDimension.MainWindow[1];
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            List<SpriteFont> fontList = new List<SpriteFont>
            {
                Content.Load<SpriteFont>("fonts/Generic")
            };
            Dictionary<StoryGraphicCode, Texture2D> storyGraphics = new Dictionary<StoryGraphicCode, Texture2D>
            {
                { StoryGraphicCode.Mochi, Content.Load<Texture2D>("graphics/Mochi") },
                { StoryGraphicCode.MochiCrazy, Content.Load<Texture2D>("graphics/MochiCrazy") },
                { StoryGraphicCode.KingCrab, Content.Load<Texture2D>("graphics/KingCrab") },
                { StoryGraphicCode.CrazyKing, Content.Load<Texture2D>("graphics/CrazyKing") }
            };
            Dictionary<BackgroundCode, Texture2D> bgs = new Dictionary<BackgroundCode, Texture2D>
            {

            };

            // TODO: use this.Content to load your game content here
            GraphicBuilder.LoadExternalGraphic(storyGraphics, bgs);
            GameFonts.LoadFonts(fontList);
            GraphicBuilder.BuildObjects(GraphicsDevice);
            _root = new RootComponent(GraphicsDevice, spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _root.ProcessInput();
            _root.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _root.Draw();
            base.Draw(gameTime);
        }
    }
}
