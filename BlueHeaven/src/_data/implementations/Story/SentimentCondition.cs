using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Data.Story
{
    // data: sentiment-based condition for IConversation
    public class SentimentCondition : IProvideCondition
    {
        private CharacterCode _character;
        private int _status;
        private bool _moreThan;
        private CharacterCode _towardsCharacter;
        public SentimentCondition(CharacterCode character, SentimentStatus hasSentiment, CharacterCode towardsCharacter, bool moreThan = true)
        {
            _character = character;
            _status = (int)hasSentiment;
            _towardsCharacter = towardsCharacter;
            _moreThan = moreThan;
        }
        public SentimentCondition(CharacterCode character, int hasSentiment, CharacterCode towardsCharacter, bool moreThan = true)
        {
            _character = character;
            _status = hasSentiment;
            _towardsCharacter = towardsCharacter;
            _moreThan = moreThan;
        }
        public bool IsFulfilledBy(IGameState gameState)
        {
            ICharacter character = gameState.GetCharacter(_character);
            if (character == null) return false;
            if (!character.HasSentimentTowards(_towardsCharacter)) return false;
            if (_moreThan) return character.SentimentTowards(_towardsCharacter).IsOfStatus(_status);
            else return character.SentimentTowards(_towardsCharacter).IsBelowStatus(_status);
        }
    }
}