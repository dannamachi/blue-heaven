using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Components.Choice;
using BlueHeaven.src.Components.Personality;
namespace BlueHeaven.src.Components
{
    // updater: updates all (active) components
    public class RootUpdater : IComponentUpdater
    {
        private IRoute _router;
        private bool _refreshEditing;
        public RootUpdater(IRoute router)
        {
            _router = router;
            _refreshEditing = false;
        }

        public void Update(List<IGameComponent> components, IGameState gameState)
        {
            IShowState currentState = _router.CurrentState;
            foreach (IGameComponent component in components)
            {
                bool previousActiveState = (component.IsActive == true);
                if (component.IsActive)
                    component.Update(gameState);
                // update active status
                if (component.ActiveUnderState == "Root" || currentState.IsCalled(component.ActiveUnderState)) component.IsActive = true;
                else component.IsActive = false;
                // specific cases
                if (component is StoryComponent)
                {
                    if (component.IsActive)
                    {
                        if ((component as StoryComponent).Choosing)
                        {
                            _router.RouteTo("Reading/Choosing");
                            _router.SetRedirect("Reading", 1);
                        }
                        _refreshEditing = (component as StoryComponent).NewConversation;
                    }
                }
                if (component is ChoiceComponent)
                {
                    if (component.IsActive)
                    {
                        if ((component as ChoiceComponent).Chosen)
                        {
                            _router.RouteTo("Reading/Story");
                            _router.SetRedirect("Reading", 0);
                        }
                    }
                }
                if (component is PersonalityComponent)
                {
                    if (_refreshEditing) (component as PersonalityComponent).RefreshActive();
                }
                // setup if reactivated
                if (component.IsActive && !previousActiveState) component.Setup(gameState);
            }
        }
    }
}
