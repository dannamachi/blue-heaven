using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Navigation
{
    // updater: performs the navigation
    public class NavigationUpdater : IStateUpdater
    {
        private IRoute _router;
        public NavigationUpdater(IRoute router)
        {
            NavigatingTo = -1;
            _router = router;
        }
        public int NavigatingTo { get; set; }

        public void Update(IGameState gameState)
        {
            // menu order
            switch (NavigatingTo)
            {
                case 0:
                    _router.RouteTo("Title");
                    break;
                case 1:
                    _router.RouteTo("Reading");
                    break;
                case 2:
                    _router.RouteTo("Editing");
                    break;
            }
            CurrentState = _router.CurrentState.Name;
        }

        public string CurrentState { get; set; }
    }
}