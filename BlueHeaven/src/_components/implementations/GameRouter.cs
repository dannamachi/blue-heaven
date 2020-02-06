using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // routing: controls state of game
    public class GameRouter : IRoute
    {
        public IShowState _currentState;
        public GameRouter() { }
        // get current state
        public IShowState CurrentState { get => _currentState; }
        // switch to requested state (can add condition?)
        public void RouteTo(string nextState)
        {
            _currentState = _currentState.RouteTo(nextState);
        }
        // switch to requested state, that needs param
    }
}