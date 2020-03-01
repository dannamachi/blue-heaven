using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Package;
using BlueHeaven.src.Enums;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueHeaven.src.Components.Reload
{
    public class ReloadUpdater : IStateUpdater
    {
        private VoidFunctionCodeParamPointer _reloadPointer;
        public ReloadUpdater(VoidFunctionCodeParamPointer reloadPointer)
        {
            Code = PackageCode.None;
            _reloadPointer = reloadPointer;
        }

        public void Update(IGameState gameState)
        {
            if (Code != PackageCode.None)
            {
                // switch package and reset
                _reloadPointer(Code);
            }
        }

        public PackageCode Code { get; set; }
    }
}
