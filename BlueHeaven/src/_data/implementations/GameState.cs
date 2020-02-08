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
        private List<IConversation> _finishedConversations;
        private Dictionary<string, string> _editingList;
        public GameState()
        {
            _characters = new List<ICharacter>();
            _finishedConversations = new List<IConversation>();
            _editingList = new Dictionary<string, string>(); // map conversation to editable character
                                                             // add builder
        }

        // TO REMOVE: next routed state of the game
        public int NavigatingTo { get; set; }

        /// <summary>
        /// Get current choice dispenser
        /// </summary>
        public IHaveChoice ChoiceDispenser { get; set; }


        // TO REMOVE: bool whether user has indicated next line
        public bool NextLine { get; set; }

        /// <summary>
        /// Get current conversation
        /// </summary>
        public IConversation Conversation { get; set; }

        // TO FIX: get character by name (string)
        public ICharacter GetCharacter(string name)
        {
            foreach (ICharacter character in _characters)
            {
                if (character.IsCalled(name)) return character;
            }
            return null;
        }

        /// <summary>
        /// Get bool if there is no readable conversation to fetch
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Get list of finished conversations
        /// </summary>
        public List<IConversation> FinishedConversations { get => _finishedConversations; }

        /// <summary>
        /// Get bool if a conversation is finished (using code)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool HasConversation(ConversationCode code)
        {
            foreach (IConversation conversation in _finishedConversations)
            {
                if (conversation.IsCalled(code)) return true;
            }
            return false;
        }

        // TO REMOVE: current character open for editing
        public ICharacter EditingCharacter
        {
            get
            {
                if (Conversation != null)
                {
                    if (_editingList.ContainsKey(Conversation.Name)) return GetCharacter(_editingList[Conversation.Name]);
                }
                return null;
            }
        }

        // TO REMOVE: changing which parameter of personality
        public int EditingIndex { get; set; }

        /// <summary>
        /// Get bool if editing is allowed at current conversation
        /// </summary>
        public bool Editable { get; set; }
    }

}