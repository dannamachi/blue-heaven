using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Personality
{
    // updater: updates the personality component
    public class PersonalityUpdater : IStateUpdater
    {
        public PersonalityUpdater() { }
        public void Update(IGameState gameState)
        {
            if (gameState.Editable && EditingIndex != 0)
            {
                gameState.EditingCharacter.TogglePersonality(EditingIndex);
            }
        }
        public int EditingIndex { get; set; }
    }
}