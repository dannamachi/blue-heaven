using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Story
{
    // data: conversation-based condition of IConversation
    public class ConversationCondition : IProvideCondition
    {
        private string _conversation;
        public ConversationCondition(string conversation)
        {
            _conversation = conversation;
        }
        public bool IsFulfilledBy(IGameState gameState)
        {
            return gameState.HasConversation(_conversation);
        }
    }
}