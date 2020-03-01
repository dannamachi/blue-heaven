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
        public TypingService(string regex = @"[0-9a-zA-Z +-]+", int limit = 10)
        {
            _current = "your product code";
            _currState = Keyboard.GetState();
            _regex = new Regex(regex);
            _limit = limit;
            _savedValid = true;
            IsPressed = false;
        }

        /// <summary>
        /// refresh keyboard states
        /// </summary>
        public void SnapShot()
        {
            _prevState = _currState;
            _currState = Keyboard.GetState();
        }

        /// <summary>
        /// check input matches with regex
        /// </summary>
        private void IsValidInput()
        {
            Match match = _regex.Match(_current);
            _savedValid = match.Success;
        }

        /// <summary>
        /// check if key typed is valid printable key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool FilterInput(Keys key)
        {
            Keys[] valids = new Keys[] { Keys.Q,Keys.W,Keys.E,Keys.R,Keys.T,Keys.Y,
                                        Keys.U,Keys.I,Keys.O,Keys.P,Keys.A,Keys.S,
                                        Keys.D,Keys.F,Keys.G,Keys.H,Keys.J,Keys.K,
                                        Keys.L,Keys.Z,Keys.C,Keys.V,Keys.B,Keys.N,
                                        Keys.M,Keys.OemMinus,Keys.OemPlus,
                                        Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,
                                        Keys.D6,Keys.D7,Keys.D8,Keys.D9,Keys.D0};
            foreach (Keys alpha in valids)
            {
                if (key == alpha) return true;
            }
            return false;
        }

        /// <summary>
        /// get string for numerical/sign input
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetString(Keys key)
        {
            if (key == Keys.D1) return "1";
            if (key == Keys.D2) return "2";
            if (key == Keys.D3) return "3";
            if (key == Keys.D4) return "4";
            if (key == Keys.D5) return "5";
            if (key == Keys.D6) return "6";
            if (key == Keys.D7) return "7";
            if (key == Keys.D8) return "8";
            if (key == Keys.D9) return "9";
            if (key == Keys.D0) return "0";
            if (key == Keys.OemPlus) return "+";
            if (key == Keys.OemMinus) return "-";
            return key.ToString();
        }

        /// <summary>
        /// update typed string 
        /// </summary>
        /// <returns></returns>
        public bool UpdateTyping()
        {
            Keys[] pressedKeys;
            pressedKeys = _currState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (_prevState.IsKeyUp(key))
                {
                    if (key == Keys.Back)
                    {
                        if (_current.Length > 0)
                            _current = _current.Remove(_current.Length - 1, 1);
                    }
                    else if (FilterInput(key) && _current.Length <= _limit)
                        _current += GetString(key);
                }
            }

            IsPressed = pressedKeys.Length != 0;

            if (IsPressed) IsValidInput();
            return _savedValid;
        }

        public bool IsPressed { get; set; }
        public string GetCurrent { get => _current; }
    }
}
