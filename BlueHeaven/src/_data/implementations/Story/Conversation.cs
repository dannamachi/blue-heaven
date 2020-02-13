using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Story
{
    /// <summary>
    /// Data object for conversations
    /// </summary>
    public class Conversation : IConversation
    {
        private ConversationCode _code;
        private MilestoneCode _milestone;
        private bool _isfinished;
        private int _count;
        private List<IConversationLine> _lines;
        private List<IProvideCondition> _conditionsToGet, _conditionsToChoose;

        /// <summary>
        /// Create conversation with no conditions
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lines"></param>
        /// <param name="choiceDispenser"></param>
        public Conversation(
            ConversationCode code, 
            List<IConversationLine> lines,
            MilestoneCode mile = MilestoneCode.None)
        {
            _code = code;
            _lines = lines;
            _isfinished = false;
            _count = 0;
            _conditionsToGet = new List<IProvideCondition>();
            _conditionsToChoose = new List<IProvideCondition>();
            _milestone = mile;
        }

        /// <summary>
        /// Create conversation with conditions
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lines"></param>
        /// <param name="toGet"></param>
        /// <param name="toChoose"></param>
        /// <param name="choiceDispenser"></param>
        public Conversation(
            ConversationCode code,
            List<IConversationLine> lines,
            List<IProvideCondition> toGet,
            List<IProvideCondition> toChoose,
            MilestoneCode mile = MilestoneCode.None) : this(code,lines,mile)
        {
            SetCondition(toGet, toChoose);
        }

        public IHaveChoice GetChoiceDispenser { get => DecisionBuilder.GetChoiceDispenser(GameBundle.GetChoices(_code)); }
        public bool IsFinished { get => _isfinished; }
        public string Name { get => GameBundle.GetName(_code); }
        public ConversationCode ConCode { get => _code; }
        public MilestoneCode MileCode { get => _milestone; }
        public bool HaveChoice { get => GameBundle.GetChoices(_code) != ChoiceDispenserCode.None; }

        /// <summary>
        /// Get bool whether choice is allowed
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public bool CanChoose(IGameState gameState)
        {
            // conditions to choose
            foreach (IProvideCondition condition in _conditionsToChoose)
            {
                // if cannot choose, choose 1st choice (0) and return false
                if (!condition.IsFulfilledBy(gameState))
                {
                    if (HaveChoice)
                    {
                        GetChoiceDispenser.SetChoice(0);
                        GetChoiceDispenser.Chosen.IsChosen(gameState);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get bool whether conversation can be read at current state
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public bool CanBeRead(IGameState gameState)
        {
            if (gameState.HasConversation(_code)) return false;
            if (gameState.HasMilestone(_milestone)) return false;
            // conditions
            foreach (IProvideCondition condition in _conditionsToGet)
            {
                if (!condition.IsFulfilledBy(gameState)) return false;
            }
            return true;
        }

        /// <summary>
        /// Get bool whether conversation has the inputted name (string)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsCalled(string name)
        {
            return name.Trim() == GameBundle.GetName(_code);
        }

        /// <summary>
        /// Get bool whether conversation has the inputted name (code)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsCalled(ConversationCode code)
        {
            return code == _code;
        }

        /// <summary>
        /// Set conditions (Get,Choose) for conversation
        /// </summary>
        /// <param name="getConditions"></param>
        /// <param name="chooseConditions"></param>
        public void SetCondition(List<IProvideCondition> getConditions,List<IProvideCondition> chooseConditions)
        {
            _conditionsToGet = getConditions;
            _conditionsToChoose = chooseConditions;
        }

        /// <summary>
        /// Increment index for current conversation line, set conversation to finished once last line reached
        /// </summary>
        public void Advance()
        {
            if (_count + 1 < _lines.Count) _count += 1;
            else _isfinished = true;
        }

        /// <summary>
        /// Get current conversation line, get last line if finished
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public IConversationLine GetConversationLine(IGameState gameState)
        {
            return _lines[_count];
        }
    }
}