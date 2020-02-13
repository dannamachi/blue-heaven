using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Choice
{
    // data: object that gives change to character
    public enum SentimentEffect
    {
        Romance = 0,
        Up = 5,
        UpTwice = 10,
        Down = -5,
        DownTwice = -10,
        DownAll = -60
    }
    public class ChoiceEffect : IAffectCharacter
    {
        private CharacterCode _character, _towardsCharacter;
        private SentimentEffect _effect;
        public ChoiceEffect(CharacterCode character, SentimentEffect sentimentEffect, CharacterCode towardsCharacter)
        {
            _character = character;
            _towardsCharacter = towardsCharacter;
            _effect = sentimentEffect;
        }
        public CharacterCode AffectWho { get => _character; }
        public void GiveEffect(ICharacter character)
        {
            // cancel if character is null/not applicable
            if (character == null) return;
            if (!character.IsCalled(_character)) return;
            if (!character.HasSentimentTowards(_towardsCharacter)) return;
            // effect based on parameter
            if (_effect == 0) character.SentimentTowards(_towardsCharacter).IsRomantic = true;
            else
            {
                character.SentimentTowards(_towardsCharacter).IncreaseBy((int)_effect);
            }
        }
    }
}