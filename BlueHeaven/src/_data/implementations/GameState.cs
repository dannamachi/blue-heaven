using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // data: game data
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

        // next routed state of the game
        public int NavigatingTo { get; set; }
        // current routed state of the game
        public IShowState StateBeacon { get; set; }
        // current choice dispenser
        public IHaveChoice ChoiceDispenser { get; set; }
        // bool whether user has indicated next line
        public bool NextLine { get; set; }
        // current conversation to show
        public IConversation Conversation { get; set; }
        // find character by name
        public ICharacter GetCharacter(string name)
        {
            foreach (ICharacter character in _characters)
            {
                if (character.IsCalled(name)) return character;
            }
            return null;
        }
        // bool wheather there is (readable) conversation left
        public bool Finished { get; set; }
        // list of finished conversations
        public List<IConversation> FinishedConversations { get => _finishedConversations; }
        // bool whether has finished a conversation
        public bool HasConversation(string name)
        {
            foreach (IConversation conversation in _finishedConversations)
            {
                if (conversation.IsCalled(name)) return true;
            }
            return false;
        }
        // current character open for editing
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
        // changing which parameter of personality
        public int EditingIndex { get; set; }
        // bool whether editing is allowed
        public bool Editable { get; set; }
    }

}