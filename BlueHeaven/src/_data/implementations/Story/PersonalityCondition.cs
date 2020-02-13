using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Story
{
    // data: personality-based condition of IConversation
    public class PersonalityCondition : IProvideCondition
    {
        private CharacterCode _character;
        private int _personality;
        public PersonalityCondition(CharacterCode character, int personality)
        {
            _character = character;
            _personality = personality;
        }
        public bool IsFulfilledBy(IGameState gameState)
        {
            ICharacter character = gameState.GetCharacter(_character);
            if (character == null) return false;
            return character.IsOfPersonality == _personality;
        }
    }
}