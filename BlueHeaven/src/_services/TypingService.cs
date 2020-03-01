using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using BlueHeaven.src.Enums;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlueHeaven.src.Services
{
    /// <summary>
    /// Handles getting a string from user
    /// </summary>
    public class TypingService
    {
        private string _current;
        private int _limit;
        private Regex _regex;
        private bool _savedValid;
        private KeyboardState _currState;
        private KeyboardState _prevState;
        public TypingService(string regex = @"[a-zA-Z0-9 ]+", int limit = 10)
        {
            _current = "your product code";
            _currState = Keyboard.GetState();
            _regex = new Regex(regex);
            _limit = limit;
            _savedValid = true;
        }

        public void SnapShot()
        {
            _prevState = _currState;
            _currState = Keyboard.GetState();
        }

        private void IsValidInput()
        {
            Match match = _regex.Match(_current);
            _savedValid = match.Success;
        }

        public bool UpdateTyping()
        {
            Keys[] pressedKeys;
            pressedKeys = _currState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (_prevState.IsKeyUp(key))
                {
                    if (key == Keys.Back && _current.Length > 0) 
                        _current = _current.Remove(_current.Length - 1, 1);
                    else if (key == Keys.Space)
                        _current = _current.Insert(_current.Length, " ");
                    else
                        _current += key.ToString();
                }
            }

            if (pressedKeys.Length != 0) IsValidInput();
            return _savedValid;
        }
    }
}
