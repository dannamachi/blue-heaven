using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // abstract: container of game data
    public interface IGameState
    {
        // current choice dispenser
        IHaveChoice ChoiceDispenser { get; set; }
        // bool whether user has indicated next line
        bool NextLine { get; set; }
        // current conversation to show
        IConversation Conversation { get; set; }
        // find character by name
        ICharacter GetCharacter(string name);
        // bool wheather there is (readable) conversation left
        bool Finished { get; set; }
        // list of finished conversations
        List<IConversation> FinishedConversations { get; }
        // bool whether has finished a conversation
        bool HasConversation(string name);
        // current character open for editing
        ICharacter EditingCharacter { get; }
        // changing which parameter of personality
        int EditingIndex { get; set; }
        // bool whether editing is allowed
        bool Editable { get; set; }
    }
}