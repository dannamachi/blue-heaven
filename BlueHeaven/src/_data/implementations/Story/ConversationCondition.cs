using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Story
{
    // data: conversation-based condition of IConversation
    public class ConversationCondition : IProvideCondition
    {
        private ConversationCode _code;
        public ConversationCondition(ConversationCode code)
        {
            _code = code;
        }
        public bool IsFulfilledBy(IGameState gameState)
        {
            return gameState.HasConversation(_code);
        }
    }
}