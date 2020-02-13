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
            ChooseSwitch = true;
        }
        public void Update(IGameState gameState)
        {
            if (Chosen != -1 && ChooseSwitch)
            {
                gameState.ChoiceDispenser.SetChoice(Chosen);
                gameState.ChoiceDispenser.Chosen.IsChosen(gameState);
                ChooseSwitch = false;
            }
        }
        public int Chosen { get; set; }

        public bool ChooseSwitch { get; set; }
    }
}