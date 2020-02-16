using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Graphic
{
    /// <summary>
    /// Component for drawing story graphic
    /// </summary>
    public class GraphicComponent : IGameComponent
    {
        private GraphicProcessor _processor;
        private GraphicUpdater _updater;
        private GraphicRenderer _renderer;
        public GraphicComponent(SpriteBatch sbatch)
        {
            _processor = new GraphicProcessor();
            _updater = new GraphicUpdater();
            _renderer = new GraphicRenderer(sbatch);
            IsActive = true;
        }
        public void Setup(IGameState gameState)
        {
            _updater.CurrentBackground = BackgroundCode.Default;
            _updater.CurrentGraphic = StoryGraphicCode.Default;
        }

        public void ProcessInput(IGameState gameState)
        {
            _processor.Process(gameState);
            _updater.CurrentLine = CurrentLine;
        }

        public void Update(IGameState gameState)
        {
            _updater.Update(gameState);
            _renderer.CurrentBackground = _updater.CurrentBackground;
            _renderer.CurrentGraphic = _updater.CurrentGraphic;
        }

        public void Draw(IGameState gameState)
        {
            _renderer.Draw(gameState);
        }

        public bool IsActive { get; set; }

        public string ActiveUnderState { get => "Reading/Story"; }

        public IConversationLine CurrentLine { get; set; }
    }
}
