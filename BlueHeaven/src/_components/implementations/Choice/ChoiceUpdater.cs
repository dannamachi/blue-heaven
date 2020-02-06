using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Choice
{
    // updater: updates state of choosing
    public class ChoiceUpdater : IStateUpdater
    {
        private IRoute _router;
        public ChoiceUpdater(IRoute router)
        {
            Chosen = -1;
            _router = router;
        }
        public void Update(IGameState gameState)
        {
            if (Chosen != -1)
            {
                gameState.ChoiceDispenser.SetChoice(Chosen);
                gameState.ChoiceDispenser.Chosen.IsChosen(gameState);
                _router.RouteTo("Reading");
            }
        }
        public int Chosen { get; set; }
    }
}