using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using BlueHeaven.src.Components;
namespace BlueHeaven.src.Components.Story
{
    // updater: get next line if prompted (clicking)
    public class StoryUpdater : IStateUpdater
    {
        private IRoute _router;
        private List<ConversationCode> _conversations;
        public StoryUpdater(List<ConversationCode> codes, IRoute router)
        {
            _conversations = codes;
            _router = router;
        }
        // add branching later
        private IConversation GetNextConversation(IGameState gameState)
        {
            // switch to choice if have choice
            if (gameState.Conversation.HaveChoice && gameState.Conversation.CanChoose(gameState))
            {
                _router.RouteTo("Choosing");
                gameState.ChoiceDispenser = gameState.Conversation.GetChoiceDispenser;
            }
            // else get next readable conversation
            else
            {
                foreach (ConversationCode code in _conversations)
                {
                    IConversation fetched = StoryBuilder.GetConversation(code);
                    if (fetched != null)
                    {
                        if (fetched.CanBeRead(gameState)) return fetched;
                    }
                }
            }
            return null;
        }
        public void Update(IGameState gameState)
        {
            // go to next line if prompted
            if (gameState.NextLine)
            {
                if (gameState.Conversation.IsFinished)
                {
                    gameState.FinishedConversations.Add(gameState.Conversation);
                    gameState.Conversation = GetNextConversation(gameState);
                    gameState.Finished = (gameState.Conversation == null && _router.CurrentState.IsCalled("Reading"));
                }
                else
                    gameState.Conversation.Advance();
                gameState.NextLine = false;
            }
        }
    }
}