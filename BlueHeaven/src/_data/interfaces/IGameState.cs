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
        /// Load data from Package
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="editing"></param>
        void LoadData(List<ICharacter> characters, Dictionary<ConversationCode, CharacterCode> editing);
        
        /// <summary>
        /// Get current choice dispenser
        /// </summary>
        IHaveChoice ChoiceDispenser { get; set; }

        /// <summary>
        /// Get current conversation
        /// </summary>
        IConversation Conversation { get; set; }

        // TO FIX: get character by name (string)
        ICharacter GetCharacter(CharacterCode charCode);

        /// <summary>
        /// Get bool if there is no readable conversation to fetch
        /// </summary>
        bool Finished { get; set; }

        /// <summary>
        /// Add conversation to finished list
        /// </summary>
        /// <param name="code"></param>
        void FinishConversation(IConversation convo);

        /// <summary>
        /// Get bool if a conversation is finished (using code)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool HasConversation(ConversationCode code);

        /// <summary>
        /// Get bool if a milestone has been reached
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool HasMilestone(MilestoneCode code);
        
        /// <summary>
        /// Get character open for editing
        /// </summary>
        ICharacter EditingCharacter { get; }

        /// <summary>
        /// Get bool if editing is allowed at current conversation
        /// </summary>
        bool Editable { get; }
    }
}