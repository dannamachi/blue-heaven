using BlueHeaven.src.Data;
using System.Collections.Generic;
namespace BlueHeaven.src.Components
{
    /// <summary>
    /// Router of game state
    /// </summary>
    public class GameRouter : IRoute
    {
        public IShowState _currentState;
        public GameRouter()
        {
            LoadStates();
        }
        // get current state
        public IShowState CurrentState { get => _currentState; }

        /// <summary>
        /// Switch to requested state
        /// </summary>
        /// <param name="nextState"></param>
        public void RouteTo(string nextState)
        {
            _currentState = _currentState.RouteTo(nextState);
        }
        
        private void LoadStates()
        {
            IShowState reading = new StateBeacon("Reading");
            IShowState choosing = new StateBeacon("Choosing");
            IShowState title = new StateBeacon("Title");
            IShowState help = new StateBeacon("Help");
            IShowState credits = new StateBeacon("Credits");
            IShowState reload = new StateBeacon("Reload");
            IShowState setting = new StateBeacon("Setting");
            reading.SetRoutes(new List<IShowState> { title, choosing, setting });
            choosing.SetRoutes(new List<IShowState> { title, reading, setting });
            title.SetRoutes(new List<IShowState> { help, credits, reload, reading, setting });
            help.SetRoutes(new List<IShowState> { title, reading, setting });
            credits.SetRoutes(new List<IShowState> { title, reading, setting });
            reload.SetRoutes(new List<IShowState> { title, reading, setting });
            setting.SetRoutes(new List<IShowState> { title, reading });
            _currentState = title;
        }
    }
}