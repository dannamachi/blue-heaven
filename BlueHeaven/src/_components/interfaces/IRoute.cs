using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components
{
    // abstract: contains routing state of the game, and changes it upon request
    public interface IRoute
    {
        // get current state
        IShowState CurrentState { get; }
        // switch to requested state (can add condition?)
        void RouteTo(string nextState);
        // set redirect for nexted state
        void SetRedirect(string stateName, int index);
    }
}