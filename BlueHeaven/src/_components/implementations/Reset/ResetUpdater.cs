using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using System.Collections.Generic;

namespace BlueHeaven.src.Components.Reset
{
    public class ResetUpdater : IStateUpdater
    {
        private VoidFunctionPointer _resetPointer;
        public ResetUpdater(VoidFunctionPointer resetPointer)
        {
            IsReset = false;
            _resetPointer = resetPointer;
        }
        public void Update(IGameState gameState)
        {
            if (IsReset)
            {
                _resetPointer();
            }
        }
        public bool IsReset { get; set; }
    }
}
