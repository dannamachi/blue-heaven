using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Components.Choice;
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
                // specific cases
                if (component is StoryComponent)
                {
                    if (component.IsActive)
                    {
                        if ((component as StoryComponent).Choosing) _router.RouteTo("Choosing");
                    }
                }
                if (component is ChoiceComponent)
                {
                    if (component.IsActive)
                    {
                        if ((component as ChoiceComponent).Chosen) _router.RouteTo("Reading");
                    }
                }
            }
        }
    }
}
