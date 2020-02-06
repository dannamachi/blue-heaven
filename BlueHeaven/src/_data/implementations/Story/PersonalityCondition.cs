using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Story
{
    // data: personality-based condition of IConversation
    public class PersonalityCondition : IProvideCondition
    {
        private string _character;
        private int _personality;
        public PersonalityCondition(string character, int personality)
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