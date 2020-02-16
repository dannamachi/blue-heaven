using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Story
{
    // data: conversation line
    public class ConversationLine : IConversationLine
    {
        private BackgroundCode _bg;
        private StoryGraphicCode _graphic;
        private bool _isfinished;
        private int _count;
        private string _speaker;
        private List<string> _sentences;
        public ConversationLine(
            string speaker, 
            List<string> sentences, 
            StoryGraphicCode code = StoryGraphicCode.Default,
            BackgroundCode bg = BackgroundCode.Default)
        {
            _graphic = code;
            _bg = bg;
            _speaker = speaker;
            _sentences = sentences;
            _count = 0;
            _isfinished = false;
        }

        public BackgroundCode Background { get => _bg; }
        public StoryGraphicCode GraphicCode { get => _graphic; }
        public string Speaker { get => _speaker; }
        public string Sentence
        {
            get
            {
                if (_count < _sentences.Count) _count += 1;
                else _isfinished = true;
                return _sentences[_count - 1];
            }
        }
        public bool IsFinished { get => _isfinished; }
    }
}