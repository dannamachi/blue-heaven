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
        private List<IShowState> _allStates;
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

        public void SetRedirect(string stateName, int index)
        {
            foreach (IShowState state in _allStates)
            {
                if (state.IsCalled(stateName))
                    state.SetRedirect(index);
            }
        }
        
        private void LoadStates()
        {
            IShowState reading = new StateBeacon("Reading");
            IShowState story = new StateBeacon("Reading/Story");
            IShowState choosing = new StateBeacon("Reading/Choosing");
            IShowState title = new StateBeacon("Title");
            IShowState help = new StateBeacon("Help");
            IShowState credits = new StateBeacon("Credits");
            IShowState reload = new StateBeacon("Reload");
            IShowState setting = new StateBeacon("Setting");
            reading.SetSubroutes(new List<IShowState> { story, choosing });
            story.SetRoutes(new List<IShowState> { title, choosing, setting });
            choosing.SetRoutes(new List<IShowState> { title, story, setting });
            title.SetRoutes(new List<IShowState> { help, credits, reload, reading, setting });
            help.SetRoutes(new List<IShowState> { title, reading, setting });
            credits.SetRoutes(new List<IShowState> { title, reading, setting });
            reload.SetRoutes(new List<IShowState> { title, reading, setting });
            setting.SetRoutes(new List<IShowState> { title, reading });
            _allStates = new List<IShowState>
            {
                reading, story, choosing, title, help, credits,
                reload, setting
            };
            _currentState = title;
        }
    }
}