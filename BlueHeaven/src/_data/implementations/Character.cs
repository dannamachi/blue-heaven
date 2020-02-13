using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
using System;
namespace BlueHeaven.src.Data
{
    // data: contains data of character
    public class Character : ICharacter
    {
        private int _changeCount;
        private CharacterCode _code;
        private int _personality;
        private Dictionary<CharacterCode, ISentiment> _senDict;
        public Character(CharacterCode code, Dictionary<CharacterCode, ISentiment> sentiments, Personality initial = Personality.Arianne)
        {
            _code = code;
            _personality = (int)initial;
            _senDict = sentiments;
            _changeCount = 0;
        }
        private void TogglePersonality1()
        {
            int remainder;
            int firstpos = Math.DivRem(_personality, 1000, out remainder);
            if (firstpos == 1) _personality = remainder + 2000;
            else _personality = remainder + 1000;
        }
        private void TogglePersonality2()
        {
            int remainder, firstpos, secondpos;
            int process = Math.DivRem(_personality, 100, out remainder);
            firstpos = process / 10;
            secondpos = process - firstpos * 10;
            if (secondpos == 1) _personality = remainder + firstpos * 1000 + 200;
            else _personality = remainder + firstpos * 1000 + 100;
        }
        private void TogglePersonality3()
        {
            int remainder, firstpos, secondpos, thirdpos;
            int process = Math.DivRem(_personality, 10, out remainder);
            firstpos = process / 100;
            secondpos = (process - (firstpos * 100)) / 10;
            thirdpos = process - firstpos * 100 - secondpos * 10;
            if (thirdpos == 1) _personality = remainder + firstpos * 1000 + secondpos * 100 + 20;
            else _personality = remainder + firstpos * 1000 + secondpos * 100 + 10;
        }
        private void TogglePersonality4()
        {
            int remainder;
            int process = Math.DivRem(_personality, 10, out remainder);
            if (remainder == 1) _personality = process * 10 + 2;
            else _personality = process * 10 + 1;
        }
        public void TogglePersonality(int num)
        {
            if (IsBroken) return;
            switch (num)
            {
                case 1:
                    TogglePersonality1();
                    _changeCount += 1;
                    break;
                case 2:
                    TogglePersonality2();
                    _changeCount += 1;
                    break;
                case 3:
                    TogglePersonality3();
                    _changeCount += 1;
                    break;
                case 4:
                    TogglePersonality4();
                    _changeCount += 1;
                    break;
                default:
                    break;
            }
        }
        public bool IsCalled(CharacterCode charCode)
        {
            return _code == charCode;
        }
        public bool IsBroken
        {
            get
            {
                return IsOfPersonality == 0;
            }
        }
        public string Name
        {
            get => CharacterBuilder.GetName(_code);
        }
        public int IsOfPersonality
        {
            get
            {
                if (_changeCount > 10) return (int)Personality.Broken;
                return _personality;
            }
            set
            {
                _personality = value;
            }
        }
        public ISentiment SentimentTowards(CharacterCode code)
        {
            return _senDict[code];
        }
        public bool HasSentimentTowards(CharacterCode code)
        {
            return _senDict.ContainsKey(code);
        }
    }
}