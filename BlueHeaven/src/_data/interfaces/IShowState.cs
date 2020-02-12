using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // abstract: tells what state the game is in
    public interface IShowState
    {
        IShowState RouteTo(string name);
        string Name { get; }
        bool IsCalled(string name);
        void SetRoutes(List<IShowState> states);
        bool HasSubroutes { get; }
        void SetSubroutes(List<IShowState> subs);
        IShowState GetSubroute { get; }
        void SetRedirect(int index);
    }
}