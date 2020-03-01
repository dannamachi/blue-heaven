using BlueHeaven.src.Components;
using BlueHeaven.src.Services;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Package;
using BlueHeaven.src.Enums;
using System.Collections.Generic;

namespace BlueHeaven.src.Components.Reload
{
    public class ReloadProcessor : IActionProcessor
    {
        private TypingService _typing;
        private ClickDetectingService _clicking;
        public ReloadProcessor()
        {
            RefreshService();
            Code = PackageCode.None;
            Invalid = false;
            IsClicked = false;
        }
        public void RefreshService()
        {
            _typing = new TypingService();
            _clicking = new ClickDetectingService();
        }

        public void Process(IGameState gameState)
        {
            _typing.SnapShot();
            Invalid = !_typing.UpdateTyping();
            if (!Invalid) Code = PackageBuilder.GetCode(_typing.GetCurrent);
            else Code = PackageCode.None;

            _clicking.SnapShot();
            if (_clicking.IsClicked(GraphicDimension.ReloadButton)) IsClicked = true;
            else IsClicked = false;
        }

        public PackageCode Code { get; set; }
        public string CurrentString { get => _typing.GetCurrent; }
        public bool Invalid { get; set; }
        public bool IsClicked { get; set; }
    }
}
