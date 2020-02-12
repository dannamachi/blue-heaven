using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Title
{ 
    // updater: performs the navigation
    public class TitleUpdater : IStateUpdater
    {
        private IRoute _router;
        public TitleUpdater(IRoute router)
        {
            _router = router;
            NavigatingTo = -1;
        }
        public int NavigatingTo { get; set; }

        public void Update(IGameState gameState)
        {
            // menu order
            switch (NavigatingTo)
            {
                case 0:
                    _router.RouteTo("Help");
                    break;
                case 1:
                    _router.RouteTo("Credits");
                    break;
                case 2:
                    _router.RouteTo("Reload");
                    break;
            }
        }
    }
}