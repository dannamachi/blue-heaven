﻿using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;

namespace BlueHeaven.src.Components.Credits
{
    public class CreditsUpdater : IStateUpdater
    {
        private InfoService _info;
        public CreditsUpdater(InfoService info)
        {
            _info = info;
            UpPage = false;
            DownPage = false;
        }

        public void RefreshService(InfoService info)
        {
            _info = info;
        }

        public void Update(IGameState gameState)
        {
            if (UpPage) _info.UpOnePage();
            if (DownPage) _info.DownOnePage();
        }

        public bool UpPage { get; set; }

        public bool DownPage { get; set; }
    }
}
