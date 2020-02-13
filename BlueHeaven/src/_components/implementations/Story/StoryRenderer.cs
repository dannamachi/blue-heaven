using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Components.Story
{
    /// <summary>
    /// Draw graphic for story component
    /// </summary>
    public class StoryRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private SpriteBatch _sbatch;
        private IConversationLine _line;
        private string _sentence,_speaker;
        public StoryRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _objects = objects;
            _sbatch = sbatch;
            Finished = false;
            NextLine = false;
        }

        /// <summary>
        /// Draw story box
        /// </summary>
        /// <param name="gameState"></param>
        public void Draw(IGameState gameState)
        {
            // draw box(es)
            foreach (IGraphicObject object1 in _objects)
            {
                object1.Draw(_sbatch);
            }
            // draw story text
            if (NextLine)
            {
                _sentence = _line.Sentence;
                _speaker = _line.Speaker;
                NextLine = false;
            }
            if (_speaker == null)
            {
                if (CurrentLine == null)
                {
                    _speaker = "";
                    _sentence = "Press to start =>";
                }
                else
                {
                    _speaker = CurrentLine.Speaker;
                    _sentence = CurrentLine.Sentence;
                }
            }
            if (!Finished)
            {
                CommonUtilities.DrawFont(
                    _speaker,
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.SpeakerFrame),
                    Color.Black,
                    _sbatch);
                CommonUtilities.DrawFont(
                    _sentence,
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.TextFrame),
                    Color.Black,
                    _sbatch);
            }
            else
                CommonUtilities.DrawFont(
                    "Story is finished.",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.TextFrame),
                    Color.Black,
                    _sbatch);

            if (CurrentLine != null && CurrentLine.IsFinished) _speaker = null;
        }

        public bool NextLine { get; set; }

        public IConversationLine CurrentLine
        {
            get => _line;
            set => _line = value;
        }

        public bool Finished { get; set; }
    }
}