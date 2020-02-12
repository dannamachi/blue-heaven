using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // data: tells what state the game is in
    public class StateBeacon : IShowState
    {
        private string _name;
        private List<IShowState> _routableStates;
        private List<IShowState> _subroutes;
        private int _currentRedirect;
        public StateBeacon(string name)
        {
            _routableStates = new List<IShowState>();
            _name = name;
            _subroutes = new List<IShowState>();
            _currentRedirect = -1;
        }
        public string Name { get => _name; }

        public bool HasSubroutes { get => _currentRedirect != -1; }

        public IShowState GetSubroute
        {
            get
            {
                if (_currentRedirect < 0 || _currentRedirect >= _subroutes.Count) return this;
                else return _subroutes[_currentRedirect];
            }
        }

        public bool IsCalled(string name)
        {
            return name.Trim() == _name.Trim();

        }

        public void SetRoutes(List<IShowState> states)
        {
            _routableStates = new List<IShowState>();
            foreach (IShowState state in states)
            {
                _routableStates.Add(state);
            }
        }

        public void SetRedirect(int index)
        {
            if (index >= 0 && index < _subroutes.Count) _currentRedirect = index;
        }

        public void SetSubroutes(List<IShowState> subs)
        {
            _subroutes = subs;
            if (_subroutes.Count > 0) _currentRedirect = 0;
        }

        public IShowState RouteTo(string name)
        {
            foreach (IShowState state in _routableStates)
            {
                if (state.IsCalled(name))
                {
                    if (state.HasSubroutes) return state.GetSubroute;
                    else return state;
                }
            }
            return this;
        }
    }
}