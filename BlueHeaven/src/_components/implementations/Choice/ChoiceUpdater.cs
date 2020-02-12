using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Choice
{
    // updater: updates state of choosing
    public class ChoiceUpdater : IStateUpdater
    {
        public ChoiceUpdater()
        {
            Chosen = -1;
        }
        public void Update(IGameState gameState)
        {
            if (Chosen != -1)
            {
                gameState.ChoiceDispenser.SetChoice(Chosen);
                gameState.ChoiceDispenser.Chosen.IsChosen(gameState);
            }
        }
        public int Chosen { get; set; }
    }
}