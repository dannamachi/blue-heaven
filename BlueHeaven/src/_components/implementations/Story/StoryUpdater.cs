using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using BlueHeaven.src.Components;

namespace BlueHeaven.src.Components.Story
{
    /// <summary>
    /// Get next line if prompted
    /// </summary>
    public class StoryUpdater : IStateUpdater
    {
        private List<ConversationCode> _conversations;
        public StoryUpdater(List<ConversationCode> codes)
        {
            _conversations = codes;
            NextLine = false;
            Choosing = false;
            Finished = false;
            DetectChangeLine = false;
        }

        public void SetConversations(List<ConversationCode> codes)
        {
            _conversations = codes;
        }
        
        /// <summary>
        /// Get next conversation or switch to choosing
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        private IConversation GetNextConversation(IGameState gameState)
        {
            // switch to choice if have choice
            if (gameState.Conversation.HaveChoice)
            {
                if (gameState.Conversation.CanChoose(gameState))
                {
                    gameState.ChoiceDispenser = gameState.Conversation.GetChoiceDispenser;
                    Choosing = true;
                }
                else
                {
                    Choosing = false;
                    return GetConversation(gameState);
                }
            }
            // else get next readable conversation
            else
            {
                return GetConversation(gameState);
            }
            return null;
        }

        /// <summary>
        /// Get next conversation
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        private IConversation GetConversation(IGameState gameState)
        {
            foreach (ConversationCode code in _conversations)
            {
                IConversation fetched = StoryBuilder.GetConversation(code);
                if (fetched != null)
                {
                    if (fetched.CanBeRead(gameState)) return fetched;
                }
            }
            return null;
        }

        /// <summary>
        /// Update conversation
        /// </summary>
        /// <param name="gameState"></param>
        public void Update(IGameState gameState)
        {
            // update convo
            if (gameState.Conversation == null)
            {
                gameState.Conversation = GetConversation(gameState);
                if (gameState.Conversation != null)
                {
                    CurrentLine = gameState.Conversation.GetConversationLine(gameState);
                    DetectChangeLine = true;
                }
            }
            // update line
            if (CurrentLine == null) Finished = true;
            else if (CurrentLine.IsFinished && !Finished)
            {
                DetectChangeLine = true;
                if (gameState.Conversation == null)
                {
                    Finished = true;
                }
                else if (gameState.Conversation.IsFinished)
                {
                    gameState.FinishConversation(gameState.Conversation);
                    gameState.Conversation = GetNextConversation(gameState);
                }
                else
                {
                    gameState.Conversation.Advance();
                }
                if (gameState.Conversation != null) CurrentLine = gameState.Conversation.GetConversationLine(gameState);
            }

            Finished = (gameState.Conversation == null) && (Choosing == false);
        }

        public IConversationLine CurrentLine { get; set; }

        public bool DetectChangeLine { get; set; }

        public bool NextLine { get; set; }

        public bool Choosing { get; set; }

        public bool Finished { get; set; }
    }
}