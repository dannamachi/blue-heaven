using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // updater: updates all (active) components
    public class RootUpdater : IComponentUpdater
    {
        private IRoute _router;
        public RootUpdater(IRoute router)
        {
            _router = router;
        }
        public void Update(List<IGameComponent> components, IGameState gameState)
        {
            string currentState = _router.CurrentState.Name;
            foreach (IGameComponent component in components)
            {
                bool previousActiveState = (component.IsActive == true);
                if (component.IsActive)
                    component.Update(gameState);
                // update active status
                if (component.ActiveUnderState == "Root" || component.ActiveUnderState == currentState) component.IsActive = true;
                else component.IsActive = false;
                // setup if reactivated
                if (component.IsActive && !previousActiveState) component.Setup(gameState);
            }
        }
    }
}
