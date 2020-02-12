using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // data: tells what state the game is in
    public class StateBeacon : IShowState
    {
        private string _name;
        private List<IShowState> _routableStates;
        public StateBeacon(string name)
        {
            _routableStates = new List<IShowState>();
            _name = name;
        }
        public string Name { get => _name; }
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
        public IShowState RouteTo(string name)
        {
            foreach (IShowState state in _routableStates)
            {
                if (state.IsCalled(name)) return state;
            }
            return this;
        }
    }
}