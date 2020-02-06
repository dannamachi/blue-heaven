using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Story
{
    // data: conversation line
    public class ConversationLine : IConversationLine
    {
        private bool _isfinished;
        private int _count;
        private string _name, _speaker;
        private List<string> _sentences;
        public ConversationLine(string speaker, List<string> sentences, string name = "Line Nth")
        {
            _name = name;
            _speaker = speaker;
            _sentences = sentences;
            _count = 0;
            _isfinished = false;
        }
        public bool IsCalled(string name)
        {
            return name.Trim() == _name.Trim();
        }
        public string Speaker { get => _speaker; }
        public string Sentence
        {
            get
            {
                if (_count + 1 < _sentences.Count) _count += 1;
                else _isfinished = true;
                return _sentences[_count];
            }
        }
    }
}