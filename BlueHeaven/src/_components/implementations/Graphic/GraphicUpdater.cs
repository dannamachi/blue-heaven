using BlueHeaven.src.Data;
using BlueHeaven.src.Components;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Components.Graphic
{
    /// <summary>
    /// Updates story graphic & background
    /// </summary>
    public class GraphicUpdater : IStateUpdater
    {
        public GraphicUpdater()
        {
            CurrentLine = null;
            CurrentGraphic = StoryGraphicCode.Default;
            CurrentBackground = BackgroundCode.Default;
            IsChoice = false;
        }

        public void Update(IGameState gameState)
        {
            if (CurrentLine != null)
            {
                CurrentGraphic = CurrentLine.GraphicCode;
                CurrentBackground = CurrentLine.Background;
            }
            else if (!IsChoice)
            {
                CurrentGraphic = StoryGraphicCode.Default;
                CurrentBackground = BackgroundCode.Default;
            }
        }

        public IConversationLine CurrentLine { get; set; }

        public StoryGraphicCode CurrentGraphic { get; set; }

        public BackgroundCode CurrentBackground { get; set; }

        public bool IsChoice { get; set; }
    }
}
