using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Story
{
    // data: sentiment-based condition for IConversation
    public class SentimentCondition : IProvideCondition
    {
        private string _character;
        private SentimentStatus _status;
        private string _towardsCharacter;
        public SentimentCondition(string character, SentimentStatus hasSentiment, string towardsCharacter)
        {
            _character = character;
            _status = hasSentiment;
            _towardsCharacter = towardsCharacter;
        }
        public bool IsFulfilledBy(IGameState gameState)
        {
            ICharacter character = gameState.GetCharacter(_character);
            if (character == null) return false;
            if (!character.HasSentimentTowards(_towardsCharacter)) return false;
            return character.SentimentTowards(_towardsCharacter).IsOfStatus(_status);
        }
    }
}