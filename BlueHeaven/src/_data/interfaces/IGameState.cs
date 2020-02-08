using System.Collections.Generic;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    /// <summary>
    /// Data object for (strictly) game data (abstract)
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Get current choice dispenser
        /// </summary>
        IHaveChoice ChoiceDispenser { get; set; }

        // TO REMOVE: bool whether user has indicated next line
        bool NextLine { get; set; }

        /// <summary>
        /// Get current conversation
        /// </summary>
        IConversation Conversation { get; set; }

        // TO FIX: get character by name (string)
        ICharacter GetCharacter(string name);

        /// <summary>
        /// Get bool if there is no readable conversation to fetch
        /// </summary>
        bool Finished { get; set; }

        /// <summary>
        /// Get list of finished conversations
        /// </summary>
        List<IConversation> FinishedConversations { get; }

        /// <summary>
        /// Get bool if a conversation is finished (using code)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool HasConversation(ConversationCode code);

        // TO REMOVE: current character open for editing
        ICharacter EditingCharacter { get; }

        // TO REMOVE: changing which parameter of personality
        int EditingIndex { get; set; }

        /// <summary>
        /// Get bool if editing is allowed at current conversation
        /// </summary>
        bool Editable { get; set; }
    }
}