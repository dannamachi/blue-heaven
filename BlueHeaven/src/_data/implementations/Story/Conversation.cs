using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Story
{
    // data: conversation
    public class Conversation : IConversation
    {
        private IHaveChoice _choiceDispenser;
        private bool _isfinished;
        private int _count;
        private string _name;
        private List<IConversationLine> _lines;
        private List<IProvideCondition> _conditionsToGet, _conditionsToChoose;
        public Conversation(string name, List<IConversationLine> lines, IHaveChoice choiceDispenser = null)
        {
            _choiceDispenser = choiceDispenser;
            _name = name;
            _lines = lines;
            _isfinished = false;
            _count = 0;
            _conditionsToGet = new List<IProvideCondition>();
            _conditionsToChoose = new List<IProvideCondition>();
        }
        public IHaveChoice GetChoiceDispenser { get => _choiceDispenser; }
        public bool IsFinished { get => _isfinished; }
        public string Name { get => _name; }
        public bool HaveChoice { get => _choiceDispenser != null; }
        public bool CanChoose(IGameState gameState)
        {
            // conditions
            foreach (IProvideCondition condition in _conditionsToChoose)
            {
                if (!condition.IsFulfilledBy(gameState)) return false;
            }
            return true;
        }
        public bool CanBeRead(IGameState gameState)
        {
            // conditions
            foreach (IProvideCondition condition in _conditionsToGet)
            {
                if (!condition.IsFulfilledBy(gameState)) return false;
            }
            return true;
        }
        public bool IsCalled(string name)
        {
            return name.Trim() == _name.Trim();
        }
        public void SetConditions(List<IProvideCondition> getConditions,List<IProvideCondition> chooseConditions)
        {
            _conditionsToGet = getConditions;
            _conditionsToChoose = chooseConditions;
        }
        public void Advance()
        {
            if (_count + 1 < _lines.Count) _count += 1;
            else _isfinished = true;
        }
        public IConversationLine GetConversationLine(IGameState gameState)
        {
            return _lines[_count];
        }
    }
}