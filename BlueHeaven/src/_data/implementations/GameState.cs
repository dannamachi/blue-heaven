using System.Collections.Generic;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    /// <summary>
    /// Data object for (strictly) game data
    /// </summary>
    public class GameState : IGameState
    {
        private List<ICharacter> _characters;
        private List<ConversationCode> _finishedConversations;
        private Dictionary<ConversationCode, CharacterCode> _editingList;
        private List<MilestoneCode> _milestones;
        public GameState() { }

        /// <summary>
        /// Load data from Package
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="editing"></param>
        public void LoadData(List<ICharacter> characters, Dictionary<ConversationCode, CharacterCode> editing)
        {
            _characters = characters;
            _finishedConversations = new List<ConversationCode>();
            _editingList = editing; // map conversation to editable character
            _milestones = new List<MilestoneCode>();
        }

        /// <summary>
        /// Get current choice dispenser
        /// </summary>
        public IHaveChoice ChoiceDispenser { get; set; }

        /// <summary>
        /// Get current conversation
        /// </summary>
        public IConversation Conversation { get; set; }

        // TO FIX: get character by name (string)
        public ICharacter GetCharacter(CharacterCode charCode)
        {
            foreach (ICharacter character in _characters)
            {
                if (character.IsCalled(charCode)) return character;
            }
            return null;
        }

        /// <summary>
        /// Get bool if there is no readable conversation to fetch
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Add finished convo to finished list
        /// </summary>
        /// <param name="code"></param>
        public void FinishConversation(IConversation convo)
        {
            _finishedConversations.Add(convo.ConCode);
            if (convo.MileCode != MilestoneCode.None) _milestones.Add(convo.MileCode);
        }

        /// <summary>
        /// Get bool if a conversation is finished (using code)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool HasConversation(ConversationCode code)
        {
            foreach (ConversationCode conversation in _finishedConversations)
            {
                if (conversation == code) return true;
            }
            return false;
        }

        /// <summary>
        /// Get bool is milestone has been reached
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool HasMilestone(MilestoneCode code)
        {
            if (code == MilestoneCode.None) return false;
            return _milestones.Contains(code);
        }

        /// <summary>
        /// Get current character that is being edited
        /// </summary>
        public ICharacter EditingCharacter
        {
            get
            {
                if (Conversation != null)
                {
                    if (_editingList.ContainsKey(Conversation.ConCode)) return GetCharacter(_editingList[Conversation.ConCode]);
                }
                return null;
            }
        }

        // TO REMOVE: changing which parameter of personality
        public int EditingIndex { get; set; }

        /// <summary>
        /// Get bool if editing is allowed at current conversation
        /// </summary>
        public bool Editable
        {
            get
            {
                if (Conversation == null) return false;
                return _editingList.ContainsKey(Conversation.ConCode);
            }
        }
    }

}